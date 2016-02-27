using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XBD.Entity;
using XBD.Service;
using XBD.Test.Codes;

namespace XBD.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var svc =new AdminSvc();
            var obj = new Admin
            {
                Name = "admin",
                Pwd = "admin",
                AddTime = DateTime.Now,
                EditTime = DateTime.Now,
                Remark = "Default"
            };
            //svc.Add(obj);

            //var res = svc.Check("admin", "admin1");


            Assert.IsTrue(1==1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var svc = new XBD.Service.NarcoticsSvc();
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "/Files/危险化学品名录统计表2.xls";
            var dt = ExcelTool.ToDataTable(filePath);
            svc.AddAll(dt);

            Assert.IsTrue(1==1);
        }
    }
}
