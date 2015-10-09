using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Plugin.Qiniu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CL.Plugin.RedisPlugin;

namespace CL.Test.Demo.Thrid.Redis
{
    [TestClass]
    public class RedisTest
    {
        [TestMethod]
        public void 基础测试()
        {
            RedisBase.Item_Set<string>("a123", DateTime.Now.ToString());
            var value = RedisBase.Item_Get<string>("aa");
        }
    }
}
