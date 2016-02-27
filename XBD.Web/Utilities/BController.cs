using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XBD.Web.Utilities
{
    public class BController : Controller
    {
        public string webTypeCode = System.Configuration.ConfigurationManager.AppSettings["WebTypeCode"];

    }
}