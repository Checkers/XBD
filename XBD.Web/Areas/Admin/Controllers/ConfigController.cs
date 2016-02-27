using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XBD.Service;
using XBD.Entity;
using Newtonsoft.Json;
using Swift.Net.API;
using XBD.Web.Utilities;
namespace XBD.Web.Areas.Admin.Controllers
{
    public class ConfigController : BaseController
    {
        ConfigSvc svc = new ConfigSvc();
        CategorySvc Catesvc = new CategorySvc();
        public ActionResult Index(string webTypeCode)
        {
            var res = Catesvc.GetWebType();
            ViewData["WebType"] = res.Rows;

            webTypeCode = string.IsNullOrEmpty(webTypeCode) ? Catesvc.GetDefaultWebType().CodeName : webTypeCode;
            var ret = svc.GetByCode(webTypeCode);
            ret = ret ?? new ConfigInfo();
            ViewData["Config"] = ret;

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddOrEdit(ConfigInfo obj)
        {
            return Json(svc.AddOrEdit(obj));
        }
    }
}