using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CL.DAL.DataModel.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
     [Serializable]
    public class AdminRightInfo
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key, Column(Order = 1)]
        public String AdminID { get; set; }

        /// <summary>
        /// 父级编号
        /// </summary>
        [Key, Column(Order = 2)]
        public String RightID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Created { get; set; }
    }
}
