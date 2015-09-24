using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CL.Framework.Utils.Security
{
    public class MD5Util
    {
        public static string GetMd5(string origin)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.UTF8.GetBytes(origin);
            byte[] targetData = md5.ComputeHash(fromData);
            return Convert.ToBase64String(targetData);
        }
    }
}
