
namespace CL.CrossDomain.DomainModel
{
    /// <summary>
    /// 数据库实体类基类
    /// </summary>
    public class DbEntityBase : EntityBase
    {
        public DbEntityBase()
        {
            this.ErrMsg = null;
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        public virtual string ErrMsg { get; set; }
    }
}
