using Swift.Net.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBD.Entity;
using XBD.Repository;

namespace XBD.Service
{
    public class NarcoticsSvc : BaseSvc<Narcotics>
    {
        NarcoticsResp rep = new NarcoticsResp();
        public List<Narcotics> PageList(string keyword)
        {
            var res = rep.GetList(keyword);
            return res;
        }

        public void AddAll(DataTable dt)
        {
            foreach (DataRow item in dt.Rows)
            {
                var obj = new Narcotics
                {
                    Name = item["品名"] + "",
                    SubName = item["别名"] + "",
                    CASNo = item["CAS号"] + "",
                    AddTime = DateTime.Now,
                    EditTime = DateTime.Now,
                    Remark = item["备注"] + "",
                };
                base.Add(obj, false);
            }
            base.Commit();
        }
    }
}
