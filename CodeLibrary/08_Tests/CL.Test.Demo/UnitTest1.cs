using System;
using CL.Framework.Utils.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CL.Test.Demo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //K94Focwnd2xptYVN6zCnRw==
            var r = AESUtil.AESEncrypt("123");
        }
    }
}
