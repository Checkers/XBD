using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XBD.Entity;
using XBD.Service;
using XBD.Web.Utilities;


namespace XBD.Web.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {

        // GET: Admin/Customer
        CustomerSvc svc = new CustomerSvc();
        CategorySvc Catesvc = new CategorySvc();
        public ActionResult Index(int page = 1, string CodeName = "Danger")
        {
            var webType = Catesvc.GetWebType();
            ViewData["WebType"] = webType.Rows;
            CodeName = Request.QueryString["webType"] ?? CodeName;
            var list = svc.PageList(page, 10, CodeName);
            ViewData["PageList"] = list;
            return View();
        }
        public ActionResult Add()
        {
            var webType = Catesvc.GetWebType();
            ViewData["WebType"] = webType.Rows;
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewData["Cate"] = svc.GetById(id).Data;
            return View();
        }


        [HttpPost]
        public ActionResult Add(Customer obj)
        {
            return Json(svc.Add(obj));
        }

        [HttpPost]
        public ActionResult List(int page, int size)
        {
            return Json(svc.GetPageList(page, size));
        }

        [HttpPost]
        public ActionResult Edit(Customer obj)
        {
            return Json(svc.Edit(obj));
        }

        [HttpPost]
        public ActionResult Del(Customer obj)
        {
            return Json(svc.Del(obj));
        }
    }
}