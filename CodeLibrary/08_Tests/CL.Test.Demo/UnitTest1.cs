using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CL.Test.Demo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string a = "21";
            Assert.AreEqual("211", a);
        }
    }
}
