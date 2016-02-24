﻿using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using apcurium.MK.Common.Caching;
using apcurium.MK.Common.Configuration;
using apcurium.MK.Common.Diagnostic;
using apcurium.MK.Common.Extensions;
using apcurium.MK.Common.Http;
using Microsoft.Practices.Unity;
using MK.Common.Configuration;
using UnityContainer = apcurium.MK.Common.IoC.UnityServiceLocator;

namespace apcurium.MK.Booking.Api.Services
{
    public class BaseApiController : ApiController
    {
        private readonly ICacheClient _cacheClient;

        public BaseApiController()
        {
            Settings = UnityContainer.Instance.Resolve<IServerSettings>().ServerData;
            Logger = UnityContainer.Instance.Resolve<ILogger>();
            _cacheClient = UnityContainer.Instance.Resolve<ICacheClient>();
        }


        public SessionEntity GetSession()
        {
            var sessionId = Request.Headers.Where(request =>
                    request.Key.Equals("Cookie", StringComparison.InvariantCultureIgnoreCase) &&
                    request.Value.Any(val => val == "ss-opt=perm")
                )
                .Select(request => request.Value.FirstOrDefault(p => p.StartsWith("ss-pid")))
                .Select(pid => pid.Split('=').Last())
                .FirstOrDefault();

            if (!sessionId.HasValueTrimmed())
            {
                return new SessionEntity();
            }

            var urn = "urn:iauthsession:{0}".InvariantCultureFormat(sessionId);

            var cachedSession = _cacheClient.Get<SessionEntity>(urn);
            
            return cachedSession;
        }

        public ILogger Logger { get; }

        public ServerTaxiHailSetting Settings { get; }
    }
}
