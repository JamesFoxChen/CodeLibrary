using CL.CrossDomain.DomainModel;
using System.Collections.Generic;

namespace CL.Services.WCF
{
    /// <summary>
    /// 获取收货信息列表接口-响应实体类
    /// </summary>
    public class GetReceiptListResponse : ResponseEntityBase
    {
        public virtual IList<GetReceiptListDataResponse> Data { get; set; }
    }


    /// <summary>
    /// 获取收货信息列表接口-响应数据实体类
    /// </summary>
    public class GetReceiptListDataResponse
    {
        /// <summary>
        /// 收货地址编号
        /// </summary>
        public virtual string LinkId { get; set; }

        /// <summary>
        /// 是否为默认值
        /// </summary>
        public virtual string IsFlag { get; set; }

        /// <summary>
        /// 收货城区编号
        /// </summary>
        public virtual string RegionId { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        public virtual string LinkAddress { get; set; }

        /// <summary>
        /// 收货联系人
        /// </summary>
        public virtual string LinkMan { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public virtual string LinkPost { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public virtual string LinkMobile { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public virtual string LinkTel { get; set; }
    }
}
