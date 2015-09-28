using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.DomainModel.Common
{
    /// <summary>
    /// 响应信息
    /// </summary>
    public class ResponseInfo
    {
        public ResponseInfo()
        {
            this.IsSuccess = false;
            this.Msg = "";
        }

        /// <summary>
        /// 返回结果
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 返回结果描述
        /// </summary>
        public string Msg { get; set; }
    }
}
