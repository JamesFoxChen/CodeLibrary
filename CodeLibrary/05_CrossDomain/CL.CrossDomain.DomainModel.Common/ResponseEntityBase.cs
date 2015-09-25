using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.DomainModel.Common
{
    /// <summary>
    /// 响应实体类基类
    /// </summary>
    public class ResponseEntityBase : EntityBase
    {
        /// <summary>
        /// 返回结果编号
        /// </summary>
        public virtual string ResultId { get; set; }

        /// <summary>
        /// 返回结果描述
        /// </summary>
        public virtual string ResultMsg { get; set; }
    }
}
