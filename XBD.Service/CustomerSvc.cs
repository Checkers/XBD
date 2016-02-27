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
    public class CustomerSvc : BaseSvc<Customer>
    {
        CategorySvc svc = new CategorySvc();
        public PaginationResult<Customer> PageList(int page, int size, string webType)
        {
            var cusvc = new CustomerResp();
            var res = cusvc.GetList(page, size, webType);
            return res;
        }

        public DataResult<Customer> GetById(int id)
        {
            try
            {
                var res = base.Get(id);
                return new DataResult<Customer> { Code = 0, Data = res };
            }
            catch (Exception ex)
            {
                return new DataResult<Customer> { Code = -1, ExtData = ex.Message };
            }
        }

        public DataResult<string> Add(Customer obj)
        {
            try
            {
                if (string.IsNullOrEmpty(obj.Name))
                    return new DataResult<string> { Code = -1, Data = "名称不能为空" };
                if (string.IsNullOrEmpty(obj.CodeName))
                    return new DataResult<string> { Code = -1, Data = "名称代码不能为空" };
                obj.AddTime = DateTime.Now;
                obj.EditTime = DateTime.Now;
                var res = base.Add(obj);
                return new DataResult<string> { Code = 0, Data = "添加成功" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "添加失败", ExtData = ex.Message };
            }
        }

        public DataResult<string> Edit(Customer obj)
        {
            try
            {
                if (string.IsNullOrEmpty(obj.Name))
                    return new DataResult<string> { Code = -1, Data = "名称不能为空" };
                if (string.IsNullOrEmpty(obj.CodeName))
                    return new DataResult<string> { Code = -1, Data = "名称代码不能为空" };
                var dbs = base.Get(obj.Id);
                dbs.Name = obj.Name;
                dbs.Remark = obj.Remark;
                dbs.CodeName = obj.CodeName;
                dbs.EditTime = DateTime.Now;
                dbs.Enable = obj.Enable;
                dbs.Link = obj.Link;
                dbs.Sort = obj.Sort;
                dbs.ImgUrl = obj.ImgUrl;
                var res = base.Update(dbs);
                return new DataResult<string> { Code = 0, Data = "修改成功" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "修改失败", ExtData = ex.Message };
            }
        }

        public DataResult<string> Del(Customer obj)
        {
            try
            {
                var res = base.Delete(obj);
                return new DataResult<string> { Code = 0, Data = "删除成功" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "删除失败", ExtData = ex.Message };
            }
        }

    }
}
