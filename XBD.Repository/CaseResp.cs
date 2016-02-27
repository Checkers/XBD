using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.Base;
using XBD.Entity;
using Swift.Net.API;
using XBD.Entity.DTO;

namespace XBD.Repository
{
    public class CaseResp : BaseRep<Case>
    {

        public PaginationResult<CaseDTO> GetList(int page, int size, string codeName)
        {
            var sqlWhere = new StringBuilder(" 1=1 ");

            if (!string.IsNullOrEmpty(codeName))
                sqlWhere.AppendFormat(" and ar.CodeName='{0}'", codeName);

            var sql = string.Format(@"with res as(select  ROW_NUMBER() over(order by ar.Sort asc, ar.addtime desc) numid, ar.* 
	                from [Case] ar where {0}) ", sqlWhere);

            var listSql = string.Format("{0} select top {1} * from res where numid>{2}", sql, size, (page - 1) * size);
            var countSql = string.Format("{0} select count(1)  from res", sql);

            var list = this.EfContext.Database.SqlQuery<CaseDTO>(listSql);
            var count = this.ExecuteCount(countSql);


            return new PaginationResult<CaseDTO> { Total = count, Rows = list == null ? new List<CaseDTO>() : list.ToList() };
        }



        public List<CaseDTO> GetCidList(int cid)
        {
            var sql = string.Format(@"select  ROW_NUMBER() over(order by ar.Sort asc, ar.addtime desc) numid, ar.* 
	                from [Case] ar where ar.CustomerId={0}", cid);
            var list = this.EfContext.Database.SqlQuery<CaseDTO>(sql);

            return list == null ? null : list.ToList();
        }



        public CaseDTO GetNext(int id, string codeName)
        {
            var sql = string.Format(@"select * from (select  ROW_NUMBER() over(order by ar.Sort asc, ar.addtime desc) numid, 
                                    ar.* from [Case] ar where CodeName='{1}') as res where numid={0}", ++id, codeName);
            var obj = this.EfContext.Database.SqlQuery<CaseDTO>(sql);
            return obj == null ? null : obj.FirstOrDefault();

        }

        public CaseDTO GetPrve(int id, string codeName)
        {
            var sql = string.Format(@"select * from (select  ROW_NUMBER() over(order by ar.Sort asc, ar.addtime desc) numid, 
                                    ar.* from [Case] ar where CodeName='{1}') as res where numid={0}", --id, codeName);
            var obj = this.EfContext.Database.SqlQuery<CaseDTO>(sql);
            return obj == null ? null : obj.FirstOrDefault();

        }

    }
}
