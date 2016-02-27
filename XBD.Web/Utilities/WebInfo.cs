using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XBD.Entity;
using XBD.Service;

namespace XBD.Web.Utilities
{
    public class WebInfo
    {
        public static string webTypeCode = System.Configuration.ConfigurationManager.AppSettings["WebTypeCode"];
        static ConfigSvc svc = new ConfigSvc();
        public static ConfigInfo GetWebInfo()
        {
            return svc.GetByCode(webTypeCode);
        }
    }
}