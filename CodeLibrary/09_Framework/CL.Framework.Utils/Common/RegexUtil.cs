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
}
