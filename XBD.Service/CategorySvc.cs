using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.Base;
using XBD.Entity;
using Swift.Net.API;

namespace XBD.Service
{
    public class CategorySvc : BaseSvc<Category>
    {

        public PaginationResult<Category> PageList(int page, int size, int webType)
        {
            var res = base.GetPageList(page, size, t => t.Pid == webType);
            return res;
        }

        //获取当前网站下的所有分类
        public PaginationResult<Category> GetWebType(int tt = 0)
        {
            var res = base.GetPageList(0, int.MaxValue, t => t.Pid == tt);
            return res;
        }

        //获取当前网站下的所有分类
        public List<Category> GetWebTypeByCodeName(string codeName)
        {
            var parent = GetAll().FirstOrDefault(t => t.CodeName == codeName);
            var res = GetWebType(parent.Id);
            if (res == null || res.Rows == null) return new List<Category>();
            return res.Rows.OrderBy(t => t.Sort).ToList();
        }

        //根据网站类型获取网站目录分类
        public PaginationResult<Category> GetCateType(int webType)
        {
            var res = base.GetPageList(0, int.MaxValue, t => t.Pid == webType);
            return res;
        }

        //获取当前类型
        public DataResult<Category> GetCurrnetType(int typeId)
        {
            var res = base.GetAll().ToList().FirstOrDefault(t => t.Id == typeId);
            return new DataResult<Category> { Code = 0, Data = res };
        }

        public Category GetByCode(string codeName)
        {
            return GetFirst(t => t.CodeName == codeName);
        }

        public DataResult<Category> GetById(int id)
        {
            try
            {
                var res = base.Get(id);
                return new DataResult<Category> { Code = 0, Data = res };
            }
            catch (Exception ex)
            {
                return new DataResult<Category> { Code = -1, ExtData = ex.Message };
            }
        }


        public Category GetDefaultWebType()
        {
            return base.GetFirst(t => t.Pid == 0);
        }

        public DataResult<string> Add(Category cate)
        {
            try
            {
                if (string.IsNullOrEmpty(cate.Name))
                    return new DataResult<string> { Code = -1, Data = "名称不能为空" };
                if (string.IsNullOrEmpty(cate.CodeName))
                    return new DataResult<string> { Code = -1, Data = "名称代码不能为空" };
                if (string.IsNullOrEmpty(cate.Link))
                    return new DataResult<string> { Code = -1, Data = "链接地址不能为空" };
                if (base.GetFirst(t => t.CodeName == cate.CodeName) != null)
                    return new DataResult<string> { Code = -1, Data = "分类代码已经存在,请更换" };

                cate.AddTime = DateTime.Now;
                cate.EditTime = DateTime.Now;
                var res = base.Add(cate);
                return new DataResult<string> { Code = 0, Data = "添加成功" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "添加失败", ExtData = ex.Message };
            }
        }

        public DataResult<string> Edit(Category cate)
        {
            try
            {
                if (string.IsNullOrEmpty(cate.Name))
                    return new DataResult<string> { Code = -1, Data = "名称不能为空" };
                if (string.IsNullOrEmpty(cate.CodeName))
                    return new DataResult<string> { Code = -1, Data = "名称代码不能为空" };
                if (string.IsNullOrEmpty(cate.Link))
                    return new DataResult<string> { Code = -1, Data = "链接地址不能为空" };

                var dbs = base.Get(cate.Id);
                dbs.Name = cate.Name;
                dbs.Pid = cate.Pid;
                dbs.Remark = cate.Remark;
                dbs.CodeName = cate.CodeName;
                dbs.KeyWord = cate.KeyWord;
                dbs.Link = cate.Link;
                dbs.EditTime = DateTime.Now;
                dbs.Enable = cate.Enable;
                dbs.Sort = cate.Sort;

                var res = base.Update(dbs);
                return new DataResult<string> { Code = 0, Data = "修改成功" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "修改失败", ExtData = ex.Message };
            }
        }

        public DataResult<string> Del(Category cate)
        {
            try
            {
                var res = base.Delete(cate);
                return new DataResult<string> { Code = 0, Data = "删除成功" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "删除失败", ExtData = ex.Message };
            }
        }

    }
}
