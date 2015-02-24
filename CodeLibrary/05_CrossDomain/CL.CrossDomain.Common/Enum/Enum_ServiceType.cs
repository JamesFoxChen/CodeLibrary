using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.Common
{
    ///<summary>
    /// 枚举类型--接口名称枚举
    ///</summary>
    public enum Enum_ServiceType
    {
        /// <summary>
        ///获取收货信息列表(33)
        /// </summary>
        GetReceiptList = 33,

        /// <summary>
        /// 新增收货信息(34)
        /// </summary>
        AddReceipt = 34,

        /// <summary>
        /// 修改收货信息(35)
        /// </summary>
        UpdateReceipt = 35,

        /// <summary>
        /// 删除收货信息(36)
        /// </summary>
        DeleteReceipt = 36
    }
}
