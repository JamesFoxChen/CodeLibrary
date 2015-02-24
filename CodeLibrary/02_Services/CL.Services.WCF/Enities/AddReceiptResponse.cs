using CL.CrossDomain.DomainModel;
using CL.Services.WCF;

namespace CL.Services.WCF
{
    /// <summary>
    /// 新增收货信息接口-响应实体类
    /// </summary>
    public class AddReceiptResponse : ResponseEntityBase
    {
        /// <summary>
        /// 收货地址编号
        /// </summary>
        public virtual string LinkId { get; set; }
    }
}
