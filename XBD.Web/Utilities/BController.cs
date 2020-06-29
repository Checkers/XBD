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

        public List<int> GetPageNumList(int cidx, int total, decimal psize)
        {
            var result = new List<int>();
            var pageLen = (int)Math.Ceiling(total / psize);

            var si = cidx <= (6 / 2 + 1) ? 1 : cidx - 6 / 2;
            var ei = si + 6 - 1;

            while (si <= pageLen && si <= ei)
            {
                result.Add(si);
                si++;
            }

            //if (result.First() > 1) result.Insert(0, 0);
            //if (result.Last() < pageLen) result.Add(0);

            return result;
        }
    }
}