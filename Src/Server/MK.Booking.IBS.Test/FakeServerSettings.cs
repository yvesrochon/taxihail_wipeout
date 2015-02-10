﻿#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using apcurium.MK.Common.Configuration;
using apcurium.MK.Common.Configuration.Helpers;
using apcurium.MK.Common.Configuration.Impl;
using MK.Common.Configuration;

#endregion

namespace MK.Booking.IBS.Test
{
    public class FakeServerSettings : IServerSettings
    {
        private readonly Dictionary<string, string> _settings = new Dictionary<string, string>
        {
            {"IBS.WebServicesUrl", "http://apcuriumibs:6928/XDS_IASPI.DLL/soap/"}
        };

        public ServerTaxiHailSetting ServerData { get; private set; }


        public FakeServerSettings()
        {
            ServerData = new ServerTaxiHailSetting();
            Load();
        }

        public void Load()
        {
            SettingsLoader.InitializeDataObjects(ServerData, GetSettings(), null);
        }

        public IDictionary<string, string> GetSettings()
        {
            return _settings;
        }

        public ServerPaymentSettings GetPaymentSettings()
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            ServerData = new ServerTaxiHailSetting();
            Load();
        }
    }
}