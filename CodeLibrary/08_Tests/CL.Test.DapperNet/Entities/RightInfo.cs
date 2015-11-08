﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Test.DapperNet.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Serializable]
    public class RightInfo
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public String ID { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public String RightName { get; set; }

        /// <summary>
        /// 父节点编号
        /// </summary>
        public String ParentID { get; set; }

        /// <summary>
        /// 菜单连接Url
        /// </summary>
        public String URL { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int? OrderIndex { get; set; }
    }
}
