﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CL.Test.DapperNet.Entities
{
    [Serializable]
    [Table("Test1")]
    public class Test1
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int ID { get; set; }

   
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Created { get; set; }

    }
}

