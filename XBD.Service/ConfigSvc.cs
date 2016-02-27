using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.Base;
using Swift.Net.API;
using XBD.Entity;
using Newtonsoft.Json;

namespace XBD.Service
{
    public class ConfigSvc : BaseSvc<Config>
    {
        /// <summary>
        /// 获取网站配置信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsExist(string codeName)
        {
            var ret = base.RowsCount(t=>t.CodeName==codeName);
            return ret>0;
        }

        public ConfigInfo GetByCode(string name)
        {
            var ret = base.GetFirst(t => t.CodeName == name);
            if (ret == null) return new ConfigInfo();
            var obj = JsonConvert.DeserializeObject<ConfigInfo>(ret.Value);
            obj.CodeName = ret.Name;
            obj.Descript = ret.Remark;
            return obj;
        }

        public DataResult<string> AddOrEdit(ConfigInfo obj)
        {
            if (string.IsNullOrEmpty(obj.CodeName))
                return new DataResult<string> { Code = -1, Data = "网站名称不能为空" };

            var model = new Config
            {
                Id = obj.id,
                Name = obj.CodeName,
                CodeName = obj.CodeName,
                Value = JsonConvert.SerializeObject(obj),
                Remark = obj.Descript
            };

            return IsExist(obj.CodeName) ? Eidt(model) : Add(model);

        }

        /// <summary>
        /// 新增网站配置
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public DataResult<string> Add(Config obj)
        {
            try
            {
                obj.AddTime = DateTime.Now;
                var ret = base.Add(obj);
                return ret >= 0 ?
                    new DataResult<string> { Code = 0, Data = "保存成功！" }
                    : new DataResult<string> { Code = -1, Data = "保存失败！" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "保存失败！", ExtData = ex.Message };
            }
        }
        /// <summary>
        /// 修改网站配置
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public DataResult<string> Eidt(Config obj)
        {
            try
            {
                var dbs = base.GetFirst(t => t.CodeName == obj.CodeName);
                dbs.EditTime = DateTime.Now;
                dbs.Remark = obj.Remark;
                dbs.Value = obj.Value;
                var ret = base.Update(dbs);

                return ret >= 0 ?
                     new DataResult<string> { Code = 0, Data = "保存成功！" }
                     : new DataResult<string> { Code = -1, Data = "保存失败！" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "保存失败！", ExtData = ex.Message };
            }

        }
    }
}
