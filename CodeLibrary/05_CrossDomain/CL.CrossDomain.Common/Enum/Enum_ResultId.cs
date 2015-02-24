using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.Common
{
    ///<summary>
    /// 枚举类型--返回结果枚举
    /// -1:无数据或异常
    /// 0:业务数据验证错误
    /// 1:成功
    /// 9:登陆超时
    ///</summary>
    public enum Enum_ResultId
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
}
