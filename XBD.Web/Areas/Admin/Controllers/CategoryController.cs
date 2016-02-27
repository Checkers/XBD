using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XBD.Service;
using XBD.Entity;
using XBD.Web.Utilities;

namespace XBD.Web.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        CategorySvc svc = new CategorySvc();
        // GET: Admin/Category
        public ActionResult Index(int page = 1, int webType = 1)
        {
            var list = svc.PageList(page, 10, webType);
            var res = svc.GetWebType();
            ViewData["WebType"] = res.Rows;
            ViewData["PageList"] = list;
            return View();
        }

        public ActionResult Add()
        {
            var webType = svc.GetWebType();
            ViewData["WebType"] = webType.Rows;
            return View();
        }

        public ActionResult Edit(int id)
        {
            var webType = svc.GetWebType();
            ViewData["WebType"] = webType.Rows;
            ViewData["Cate"] = svc.GetById(id).Data;
            return View();
        }


        [HttpPost]
        public ActionResult Add(Category obj) {
            return Json(svc.Add(obj));
        }

        [HttpPost]
        public ActionResult List(int page,int size)
        {
            return Json(svc.GetPageList(page,size));
        }

        [HttpPost]
        public ActionResult Edit(Category obj)
        {
            return Json(svc.Edit(obj));
        }

        [HttpPost]
        public ActionResult Del(Category obj)
        {
            return Json(svc.Del(obj));
        }

        [HttpPost]
        public ActionResult GetCateType(int id)
        {
            return Json(svc.GetCateType(id));
        }
    }
}