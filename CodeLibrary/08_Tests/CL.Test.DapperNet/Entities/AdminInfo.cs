using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CL.Test.DapperNet.Entities
{
    /// <summary>
    /// 管理员信息表
    /// </summary>
    [Serializable]
    [Table("AdminInfo")]
    public class AdminInfo
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public String ID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public String AdminName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        public Int32? IsSystem { get; set; }

        /// <summary>
        /// 账号状态
        /// </summary>
        public Int32? AccountStatus { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? Updated { get; set; }
    }
}

