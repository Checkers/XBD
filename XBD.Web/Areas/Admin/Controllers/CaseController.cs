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
    public class CaseController : BaseController
    {
        // GET: Admin/Case

        CaseSvc svc = new CaseSvc();
        CategorySvc Catesvc = new CategorySvc();
        CustomerSvc csv = new CustomerSvc();
        // GET: Admin/Case
        public ActionResult Index(int page = 1, string webType = "")
        {
            var webType1 = Catesvc.GetWebType();
            ViewData["WebType"] = webType1.Rows;

            webType = string.IsNullOrEmpty(webType) ? Catesvc.GetDefaultWebType().CodeName : webType;
            var list = svc.PageList(page, 10, webType);
            ViewData["PageList"] = list;
            return View();
        }
        public ActionResult Add()
        {
            var webType = Catesvc.GetWebType();
            ViewData["WebType"] = webType.Rows;
            return View();
        }

        [HttpPost]
        public ActionResult CustomerList(string webType)
        {
            return Json(csv.PageList(1, int.MaxValue, webType));
        }

        public ActionResult Edit(int id)
        {
            ViewData["Cate"] = svc.GetById(id).Data;

            var webType = Catesvc.GetWebType();
            ViewData["WebType"] = webType.Rows;
            return View();
        }


        [HttpPost]
        public ActionResult Add(Case obj)
        {
            return Json(svc.Add(obj));
        }

        [HttpPost]
        public ActionResult List(int page, int size)
        {
            return Json(svc.GetPageList(page, size));
        }

        [HttpPost]
        public ActionResult Edit(Case obj)
        {
            return Json(svc.Edit(obj));
        }

        [HttpPost]
        public ActionResult Del(Case obj)
        {
            return Json(svc.Del(obj));
        }
    }
}