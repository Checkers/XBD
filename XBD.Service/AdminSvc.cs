﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.API;
using Swift.Net.Base;
using XBD.Entity;
using Swift.Net.Share;
namespace XBD.Service
{
    public class AdminSvc : BaseSvc<Admin>
    {

        public PaginationResult<XBD.Entity.Admin> PageList(int page, int size)
        {
            var res = base.GetPageList(page, size);
            return res;
        }

        public DataResult<Admin> GetById(int id)
        {
            try
            {
                var res = base.Get(id);
                return new DataResult<Admin> { Code = 0, Data = res };
            }
            catch (Exception ex)
            {
                return new DataResult<Admin> { Code = -1, ExtData = ex.Message };
            }
        }

        public DataResult<Admin> GetByName(string name)
        {
            try
            {
                var res = base.GetFirst(t => t.Name == name);
                return new DataResult<Admin> { Code = 0, Data = res };
            }
            catch (Exception ex)
            {
                return new DataResult<Admin> { Code = -1, ExtData = ex.Message };
            }
        }

        public DataResult<string> Del(Admin obj)
        {
            try
            {
                if (base.RowsCount() == 1) return new DataResult<string> { Code = -1, Data = "最后一个用户不能删除" };
                base.Delete(obj);
                return new DataResult<string> { Code = 0, Data = "删除成功" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "删除失败", ExtData = ex.Message };
            }
        }


        public DataResult<string> Edit(Admin obj)
        {
            try
            {
                if (string.IsNullOrEmpty(obj.Name))
                    return new DataResult<string> { Code = -1, Data = "用户名不能为空" };

                var en = base.Get(obj.Id);
                en.Name = obj.Name;
                en.Remark = obj.Remark;
                en.Enable = obj.Enable;
                en.EditTime = DateTime.Now;
                base.Update(en);
                return new DataResult<string> { Code = 0, Data = "修改成功" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "修改失败", ExtData = ex.Message };
            }
        }

        public DataResult<string> Add(Admin obj)
        {
            try
            {
                if (string.IsNullOrEmpty(obj.Name))
                    return new DataResult<string> { Code = -1, Data = "用户名不能为空" };
                if (string.IsNullOrEmpty(obj.Pwd))
                    return new DataResult<string> { Code = -1, Data = "密码不能为空" };

                var exist = RowsCount(t => t.Name == obj.Name);
                if (exist > 0) return new DataResult<string> { Code = -1, Data = "管理员名称已经存在" };

                obj.Pwd = obj.Pwd.GetMd5().GetMd5();
                obj.AddTime = DateTime.Now;
                obj.EditTime = DateTime.Now;
                base.Add(obj);
                return new DataResult<string> { Code = 0, Data = "添加成功" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "添加失败", ExtData = ex.Message };
            }
        }

        public DataResult<string> Check(string uname, string pwd)
        {
            try
            {
                if (string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(pwd))
                    return new DataResult<string> { Code = -1, Data = "用户名或密码不能为空" };

                var mdPwd = pwd.GetMd5().GetMd5();
                var admin = GetFirst(t => t.Name == uname && t.Pwd == mdPwd && t.Enable);
                return admin != null ? new DataResult<string> { Code = 0, Data = "操作成功", ExtData = admin } :
                        new DataResult<string> { Code = -1, Data = "用户名或密码错误" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "操作失败", ExtData = ex.Message };
            }
        }



        public DataResult<string> EditPwd(string oldPwd, string newPwd, string confirm, int adminId)
        {
            try
            {
                if (string.IsNullOrEmpty(oldPwd))
                    return new DataResult<string> { Code = -1, Data = "旧密码不能为空" };

                if (string.IsNullOrEmpty(newPwd))
                    return new DataResult<string> { Code = -1, Data = "新密码不能为空" };

                if (newPwd != confirm)
                    return new DataResult<string> { Code = -1, Data = "两次新密码输入不一致" };

                var old = Get(adminId);
                oldPwd = oldPwd.GetMd5().GetMd5();
                if (old.Pwd != oldPwd) return new DataResult<string> { Code = -1, Data = "旧密码不正确" };

                old.EditTime = DateTime.Now;
                old.Pwd = newPwd.GetMd5().GetMd5();

                base.Update(old);
                return new DataResult<string> { Code = 0, Data = "修改成功" };
            }
            catch (Exception ex)
            {
                return new DataResult<string> { Code = -1, Data = "修改失败", ExtData = ex.Message };
            }
        }

    }
}