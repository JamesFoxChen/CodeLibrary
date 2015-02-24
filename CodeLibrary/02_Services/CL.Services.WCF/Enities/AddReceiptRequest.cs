
using CL.CrossDomain.DomainModel;
namespace CL.Services.WCF
{
    /// <summary>
    ///  新增收货信息接口-请求实体类
    /// </summary>
    /// </summary>
    public class AddReceiptRequest : RequestEntityBase
    {
        /// <summary>
        /// 用户验证串
        /// </summary>
        public virtual string UserStateId { get; set; }

        /// <summary>
        /// 是否为默认值
        /// </summary>
        public virtual string IsFlag { get; set; }

        /// <summary>
        /// 收货省份编号
        /// </summary>
        public virtual string ProvinceId { get; set; }

        /// <summary>
        /// 收货城市编号
        /// </summary>
        public virtual string CityId { get; set; }

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
