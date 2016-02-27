using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.Base;
using XBD.Entity;
using Swift.Net.API;

namespace XBD.Repository
{
    public class CustomerResp:BaseRep<Customer>
    {

        public PaginationResult<Customer> GetList(int page, int size, string codeName)
        {
            var sqlWhere = new StringBuilder(" 1=1 ");

            if (!string.IsNullOrEmpty(codeName))
                sqlWhere.AppendFormat(" and ar.CodeName='{0}'", codeName);

            var sql = string.Format(@"with res as(select  ROW_NUMBER() over(order by ar.Sort asc, ar.addtime desc) numid, ar.* 
	                from [Customer] ar where {0}) ", sqlWhere);

            var listSql = string.Format("{0} select top {1} * from res where numid>{2}", sql, size, (page - 1) * size);
            var countSql = string.Format("{0} select count(1)  from res", sql);

            var list = this.EfContext.Database.SqlQuery<Customer>(listSql);
            var count = this.ExecuteCount(countSql);


            return new PaginationResult<Customer> { Total = count, Rows = list == null ? new List<Customer>() : list.ToList() };
        }
    }
}
