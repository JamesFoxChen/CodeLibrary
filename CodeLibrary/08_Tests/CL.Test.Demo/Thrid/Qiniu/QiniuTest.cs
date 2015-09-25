using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Plugin.Qiniu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CL.Test.Demo.Thrid.Qiniu
{
    [TestClass]
    public class QiniuTest
    {
        [TestMethod]
        public void 上传图片()
        {
            var result = QiniuImageMng.UploadImage(@"C:\Users\Public\Pictures\Sample Pictures\1111.jpg");
        }
    }
}
