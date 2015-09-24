using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Biz.Common
{
    /// <summary>
    /// 操作类型
    /// </summary>
    public enum EnumAction
    {
        [Description("新增")]
        Add = 1,
        [Description("修改")]
        Update = 2
    }

    /// <summary>
    /// 是/否
    /// </summary>
    public enum YesNo
    {
        [Description("是")]
        是 = 1,
        [Description("否")]
        否 = 2
    }

    /// <summary>
    /// 是否删除
    /// </summary>
    public enum IsDelete
    {
        [Description("否")]
        否 = 1,
        [Description("是")]
        是 = 2
    }

    /// <summary>
    /// 上下级状态
    /// </summary>
    public enum ShowStatus
    {
        [Description("上架")]
        上架 = 1,
        [Description("下架")]
        下架 = 2
    }

    /// <summary>
    /// 系统类型
    /// </summary>
    public enum SystemType
    {
        [Description("后台")]
        后台 = 1,
        [Description("前端")]
        前端 = 2
    }

    /// <summary>
    /// 是否删除
    /// </summary>
    public enum DataSourceType
    {
        [Description("导入")]
        导入 = 1,
        [Description("移动端")]
        移动端 = 2,
        [Description("PC端")]
        PC端 = 3,
        [Description("后台")]
        后台 = 4
    }

}
