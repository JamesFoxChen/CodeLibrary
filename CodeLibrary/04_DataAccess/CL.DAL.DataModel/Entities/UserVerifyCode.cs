using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.DAL.DataModel.Entities
{
    /// <summary>
    /// 短信验证码表
    /// </summary>
    public class SmsVerifyCode
    {

        /// <summary>
        /// 编号
        /// </summary>
        [Key]
        public String ID { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public String Mobile { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// 是否验证
        /// </summary>
        public Int32? IsVeify { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Remark { get; set; }

    }
}
