using CL.Plugin.Sms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CL.Test.Demo.Thrid.Sms
{
    [TestClass]
    public class SmsTest
    {
        [TestMethod]
        public void 验证码短信()
        {
            SmSend.SendVerifyCode("13507162783");
        }

        [TestMethod]
        public void 发货短信()
        {
            SmSend.DeliverGoods("", "a123123", "b32321");
        }
    }
}
