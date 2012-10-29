﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace apcurium.MK.Common.Configuration.Impl
{
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly Func<ConfigurationDbContext> _contextFactory;

        public ConfigurationManager(Func<ConfigurationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IDictionary<string, string> GetAllSettings()
        {
            using (var context = _contextFactory.Invoke())
            {
                return context.Query<AppSetting>().Select(x => x).ToDictionary(x=>x.Key,r=>r.Value);
            }
        }

        public void Reset()
        {
            
        }

        public string GetSetting(string key)
        {
            using (var context = _contextFactory.Invoke())
            {
                return context.Query<AppSetting>().Where(x => x.Key.Equals(key)).Select(x=>x.Value).FirstOrDefault();
            }
        }

        public void SetSetting(string key, string value)
        {
        }

        private void Save(string key, string value)
        {
           
        }

        private void Load()
        {
          
        }
    }
}