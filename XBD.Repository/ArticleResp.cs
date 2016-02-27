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
    public class ArticleResp:BaseRep<Article>
    {
        public PaginationResult<ArticleDTO> GetList(int page, int size, int webType = 0, int typeId = 0, string title = "")
        {
            var sqlWhere = new StringBuilder(" 1=1 ");

            if (webType != 0)
                sqlWhere.AppendFormat(" and ca.Pid={0}",webType);

            if (typeId != 0)
                sqlWhere.AppendFormat(" and ar.TypeId={0}", typeId);

            if (!string.IsNullOrEmpty(title))
                sqlWhere.AppendFormat(" and ar.Name like '%{0}%'", title);

            var sql = string.Format(@"with res as(select  ROW_NUMBER() over(order by ar.Sort asc, ar.addtime desc) numid, ar.[Id],
                    ar.[TypeId],ca.Name as TypeStr,ar.[Name],
                    ar.[Description],ar.[KeyWord],ar.[Sort] ,ar.[AddTime],ar.[EditTime],ar.[Remark],ar.[Enable]  
	                from article ar left join Category ca on ar.TypeId=ca.Id
	                where {0}) ",sqlWhere);

            var listSql = string.Format("{0} select top {1} * from res where numid>{2}", sql, size, (page - 1) * size);
            var countSql = string.Format("{0} select count(1)  from res", sql);

            var list = this.EfContext.Database.SqlQuery<ArticleDTO>(listSql);
            var count = this.ExecuteCount(countSql);

            return new PaginationResult<ArticleDTO> { Total=count,Rows=list==null?new List<ArticleDTO>():list.ToList()};
        }
    }
}
