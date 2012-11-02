﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apcurium.Tools.Localization
{
    //Working with .resx Files Programmatically http://msdn.microsoft.com/en-us/library/gg418542.aspx
    public abstract class ResourceFileHandlerBase : Dictionary<string, string>
    {
        private readonly string _filePath;

        protected ResourceFileHandlerBase(string filePath)
        {
            _filePath = filePath;
        }

        public virtual string Name
        {
            get { return Path.GetFileName(_filePath); }
        }
    }
}
