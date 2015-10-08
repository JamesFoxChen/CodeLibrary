using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.DAL.DataAccess.Common;
using CL.DAL.DataModel.Entities;

namespace CL.DAL.DataAccess
{
    public class CLDbContext : DbContext
    {
          // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public CLDbContext()
            : base(DBConnection.GetConnectionString())
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//移除复数表名的契约
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();//移除对MetaData表的查询验证，要不然每次都要访问EdmMetadata这个表
        }

        /// <summary>
        /// 管理员信息表
        /// </summary>
        public DbSet<AdminInfo> AdminInfo { get; set; }

        /// <summary>
        /// 管理员权限关系表
        /// </summary>
        public DbSet<AdminRightInfo> AdminRightInfo { get; set; }

        /// <summary>
        /// 后台权限信息表
        /// </summary>
        public DbSet<RightInfo> RightInfo { get; set; }

        /// <summary>
        /// 品牌信息表
        /// </summary>
        public DbSet<BrandInfo> BrandInfo { get; set; }

        /// <summary>
        /// 订单信息表
        /// </summary>
        public DbSet<OrderInfo> OrderInfo { get; set; }

        /// <summary>
        /// 订单产品信息表
        /// </summary>
        public DbSet<OrderProductInfo> OrderProductInfo { get; set; }

        /// <summary>
        /// 产品信息表
        /// </summary>
        public DbSet<ProductInfo> ProductInfo { get; set; }

        /// <summary>
        /// 用户信息表
        /// </summary>
        public DbSet<UserInfo> UserInfo { get; set; }


        /// <summary>
        /// 入口流水信息表
        /// </summary>
        public DbSet<StockInLog> StockInLog { get; set; }
    }
}
