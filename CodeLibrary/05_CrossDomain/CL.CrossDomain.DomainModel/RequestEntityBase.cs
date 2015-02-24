using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.DomainModel
{
    /// <summary>
    /// 请求实体类基类
    /// </summary>
    public class RequestEntityBase : EntityBase
    {
        /// <summary>
        /// 企业编号
        /// </summary>
        public virtual string CID { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public virtual string Position { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public virtual string PhoneNum { get; set; }

        /// <summary>
        /// mac地址
        /// </summary>
        public virtual string Mac { get; set; }

        /// <summary>
        /// imei号
        /// </summary>
        public virtual string IMEI { get; set; }

        /// <summary>
        /// 手机类型
        /// </summary>
        public virtual string PhoneType { get; set; }

        /// <summary>
        /// 应用程序类型
        /// </summary>
        public virtual string AppType { get; set; }
    }
}
