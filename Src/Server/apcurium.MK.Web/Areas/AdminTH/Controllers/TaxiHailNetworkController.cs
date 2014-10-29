﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Mvc;
using apcurium.MK.Booking.Api.Contract.Requests;
using apcurium.MK.Booking.Api.Services;
using apcurium.MK.Common.Configuration;
using CustomerPortal.Client;
using CustomerPortal.Contract.Resources;
using ServiceStack.CacheAccess;
using ServiceStack.ServiceClient.Web;

namespace apcurium.MK.Web.Areas.AdminTH.Controllers
{
    public class TaxiHailNetworkController : ServiceStackController
    {
        private readonly IServerSettings _serverSettings;
        private readonly ITaxiHailNetworkServiceClient _taxiHailNetworkService;
        private readonly ConfigurationsService _configurationsService;
        private readonly string _applicationKey;

        // GET: AdminTH/TaxiHailNetwork
        public TaxiHailNetworkController(ICacheClient cache, IServerSettings serverSettings, ITaxiHailNetworkServiceClient taxiHailNetworkService, ConfigurationsService configurationsService) 
            : base(cache, serverSettings)
        {
            _serverSettings = serverSettings;
            _taxiHailNetworkService = taxiHailNetworkService;
            _configurationsService = configurationsService;

            _applicationKey = serverSettings.ServerData.TaxiHail.ApplicationKey;
        }

        public async Task<ActionResult> Index()
        {
            if (AuthSession.IsAuthenticated)
            {
                var response = await _taxiHailNetworkService.GetNetworkCompanyPreferences(_applicationKey);

                return View(response);
            }

               return Redirect(BaseUrl);
        }

        [HttpPost]
        public async Task<JsonResult> Index(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var companyPreferences = await _taxiHailNetworkService.GetNetworkCompanyPreferences(_applicationKey);

                var preferences = new List<CompanyPreference>();
                for (var i = 0; i < companyPreferences.Count; i++)
                {
                    int? order=null;
                    order = form["orderKey_" + companyPreferences[i].CompanyPreference.CompanyKey] == string.Empty 
                        ? i 
                        : int.Parse(form["orderKey_" + companyPreferences[i].CompanyPreference.CompanyKey]);

                    var canAccept = form["acceptKey_" + companyPreferences[i].CompanyPreference.CompanyKey].Contains("true");
                    var canDispatch = form["dispatchKey_" + companyPreferences[i].CompanyPreference.CompanyKey].Contains("true");
                    preferences.Add(new CompanyPreference
                    {
                        CompanyKey = form["idKey_" + companyPreferences[i].CompanyPreference.CompanyKey], 
                        CanAccept = canAccept, 
                        CanDispatch = canDispatch,
                        Order=order
                    });
                    

                }

                await _taxiHailNetworkService.SetNetworkCompanyPreferences(_applicationKey, preferences.OrderBy(thn => thn.Order.HasValue)
                    .ThenBy(thn => thn.Order.GetValueOrDefault()).ToArray());

                SaveNetworkSettingsIfNecessary();

                 return Json(new { Success = true, Message = "Changes Saved" });
            }

            return Json(new { Success = false, Message = "All fields are required" });
        }

        private  void SaveNetworkSettingsIfNecessary()
        {
            if(!_serverSettings.ServerData.Network.Enabled)
            {
                _configurationsService.Post(new ConfigurationsRequest
                {
                    AppSettings = new Dictionary<string, string> { { "Network.Enabled", "true" } }
                });
            }
        }
    }
}