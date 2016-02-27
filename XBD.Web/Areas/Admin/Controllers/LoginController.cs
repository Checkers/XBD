using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XBD.Service;

namespace XBD.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        AdminSvc svc = new AdminSvc();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Check(Entity.Admin admin)
        {
            var cres = svc.Check(admin.Name, admin.Pwd);
            if (cres.Code == 0) Session["LoginInfo"] = cres.ExtData;
            return Json(cres);
        }

        public ActionResult LogOut(Entity.Admin admin)
        {
             Session["LoginInfo"] = null;
            return RedirectToAction("Index");
        }
    }
}