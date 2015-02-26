using System;
using System.Reflection;
using System.ComponentModel;

public static class EnumExtensions
{
    //just test
    
    /// <summary>
    /// 获取枚举值的描述信息
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string GetDescription(this Enum obj)
    {
        FieldInfo fielInfo = obj.GetType().GetField(obj.ToString());
        if (fielInfo == null) return "";

        object[] attrs = fielInfo.GetCustomAttributes(true);
        if (attrs.Length <= 0)
        {
            return string.Empty;
        }

        DescriptionAttribute desAttr = attrs[0] as DescriptionAttribute;
        return desAttr.Description;

        //Type type = obj.GetType();
        //if (!type.IsEnum)
        //{
        //    throw new ArgumentException("obj必须是一个枚举值", "objobj");
        //}

        ////使用反射获取该枚举的成员信息
        //MemberInfo[] memberInfo = obj.GetType().GetMember(obj.ToString());

        //if (memberInfo != null && memberInfo.Length > 0)
        //{
        //    object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        //    if (attrs != null && attrs.Length > 0)
        //    {
        //        //返回枚举值得描述信息 
        //        return ((DescriptionAttribute)attrs[0]).Description;
        //    }
        //}
        //return obj.ToString();
    }

    ///// <summary>
    ///// 获取指定枚举的Description信息
    ///// </summary>
    ///// <param name="e">枚举值(T为枚举类型；e为枚举值）</param>
    ///// <returns>获取成功返回描述；获取失败返回空字符串</returns>
    //public static string GetEnumDescription<T>(T e)
    //{
    //    FieldInfo fielInfo = e.GetType().GetField(e.ToString());
    //    if (fielInfo == null) return "";

    //    object[] attrs = fielInfo.GetCustomAttributes(true);
    //    if (attrs.Length <= 0)
    //    {
    //        return string.Empty;
    //    }

    //    DescriptionAttribute desAttr = attrs[0] as DescriptionAttribute;
    //    return desAttr.Description;
    //}
}

