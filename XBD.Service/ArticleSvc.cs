using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.Base;
using XBD.Entity;
using Swift.Net.API;
using XBD.Repository;

namespace XBD.Service
{
    public class ArticleSvc : BaseSvc<Article>
    {
        ArticleResp rep = new ArticleResp();
        public PaginationResult<ArticleDTO> PageList(int page = 1,int size =10, int webType = 0, int typeId = 0, string title = "")
        {
            var res = rep.GetList(page, size, webType,typeId,title);
            return res;
        }

        public PaginationResult<ArticleDTO> PageListByCode(int page = 1, int size = 9, string webCode="", string typeCode = "", string title = "")
        {
            var w = new CategorySvc().GetByCode(webCode);
            var t = new CategorySvc().GetByCode(typeCode);
            var type = t == null ? 0 : t.Id;
            var res = rep.GetList(page, size, w.Id, type, title);
            if(res.Rows==null) res.Rows=new List<ArticleDTO>();
            return res;
        }


        public DataResult<Article> GetById(int id)
        {
            try
            {
                var res = base.Get(id);
                return new DataResult<Article> { Code = 0, Data = res };
            }
            catch (Exception ex)
            {
                return new DataResult<Article> { Code = -1, ExtData = ex.Message };
            }
        }

        public DataResult<string> Add(Article art)
        {
            try
            {
                if (string.IsNullOrEmpty(art.Name))
                    return new DataResult<string> { Code = -1, Data = "标题不能为空" };
                if (string.IsNullOrEmpty(art.Content))
                    return new DataResult<string> { Code = -1, Data = "内容不能为空" };
                if (art.Description.Length>400)
                    return new DataResult<string> { Code = -1, Data = "摘要太长了" };
                if ((!string.IsNullOrEmpty(art.KeyWord))&&art.KeyWord.Length > 200)
                    return new DataResult<string> { Code = -1, Data = "关键词太长了" };
              
                art.AddTime = DateTime.Now;
                art.EditTime = DateTime.Now;
                var res = base.Add(art);
                return new DataResult<string> { Code = 0, Data = "添加成功" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "添加失败", ExtData = ex.Message };
            }
        }

        public DataResult<string> Edit(Article art)
        {
            try
            {
                if (string.IsNullOrEmpty(art.Name))
                    return new DataResult<string> { Code = -1, Data = "标题不能为空" };
                if (string.IsNullOrEmpty(art.Content))
                    return new DataResult<string> { Code = -1, Data = "内容不能为空" };
                if (art.Description.Length > 400)
                    return new DataResult<string> { Code = -1, Data = "摘要太长了" };
                if ((!string.IsNullOrEmpty(art.KeyWord)) && art.KeyWord.Length > 200)
                    return new DataResult<string> { Code = -1, Data = "关键词太长了" };

                var dbs = base.Get(art.Id);
                dbs.Name = art.Name;
                dbs.TypeId = art.TypeId;
                dbs.Content = art.Content;
                dbs.KeyWord = art.KeyWord;
                dbs.Description = art.Description;
                dbs.EditTime = DateTime.Now;
                dbs.Enable = art.Enable;
                dbs.Sort = art.Sort;

                var res = base.Update(dbs);
                return new DataResult<string> { Code = 0, Data = "修改成功" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "修改失败", ExtData = ex.Message };
            }
        }

        public DataResult<string> Del(Article art)
        {
            try
            {
                var res = base.Delete(art);
                return new DataResult<string> { Code = 0, Data = "删除成功" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "删除失败", ExtData = ex.Message };
            }
        }

        public DataResult<string> DelBatch(string ids)
        {
            try
            {
                ids = ids.Trim('|');
                foreach (var item in ids.Split('|'))
                {
                    base.Delete(new Article { Id=Convert.ToInt32(item)});
                }
                return new DataResult<string> { Code = 0, Data = "删除成功" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "删除失败", ExtData = ex.Message };
            }
        }

    }
}
