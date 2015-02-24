
using CL.CrossDomain.DomainModel;
namespace CL.Services.WCF
{
    /// <summary>
    ///  获取收货信息列表接口-请求实体类
    /// </summary>
    /// </summary>
    public class GetReceiptListRequest : RequestEntityPagerBase
    {
        /// <summary>
        /// 用户验证串
        /// </summary>
        public virtual string UserStateId { get; set; }
    }
}
