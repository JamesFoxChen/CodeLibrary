
namespace CL.CrossDomain.DomainModel
{
    /// <summary>
    /// 翻页请求实体类基类
    /// </summary>
    public class RequestEntityPagerBase : RequestEntityBase
    {
        /// <summary>
        /// 每页显示数量
        /// </summary>
        public virtual string PageSize { get; set; }

        /// <summary>
        /// 当前页数
        /// </summary>
        public virtual string PageIndex { get; set; }

        /// <summary>
        /// 是否获取所有数据
        /// </summary>
        public virtual string IsGetAll { get; set; }
    }
}
