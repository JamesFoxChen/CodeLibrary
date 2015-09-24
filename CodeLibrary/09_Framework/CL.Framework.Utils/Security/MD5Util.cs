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
            byte[] fromData = Encoding.UTF8.GetBytes(origin);
            byte[] targetData = md5.ComputeHash(fromData);
            return Convert.ToBase64String(targetData);
        }


        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="source">原内容</param>
        /// <returns>加密后内容</returns>
        public static string GetMd52(string source)
        {
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(source));

            // Create a new Stringbuilder to collect the bytes and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        #region MD5加密，加密结果在.Net、Java、IOS通用
        /// <summary>
        /// MD5加密，加密结果在.Net、Java、IOS通用
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMd5Str(string str)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }
        #endregion

    }
}
