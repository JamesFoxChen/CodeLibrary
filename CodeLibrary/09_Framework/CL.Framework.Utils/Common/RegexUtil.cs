using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CL.Framework.Utils
{
    /// <summary>
    /// 正则表达式工具类
    /// </summary>
    public class RegexUtil
    {
        #region 方法

        /// <summary>
        ///  验证数字格式
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsDigit(string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }

        /// <summary>
        /// 验证电子邮件格式
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsEmail(string input)
        {
            return Regex.IsMatch(input, @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
        }

        /// <summary>
        /// 验证手机格式
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsMobile(string input)
        {
            return Regex.IsMatch(input, @"^1[358]\d{9}$");
        }

        /// <summary>
        /// 验证登录名格式(字母开头，只包含数字和字母，4-20位)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsLoginName(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]{1}([a-zA-Z0-9]){3,19}$");
        }

        /// <summary>
        /// 验证邮政编码格式
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsPostCode(string input)
        {
            return Regex.IsMatch(input, @"^\d{6}$");
        }

        /// <summary>
        /// 验证传真号码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsFax(string input)
        {
            return Regex.IsMatch(input, @"86-\d{2,3}-\d{7,8}");
        }

        /// <summary>
        ///  验证中文
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsChinese(string input)
        {
            char[] char_s = input.ToCharArray();
            for (int i = 0; i < char_s.Length; i++)
            {
                Regex rx = new Regex("^[\u4e00-\u9fa5]$");
                if (rx.IsMatch(char_s[i].ToString()))
                {
                    continue;
                }
                else { return false; }
            }
            return true;
        }

        /// <summary>
        /// 验证网址
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsWebAddress(string input)
        {
            return Regex.IsMatch(input, @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        }

        /// <summary>
        /// 验证图片
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsPicture(string input)
        {
            return Regex.IsMatch(input, @"\.(?i:gif|jpg|png|bmp|ico)$");
        }

        /// <summary>
        /// 验证电话
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        public static bool IsTelephone(string input)
        {
            bool bl = false; ;
            //验证电话
            //电话号码规则：
            //区号：3或者4位 
            //主号码：7或者8位
            //Reg = @"^((\(\d{3}\)|\d{3}-|\s)?\d{8})$";

            //加强版本的电话号码验证---支持非北京地区用户
            string Reg = @"^((\(\d{3}\)|\d{3}-|\d{3}|\(\d{4}\)|\d{4}-|\d{4}|\s)?(\d{8}|\d{7}))$";
            if (input != "")
            {
                if (Regex.IsMatch(input, Reg))
                {
                    bl = true;
                }
                else
                {
                    bl = false;
                }
            }
            else
            {
                bl = true;
            }
            return bl;
        }

        /// <summary>
        /// 验证数值类型（包含小数）
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsNum(string input)
        {
            return !Regex.IsMatch(input, "[^\\d.]");
        }

        /// <summary>
        /// 验证数值类型[整数]
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsNum_Int(string input)
        {
            return (Regex.IsMatch(input, "^-?\\d+$"));
        }


        /// <summary>
        /// 验证数值类型[正整数]
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsNum_UnsignedInt(string input)
        {
            if (Regex.IsMatch(input, "^((\\+|-)\\d)?\\d*$"))
            {
                if (int.Parse(input) > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 验证数值类型[小数]
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsDecimal(string input)
        {
            return Regex.IsMatch(input, @"[0].\d{1,2}|[1]");
        }

        /// <summary>
        /// 验证数值类型[float|double]
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsFloat(string input)
        {
            if (false == Regex.IsMatch(input, "^(?:\\+|-)?\\d+(?:\\.\\d+)?$"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 验证数值类型[正符点数]
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsUFloat(string input)
        {
            if (false == Regex.IsMatch(input, "^(?:\\+|-)?\\d+(?:\\.\\d+)?$"))
            {
                return false;
            }
            else
            {
                return (Convert.ToSingle(input) < 0) ? false : true;
            }
        }
        #endregion
    }
    
    public static class ValidatorUtils
	{
		public static bool IsEmail(string source)
		{
			return Regex.IsMatch(source, "^[A-Za-z0-9](([_\\.\\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\\.\\-]?[a-zA-Z0-9]+)*)\\.([A-Za-z]{2,})$", RegexOptions.IgnoreCase);
		}
		public static bool HasEmail(string source)
		{
			return Regex.IsMatch(source, "[A-Za-z0-9](([_\\.\\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\\.\\-]?[a-zA-Z0-9]+)*)\\.([A-Za-z]{2,})", RegexOptions.IgnoreCase);
		}
		public static bool IsUrl(string source)
		{
			return Regex.IsMatch(source, "^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)|(www\\.))+(([a-zA-Z0-9\\._-]+\\.[a-zA-Z]{2,6})|([0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}))(/[a-zA-Z0-9\\&amp;%_\\./-~-]*)?$", RegexOptions.IgnoreCase);
		}
		public static bool HasUrl(string source)
		{
			return Regex.IsMatch(source, "(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)|(www\\.))+(([a-zA-Z0-9\\._-]+\\.[a-zA-Z]{2,6})|([0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}))(/[a-zA-Z0-9\\&amp;%_\\./-~-]*)?", RegexOptions.IgnoreCase);
		}
		public static bool IsDateTime(string source)
		{
			bool result = false;
			DateTime dateTime = default(DateTime);
			if (DateTime.TryParse(source, out dateTime))
			{
				result = true;
			}
			return result;
		}
		public static bool IsMobile(string source)
		{
			return Regex.IsMatch(source, "^1[35]\\d{9}$", RegexOptions.IgnoreCase);
		}
		public static bool HasMobile(string source)
		{
			return Regex.IsMatch(source, "1[35]\\d{9}", RegexOptions.IgnoreCase);
		}
		public static bool IsIP(string source)
		{
			return Regex.IsMatch(source, "^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$", RegexOptions.IgnoreCase);
		}
		public static bool HasIP(string source)
		{
			return Regex.IsMatch(source, "(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])", RegexOptions.IgnoreCase);
		}
		public static bool IsIDCard(string Id)
		{
			if (Id.Length == 18)
			{
				return ValidatorUtils.IsIDCard18(Id);
			}
			return Id.Length == 15 && ValidatorUtils.IsIDCard15(Id);
		}
		public static bool IsIDCard18(string Id)
		{
			long num = 0L;
			if (!long.TryParse(Id.Remove(17), out num) || (double)num < Math.Pow(10.0, 16.0) || !long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out num))
			{
				return false;
			}
			string text = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
			if (text.IndexOf(Id.Remove(2)) == -1)
			{
				return false;
			}
			string s = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
			DateTime dateTime = default(DateTime);
			if (!DateTime.TryParse(s, out dateTime))
			{
				return false;
			}
			string[] array = "1,0,x,9,8,7,6,5,4,3,2".Split(new char[]
			{
				','
			});
			string[] array2 = "7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2".Split(new char[]
			{
				','
			});
			char[] array3 = Id.Remove(17).ToCharArray();
			int num2 = 0;
			for (int i = 0; i < 17; i++)
			{
				num2 += int.Parse(array2[i]) * int.Parse(array3[i].ToString());
			}
			int num3 = -1;
			Math.DivRem(num2, 11, out num3);
			return !(array[num3] != Id.Substring(17, 1).ToLower());
		}
		public static bool IsIDCard15(string Id)
		{
			long num = 0L;
			if (!long.TryParse(Id, out num) || (double)num < Math.Pow(10.0, 14.0))
			{
				return false;
			}
			string text = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
			if (text.IndexOf(Id.Remove(2)) == -1)
			{
				return false;
			}
			string s = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
			DateTime dateTime = default(DateTime);
			return DateTime.TryParse(s, out dateTime);
		}
		public static bool IsInt(string source)
		{
			Regex regex = new Regex("^(-){0,1}\\d+$");
			return regex.Match(source).Success && long.Parse(source) <= 2147483647L && long.Parse(source) >= -2147483648L;
		}
		public static bool IsDecimal(string source)
		{
			Regex regex = new Regex("[0].\\d{1,2}|[1]");
			return regex.Match(source).Success && long.Parse(source) <= 2147483647L && long.Parse(source) >= -2147483648L;
		}
		public static bool IsLengthStr(string source, int begin, int end)
		{
			int length = Regex.Replace(source, "[^\\x00-\\xff]", "OK").Length;
			return length > begin || length < end;
		}
		public static bool IsTel(string source)
		{
			return Regex.IsMatch(source, "^\\d{3,4}-?\\d{6,8}$", RegexOptions.IgnoreCase);
		}
		public static bool IsPostCode(string source)
		{
			return Regex.IsMatch(source, "^\\d{6}$", RegexOptions.IgnoreCase);
		}
		public static bool IsChinese(string source)
		{
			return Regex.IsMatch(source, "^[\\u4e00-\\u9fa5]+$", RegexOptions.IgnoreCase);
		}
		public static bool hasChinese(string source)
		{
			return Regex.IsMatch(source, "[\\u4e00-\\u9fa5]+", RegexOptions.IgnoreCase);
		}
		public static bool IsNormalChar(string source)
		{
			return Regex.IsMatch(source, "[\\w\\d_]+", RegexOptions.IgnoreCase);
		}
	}
}
