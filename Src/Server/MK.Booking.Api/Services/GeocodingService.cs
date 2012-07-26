﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface;
using apcurium.MK.Booking.Api.Contract.Requests;
using apcurium.MK.Booking.Api.Contract.Resources;
using ServiceStack.ServiceClient.Web;
using apcurium.MK.Common.Extensions;
using ServiceStack.Common.Web;
using System.Net;
using System.Globalization;
using apcurium.MK.Booking.Api.Services.GoogleApi;
using apcurium.MK.Common.Configuration;

namespace apcurium.MK.Booking.Api.Services
{
    public class GeocodingService : RestServiceBase<GeocodingRequest>
    {
        private IConfigurationManager _configManager;
        public GeocodingService(IConfigurationManager configManager)
        {
            _configManager = configManager;
        }


        public override object OnGet(GeocodingRequest request)
        {
            var client = new JsonServiceClient("http://maps.googleapis.com/maps/api/");

            

            var result = GetResultUsingFilter(client, request, true);

            if (result.Addresses.Count() == 0)
            {
                return GetResultUsingFilter(client, request, false);
            }
            else
            {
                return result;
            }
        }

        private AddressList GetResultUsingFilter(JsonServiceClient client, GeocodingRequest request, bool useFilter)
        {
            var resource = CreateResourceFromRequest(request, useFilter);

            var geoResult = client.Get<GeoResult>(resource);

            if (geoResult.Status == ResultStatus.OK)
            {
                var addressFilter = _configManager.GetSetting("GeoLoc.AddressFilter");
                var googleResults = geoResult.Results.ToArray();

                var addresses = googleResults.Where(r => r.Formatted_address.HasValue() &&
                                                         (addressFilter.IsNullOrEmpty() || r.Formatted_address.ToLower().Contains(addressFilter.ToLower())) &&
                                                         r.Geometry != null && r.Geometry.Location != null &&
                                                         r.Geometry.Location.Lng != 0 && r.Geometry.Location.Lat != 0 &&
                                                         r.AddressComponentTypes.Any(type => type == AddressComponentType.Street_address))
                                            .Select(r => ConvertToAddress(r)).ToArray();

                if (addresses.Count() == 0)
                {
                    addresses = googleResults.Where(r => r.Formatted_address.HasValue() &&
                                                         r.Geometry != null && r.Geometry.Location != null &&
                                                         r.Geometry.Location.Lng != 0 && r.Geometry.Location.Lat != 0 &&
                                                         r.AddressComponentTypes.Any(type => type == AddressComponentType.Street_address))
                                            .Select(r => ConvertToAddress(r)).ToArray();
                }

                return new AddressList { Addresses = addresses };
            }
            else
            {
                return new AddressList();
            }
        }

        private Address ConvertToAddress(GeoObj obj)
        {
            return new Address { FullAddress = obj.Formatted_address, Id = Guid.Empty, Latitude = obj.Geometry.Location.Lat, Longitude = obj.Geometry.Location.Lng };
        }

        private string CreateResourceFromRequest(GeocodingRequest request, bool useFilter)
        {
         
            if ( (request.Lat.HasValue && request.Lng.HasValue && request.Name.HasValue()) ||
                (!request.Lat.HasValue && !request.Lng.HasValue && !request.Name.HasValue()))
            {
                throw new HttpError(HttpStatusCode.BadRequest, "400", "You must specify the name or the coordinate");
            }
            
            if (request.Name.HasValue())
            {
                var filter = _configManager.GetSetting("GeoLoc.SearchFilter");

                if ((filter.HasValue()) && (useFilter))
                {
                    var filteredName = string.Format(filter, request.Name.Split(' ').JoinBy("+"));
                    return string.Format(CultureInfo.InvariantCulture, "geocode/json?address={0}&sensor=false", filteredName );
                }
                else
                {
                    return string.Format(CultureInfo.InvariantCulture, "geocode/json?address={0}&sensor=false", request.Name.Split(' ').JoinBy("+"));
                }                
            }
            else
            {
                return string.Format( CultureInfo.InvariantCulture, "geocode/json?latlng={0},{1}&sensor=false", request.Lat, request.Lng);
            }

        }



    }
}
