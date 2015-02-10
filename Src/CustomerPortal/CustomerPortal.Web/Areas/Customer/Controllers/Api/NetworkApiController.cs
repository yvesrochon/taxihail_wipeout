﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerPortal.Contract.Resources;
using CustomerPortal.Contract.Response;
using CustomerPortal.Web.Entities;
using CustomerPortal.Web.Entities.Network;
using CustomerPortal.Web.Extensions;
using MongoRepository;
using Newtonsoft.Json;

namespace CustomerPortal.Web.Areas.Customer.Controllers.Api
{
    public class NetworkApiController : ApiController
    {
        private readonly IRepository<TaxiHailNetworkSettings> _networkRepository;
        private readonly IRepository<Company> _companyRepository;


        public NetworkApiController() 
            : this(new MongoRepository<TaxiHailNetworkSettings>(), new MongoRepository<Company>())
        {
        }

        public NetworkApiController(IRepository<TaxiHailNetworkSettings> networkRepository, IRepository<Company> companyRepository)
        {
            _networkRepository = networkRepository;
            _companyRepository = companyRepository;
        }

        [Route("api/customer/{companyId}/network")]
        public HttpResponseMessage Get(string companyId)
        {
            var networkSettings = _networkRepository.FirstOrDefault(n => n.Id == companyId);
            
            if (networkSettings == null || !networkSettings.IsInNetwork)
            {
                return null;
            }

            var otherCompaniesInNetwork = _networkRepository.Where(n => n.IsInNetwork && n.Id != networkSettings.Id)
                .ToArray();

            var overlappingCompanies = otherCompaniesInNetwork.Where(n => n.Region.Contains(networkSettings.Region))
                .ToArray();

            var preferences = new List<CompanyPreferenceResponse>();

            foreach (var nearbyCompany in overlappingCompanies)
            {

                var companyPreference = networkSettings.Preferences.FirstOrDefault(p => p.CompanyKey == nearbyCompany.Id) 
                			?? new CompanyPreference{ CompanyKey = nearbyCompany.Id };

                var nearbyCompanyAllowUsToDispatch = nearbyCompany.Preferences.Any(x => x.CompanyKey == companyId && x.CanAccept);

                preferences.Add(new CompanyPreferenceResponse
                {
                    CompanyPreference = companyPreference,
                    CanDispatchTo = nearbyCompanyAllowUsToDispatch
                });
            }

            var sortedCompanyPreferences = preferences
                .OrderBy(p => p.CompanyPreference.Order == null)
                .ThenBy(p => p.CompanyPreference.Order);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(sortedCompanyPreferences))
            };
        }

        [Route("api/customer/{companyId}/network")]
        public HttpResponseMessage Post(string companyId, CompanyPreference[] preferences)
        {
            var networkSetting = _networkRepository.FirstOrDefault(x => x.Id == companyId);

            if (networkSetting == null)
            {
                return new HttpResponseMessage(HttpStatusCode.Forbidden); 
            }
            
            foreach (var companyPreference in preferences.Where(p => !p.CanAccept))
            {
                var company = _networkRepository.FirstOrDefault(x => x.Id == companyPreference.CompanyKey);
                if (company != null)
                {
                    var theirPreference = company.Preferences.FirstOrDefault(p => p.CompanyKey == companyId);
                    if (theirPreference != null)
                    {
                        theirPreference.CanDispatch = false;
                        _networkRepository.Update(company);
                    }
                }
            }

            networkSetting.Preferences = preferences.ToList();

            _networkRepository.Update(networkSetting);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Route("api/customer/{companyId}/networkfleet")]
        public HttpResponseMessage Get(string companyId, double? latitude, double? longitude)
        {
            // Cast mongo repo to list to have access to all the LINQ enumerators without the mongo driver restriction
            var network = _networkRepository.ToList();

            MapCoordinate coordinate = null;

            if (latitude.HasValue && longitude.HasValue)
            {
                coordinate = new MapCoordinate
                {
                    Latitude = latitude.Value,
                    Longitude = longitude.Value
                };
            }

            var currentCompanyNetworkSettings = network.FirstOrDefault(n => n.Id == companyId);

            if (currentCompanyNetworkSettings == null || !currentCompanyNetworkSettings.IsInNetwork)
            {
                return null;
            }

            var networkFleetResult = new List<NetworkFleetResponse>();

            // Find all companies that are setup to dispatch orders
            var dispatchableCompanies = currentCompanyNetworkSettings.Preferences.Where(n => n.CanDispatch).OrderBy(n => n.Order);

            foreach (var companyPreferences in dispatchableCompanies)
            {
                var company = _companyRepository.FirstOrDefault(c => c.CompanyKey == companyPreferences.CompanyKey);
                if (company != null)
                {
                    var fleet = new NetworkFleetResponse
                    {
                        CompanyKey = company.CompanyKey,
                        CompanyName = company.CompanyName,
                        IbsPassword = company.IBS.Password,
                        IbsUserName = company.IBS.Username,
                        IbsUrl = company.IBS.ServiceUrl
                    };

                    if (coordinate != null)
                    {
                        var isCompanyInZone = network.Any(n => n.Id == companyPreferences.CompanyKey && n.Region.Contains(coordinate));
                        if (isCompanyInZone)
                        {
                            // Company coverage is in the network zone. Add it to the fleet.
                            networkFleetResult.Add(fleet);
                        }
                    }
                    else
                    {
                        networkFleetResult.Add(fleet);
                    }
                }
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(networkFleetResult))
            };
        }
    }
}