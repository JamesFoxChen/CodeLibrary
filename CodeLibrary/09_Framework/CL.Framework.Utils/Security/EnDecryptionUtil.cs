using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CL.Framework.Utils
{
    public class EnDecryptionUtil
    {
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

        #region DES加解密（C#、C语言通用）
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="pToEncrypt">需加密字符串</param>
        /// <param name="key">秘钥（长度必须为8位）</param>
        /// <param name="padding">必须使用Zeros，使用其他Padding方式加密字符串不是8的倍数会抛异常</param>
        /// <returns></returns>
        public static string EncryptString(string pToEncrypt, string key, string padding)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            if (padding == "None")
            {
                des.Padding = PaddingMode.None;    
            }
            else if (padding == "PKCS7")
            {
                des.Padding = PaddingMode.PKCS7;
            }
            else if (padding == "Zeros")   
            {
                des.Padding = PaddingMode.Zeros;
            }
            else if (padding == "ANSIX923")
            {
                des.Padding = PaddingMode.ANSIX923;
            }
            else if (padding == "ISO10126")
            {
                des.Padding = PaddingMode.ISO10126;
            }
            else
            {
                throw new Exception("必须选择一个padding");
            }
            des.Mode = CipherMode.ECB;

            byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);

            des.Key = UTF8Encoding.UTF8.GetBytes(key.Substring(0, 8));
            des.IV = UTF8Encoding.UTF8.GetBytes(key.Substring(0, 8));
            //des.Key = UTF8Encoding.UTF8.GetBytes(key);
            //des.IV = UTF8Encoding.UTF8.GetBytes(key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }

        /// <summary>
        /// 解密
        /// 使用PaddingMode.Zeros方法，解密时会自动补字符\0，故需要去除末尾该字符
        /// 解密后字符串.TrimEnd('\0')
        /// </summary>
        /// <param name="pToDecrypt"></param>
        /// <param name="key"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public static string DecryptString(string pToDecrypt, string key, string padding)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //des.Padding = PaddingMode.ANSIX923;
            if (padding == "None")
            {
                des.Padding = PaddingMode.None;
            }
            else if (padding == "PKCS7")
            {
                des.Padding = PaddingMode.PKCS7;
            }
            else if (padding == "Zeros")
            {
                des.Padding = PaddingMode.Zeros;
            }
            else if (padding == "ANSIX923")
            {
                des.Padding = PaddingMode.ANSIX923;
            }
            else if (padding == "ISO10126")
            {
                des.Padding = PaddingMode.ISO10126;
            }
            else
            {
                throw new Exception("必须选择一个padding");
            }
            des.Mode = CipherMode.ECB;

            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }
            des.Key = UTF8Encoding.UTF8.GetBytes(key.Substring(0, 8));
            des.IV = UTF8Encoding.UTF8.GetBytes(key.Substring(0, 8));
            //des.Key = UTF8Encoding.UTF8.GetBytes(key);
            //des.IV = UTF8Encoding.UTF8.GetBytes(key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();

            return Encoding.UTF8.GetString(ms.ToArray());
        }
        #endregion
        
        #region 其它
        /// <summary>
        /// 自定义原数组。
        /// </summary>
        private static char[] SOURCE = null;

        /// <summary>
        /// 自定义密文数组。
        /// </summary>
        private static char[] RESULT = null;

        private static void setKeySource()
        {
            string source = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string key = "RbUdaFB4XEC9LIgTDMNPAGZQJSWHYeOx3V52nhwckuy7mqstfvliro1jp06z8K";
            if (string.IsNullOrEmpty(source)
                || string.IsNullOrEmpty(key)
                || source.Length != key.Length)
            {
                throw new Exception("source、key配置信息错误，长度应一致，且不能为空。");
            }
            SOURCE = new char[source.Length];
            RESULT = new char[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                SOURCE[i] = source[i];
                RESULT[i] = key[i];
            }
        }

        /// <summary>
        /// 自定义加密解密。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isEncrypt">加密：true;解密:false</param>
        /// <returns></returns>
        public static string CustomEncrypt(string value, bool isEncrypt)
        {
            setKeySource();

            char[] r = isEncrypt ? RESULT : SOURCE;
            char[] s = !isEncrypt ? RESULT : SOURCE;
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            string result = string.Empty;
            for (int i = 0; i < value.Length; i++)
            {
                bool isExist = false;
                for (int j = 0; j < s.Length; j++)
                {
                    if (value[i] == s[j])
                    {
                        result += r[j];
                        isExist = true;
                        break;
                    }
                }
                if (!isExist)
                {
                    result += value[i];
                }
            }
            return result;
        }

        #region Base64
        private static string encryptKey = "bsc";

        public static string FromBase64(string value)
        {
            byte[] bytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string ToBase64(string value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
        }

        public static string GetDecryptionByBase64(string decryptString)
        {
            if (string.IsNullOrEmpty(decryptString))
            {
                return "";
            }
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] buffer = new byte[decryptString.Length / 2];
            for (int i = 0; i < (decryptString.Length / 2); i++)
            {
                int num2 = Convert.ToInt32(decryptString.Substring(i * 2, 2), 0x10);
                buffer[i] = (byte)num2;
            }
            provider.Key = Encoding.ASCII.GetBytes(encryptKey);
            provider.IV = Encoding.ASCII.GetBytes(encryptKey);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            StringBuilder builder = new StringBuilder();
            return Encoding.Default.GetString(stream.ToArray());
        }

        public static string GetDecryptionByBase64(string decryptString, string key)
        {
            encryptKey = key;
            return GetDecryptionByBase64(decryptString);
        }

        public static string GetEncryptionByBase64(string encryptString)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(encryptString);
            provider.Key = Encoding.ASCII.GetBytes(encryptKey);
            provider.IV = Encoding.ASCII.GetBytes(encryptKey);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            StringBuilder builder = new StringBuilder();
            foreach (byte num in stream.ToArray())
            {
                builder.AppendFormat("{0:X2}", num);
            }
            builder.ToString();
            return builder.ToString();
        }

        public static string GetEncryptionByBase64(string encryptString, string key)
        {
            encryptKey = key;
            return GetEncryptionByBase64(encryptString);
        }
        #endregion
        #endregion
    }
}
