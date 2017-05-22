using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Web;
using System.Web.Mvc;
using XBD.Entity;
using XBD.Service;
using XBD.Web.Utilities;

namespace XBD.Web.Controllers
{
    public class HomeController : BController
    {
        // GET: Home
        ArticleSvc svc = new ArticleSvc();
        CategorySvc cateSvc = new CategorySvc();

        NarcoticsSvc narSvc = new NarcoticsSvc();
        CaseSvc cs = new CaseSvc();

        public ActionResult Index()
        {
            ViewData["List9"] = svc.PageListByCode(1, 9, base.webTypeCode, "d_zcfg").Rows;
            ViewData["caseList"] = new CaseSvc().PageList(1, 9, webTypeCode);
            return View();
        }

        public ActionResult List(string id, int page = 1)
        {
            ViewData["List"] = svc.PageListByCode(page, 4, base.webTypeCode, id);
            var cate = cateSvc.GetByCode(id);
            ViewData["ListName"] = cate.Name;
            ViewData["ListDes"] = cate.Remark;
            ViewData["KeyWord"] = cate.KeyWord;
            return View();
        }

        public ActionResult Detail(int id)
        {
            ViewData["model"] = svc.GetById(id).Data;
            return View();
        }

        public ActionResult Case(int page = 1)
        {
            ViewData["model"] = new CaseSvc().PageList(page, 9, webTypeCode);
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Search(string keyword = "") 
        {
            ViewData["Result"] = (!string.IsNullOrEmpty(keyword)) ? narSvc.PageList(keyword) : new List<Narcotics>();
            return View();
        }

        public ActionResult PartalList()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult GetNextCase(int id) 
        {
            return Json(cs.GetNext(id, base.webTypeCode));
        }

        [HttpPost]
        public ActionResult GetPrevCase(int id)
        {
            return Json(cs.GetPrve(id, base.webTypeCode));
        }

        [HttpPost]
        public ActionResult GetCustomerCase(int id)
        {
            return Json(cs.GetCidList(id));
        }

        public ActionResult DoingBest()
        {
            var urlFromConfig = System.Configuration.ConfigurationManager.AppSettings["redirect"];
            return Redirect(urlFromConfig);
        }

    }
}