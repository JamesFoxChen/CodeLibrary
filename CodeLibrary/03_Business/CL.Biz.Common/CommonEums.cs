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


    ///<summary>
    /// 枚举类型--返回结果枚举
    /// -1:无数据或异常
    /// 0:业务数据验证错误
    /// 1:成功
    /// 9:登陆超时
    ///</summary>
    public enum EnumResultId
    {
        /// <summary>
        /// -1:无数据或发生异常
        /// </summary>
        ExceptionOrNoData = -1,
        /// <summary>
        /// 0:业务数据验证错误
        /// </summary>
        VerifyError = 0,
        /// <summary>
        /// 1:成功
        /// </summary>
        Success = 1,
        /// <summary>
        /// 2:错误标识为2
        /// </summary>
        D2 = 2,
        /// <summary>
        /// 3:错误标识为3
        /// </summary>
        D3 = 3,
        /// <summary>
        /// 4:错误标识为4
        /// </summary>
        D4 = 4,
        /// <summary>
        /// 5:错误标识为5
        /// </summary>
        D5 = 5,
        /// <summary>
        /// 6:错误标识为6
        /// </summary>
        D6 = 6,
        /// <summary>
        /// 7:错误标识为7
        /// </summary>
        D7 = 7,
        /// <summary>
        /// 8:错误标识为8
        /// </summary>
        D8 = 8,
        /// <summary>
        /// 9:超时或验证失败
        /// </summary>
        TimeOutOrVerifyFailure = 9
    }

    /// <summary>
    /// 数据库枚举
    /// </summary>
    public enum DataBaseEnum
    {
        [Description("Oracle")]
        Oracle = 1,
        [Description("SqlServer")]
        SqlServer = 2,
        [Description("SqlServer_CE")]
        SqlServerCE = 3
    }
}
