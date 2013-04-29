
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using apcurium.MK.Booking.Api.Client.TaxiHail;
using apcurium.MK.Booking.Mobile.AppServices;
using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Booking.Api.Client;
using TinyIoC;
using apcurium.MK.Booking.Mobile.Infrastructure;
using System.Threading.Tasks;
using System.Threading;

namespace apcurium.MK.Booking.Mobile.AppServices.Impl
{
    public class ApplicationInfoService : BaseService, IApplicationInfoService
    {
        private const string _appInfoCacheKey = "ApplicationInfo";

        public ApplicationInfo GetAppInfo( )
        {
            var info = TinyIoCContainer.Current.Resolve<IAppCacheService>().Get<ApplicationInfo>(_appInfoCacheKey);

            if (info == null)
            {
                info = new ApplicationInfo();
                UseServiceClient<ApplicationInfoServiceClient>(service =>
                {
                    info = service.GetAppInfo();
                    TinyIoCContainer.Current.Resolve<IAppCacheService>().Set<ApplicationInfo>(_appInfoCacheKey, info, DateTime.Now.AddHours(1));
                });
            }
            return info;
        }
        public void ClearAppInfo()
        {
            TinyIoCContainer.Current.Resolve<IAppCacheService>().Clear (_appInfoCacheKey);
        }
        
        
        public void CheckVersion()
        {

            var t = Task.Factory.StartNew(() =>
            {
                bool isUpToDate;
                try
                {
                    var app = GetAppInfo();
                    isUpToDate = app.Version.StartsWith("1.4.");
                }
                catch (Exception e)
                {
                    isUpToDate = true;
                }

                if (!isUpToDate)
                {

                    var title = TinyIoCContainer.Current.Resolve<IAppResource>().GetString("AppNeedUpdateTitle");
                    var msg = TinyIoCContainer.Current.Resolve<IAppResource>().GetString("AppNeedUpdateMessage");
                    var mService = TinyIoCContainer.Current.Resolve<IMessageService>();
                    mService.ShowMessage(title, msg);
                }
            });



        }


    }
}

