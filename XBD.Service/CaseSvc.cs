using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.Base;
using XBD.Entity;
using Swift.Net.API;
using XBD.Repository;
using XBD.Entity.DTO;

namespace XBD.Service
{
    public class CaseSvc : BaseSvc<Case>
    {
        CaseResp resp = new CaseResp();
        public PaginationResult<CaseDTO> PageList(int page, int size, string webType)
        {
            var res = resp.GetList(page, size, webType);
            return res;
        }

        public DataResult<Case> GetById(int id)
        {
            try
            {
                var res = base.Get(id);
                return new DataResult<Case> { Code = 0, Data = res };
            }
            catch (Exception ex)
            {
                return new DataResult<Case> { Code = -1, ExtData = ex.Message };
            }
        }

        public DataResult<string> Add(Case cate)
        {
            try
            {
                if (string.IsNullOrEmpty(cate.Name))
                    return new DataResult<string> { Code = -1, Data = "名称不能为空" };
                if (string.IsNullOrEmpty(cate.CodeName))
                    return new DataResult<string> { Code = -1, Data = "名称代码不能为空" };
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

        public DataResult<string> Edit(Case obj)
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
                dbs.ImgUrl = obj.ImgUrl;
                dbs.Sort = obj.Sort;
                dbs.CustomerId = obj.CustomerId;
                var res = base.Update(dbs);
                return new DataResult<string> { Code = 0, Data = "修改成功" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "修改失败", ExtData = ex.Message };
            }
        }

        public DataResult<string> Del(Case cate)
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

        public DataResult<CaseDTO> GetNext(int id, string webType)
        {
            try
            {
                var res = resp.GetNext(id, webType);
                return res != null ? new DataResult<CaseDTO> { Code = 0, Data = res } :
                    new DataResult<CaseDTO> { Code = -1, ErrMsg = "最后一张了" };
            }
            catch (Exception ex)
            {
                return new DataResult<CaseDTO> { Code = -1, ErrMsg = "获取失败", ExtData = ex.Message };
            }
        }

        public DataResult<CaseDTO> GetPrve(int id, string webType)
        {
            try
            {
                var res = resp.GetPrve(id, webType);
                return res != null ? new DataResult<CaseDTO> { Code = 0, Data = res } :
                    new DataResult<CaseDTO> { Code = -1, ErrMsg = "前面没有了" };
            }
            catch (Exception ex)
            {
                return new DataResult<CaseDTO> { Code = -1, ErrMsg = "获取失败", ExtData = ex.Message };
            }
        }

        public DataResult<List<CaseDTO>> GetCidList(int cid)
        {
            try
            {
                var res = resp.GetCidList(cid);
                return res != null ? new DataResult<List<CaseDTO>> { Code = 0, Data = res } :
                    new DataResult<List<CaseDTO>> { Code = -1, ErrMsg = "没有案例" };
            }
            catch (Exception ex)
            {
                return new DataResult<List<CaseDTO>> { Code = -1, ErrMsg = "获取失败", ExtData = ex.Message };
            }
        }


    }
}
