using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Plugin.Excel;
using CL.Plugin.KuaiDi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CL.Test.Demo.Thrid.KuaiDi
{
    [TestClass]
    public class KuaiDiTest
    {
        [TestMethod]
        public void 百世汇通()
        {
            var list = KuaidiMng.GetWuli("210892836800", Plugin.KuaiDi.Common.ExpressCompany.百世汇通);
        }
    }
}
