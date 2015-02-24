using System;
using System.Reflection;
using System.ComponentModel;

public static class EnumExtensions
{
    public static T ParseEnum<T>(this string value, bool ignoreCase = false) where T : struct
    {
        T tenum;
        Enum.TryParse<T>(value, ignoreCase, out tenum);
        return tenum;
    }


    //public static string GetDescription(Enum enumerationValue)
    //{
    //    Type type = enumerationValue.GetType();
    //    if (!type.IsEnum)
    //    {
    //        throw new ArgumentException("EnumerationValue必须是一个枚举值", "enumerationValue");
    //    }

    //    //使用反射获取该枚举的成员信息17
    //    MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());

    //    if (memberInfo != null && memberInfo.Length > 0)
    //    {
    //        object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
    //        if (attrs != null && attrs.Length > 0)
    //        {
    //            //返回枚举值得描述信息25 
    //            return ((DescriptionAttribute)attrs[0]).Description;
    //        }
    //    }
    //    return enumerationValue.ToString();
    //}
}

//public enum EnumColor
//{
//     Red = 1,
//     White = 2
//}

//      就可以这样使用：var enumCol = "Red".ParseEnum<EnumColor>(); 返回1
