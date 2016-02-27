using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XBD.Service;
using XBD.Web.Utilities;

namespace XBD.Web.Areas.Admin.Controllers
{
    public class ManageController : BaseController
    {
        // GET: Admin/Manage
        AdminSvc svc = new AdminSvc();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Setting() {
            return View();
        }

        [HttpPost]
        public ActionResult EditPwd(string oldPwd,string newPwd,string confirm)
        {
            var session = Session["LoginInfo"] as XBD.Entity.Admin;
            return Json(svc.EditPwd(oldPwd, newPwd, confirm, session.Id));
        }
    }
}