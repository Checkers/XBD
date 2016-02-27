﻿using Swift.Net.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XBD.Service;
using XBD.Web.Utilities;

namespace XBD.Web.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        AdminSvc svc = new AdminSvc();
        // GET: Admin/Admin
        public ActionResult Index(int page=1)
        {
            var list = svc.PageList(page, 10);
            ViewData["PageList"] = list;
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewData["Adm"] = svc.GetById(id).Data;
            return View();
        }

        [HttpPost]
        public ActionResult Add(XBD.Entity.Admin obj)
        {
            var res = svc.Add(obj);
            return Json(res);
        }

        [HttpPost]
        public ActionResult Del(XBD.Entity.Admin obj)
        {
            var session = Session["LoginInfo"] as XBD.Entity.Admin;
            if (obj.Id == session.Id)  return Json(new DataResult<string> { Code = -1, Data = "当前用户不能删除" });

            var res = svc.Del(obj);
            return Json(res);
        }

        [HttpPost]
        public ActionResult Edit(XBD.Entity.Admin obj)
        {
            var res = svc.Edit(obj);
            return Json(res);
        }

    }
}