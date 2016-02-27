using Swift.Net.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBD.Entity;

namespace XBD.Repository
{
    public class NarcoticsResp : BaseRep<Narcotics>
    {
        public List<Narcotics> GetList(string keyword)
        {
            var sql = string.Format(@"select nr.[Id],nr.Name,nr.[SubName],nr.CASNo,nr.[AddTime],nr.[EditTime],nr.[Remark],nr.[Enable]
                                    from Narcotics nr where CASNo='{0}' or Name='{0}' or SubName='{0}'", keyword);

            var sql2 = string.Format(@"select nr.[Id],nr.Name,nr.[SubName],nr.CASNo,nr.[AddTime],nr.[EditTime],nr.[Remark],nr.[Enable]
                                    from Narcotics nr where (CASNo like '%{0}%' or Name like '%{0}%' or SubName like '%{0}%') 
                                    and CASNo!='{0}' and Name!='{0}' and SubName!='{0}'", keyword);
            var list = this.EfContext.Database.SqlQuery<Narcotics>(sql);
            var list2 = this.EfContext.Database.SqlQuery<Narcotics>(sql2);
            var result = list == null ? new List<Narcotics>():list.ToList();
            if(list2!=null) result.AddRange(list2.ToList());
            return result;
        }
    }
}
