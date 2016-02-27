using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XBD.Entity;
using XBD.Service;
using XBD.Web.Utilities;

namespace XBD.Web.Areas.Admin.Controllers
{
    public class ArticleController : BaseController
    {
        ArticleSvc svc = new ArticleSvc();
        CategorySvc cateSvc = new CategorySvc();
        // GET: Admin/Article
        public ActionResult Index(int page = 1, int webType = 0, int typeId = 0, string title = "")
        {
            var list = svc.PageList(page, 10, webType, typeId, System.Web.HttpUtility.UrlDecode(title));
            var res = cateSvc.GetWebType();
            ViewData["WebType"] = res.Rows;
            ViewData["PageList"] = list;
            return View();
        }

        public ActionResult Add()
        {
            var webType = cateSvc.GetWebType();
            ViewData["WebType"] = webType.Rows;
            return View();
        }

        public ActionResult Edit(int id)
        {
            var webType = cateSvc.GetWebType();
            var cur = svc.GetById(id);
            var pobj = cateSvc.GetCurrnetType(cur.Data.TypeId.Value);
            var cateype = cateSvc.GetWebType(pobj.Data.Pid.Value);
            ViewData["WebType"] = webType.Rows;
            ViewData["Art"] = cur.Data;
            ViewData["Pid"] = pobj.Data.Pid;
            ViewData["CateTypeList"] = cateype.Rows;
            return View();
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult Add(XBD.Entity.Article obj)
        {
            return Json(svc.Add(obj));
        }

        [HttpPost]
        public ActionResult List(int page, int size)
        {
            return Json(svc.GetPageList(page, size));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(XBD.Entity.Article obj)
        {
            return Json(svc.Edit(obj));
        }

        [HttpPost]
        public ActionResult Del(XBD.Entity.Article obj)
        {
            return Json(svc.Del(obj));
        }

        [HttpPost]
        public ActionResult DelBatch(string ids)
        {
            return Json(svc.DelBatch(ids));
        }

    }
}