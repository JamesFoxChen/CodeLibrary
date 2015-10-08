using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CL.DAL.DataModel.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
     [Serializable]
    public class UserInfo
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public String ID { get; set; }

        /// <summary>
        /// 父级编号
        /// </summary>
        public String ParentID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// 支付密码
        /// </summary>
        public String PayPassword { get; set; }

        /// <summary>
        /// 真实名称
        /// </summary>
        public String TrueName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public String NickName { get; set; }

        /// <summary>
        /// 用户级别
        /// </summary>
        public Int32? UserLevel { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public Int32? UserType { get; set; }

        /// <summary>
        /// 省份编号
        /// </summary>
        public Int32? ProvinceID { get; set; }

        /// <summary>
        /// 城市编号
        /// </summary>
        public Int32? CityID { get; set; }

        /// <summary>
        /// 位置编号
        /// </summary>
        public Int32? LocationID { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public String Addr { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public String Mobile { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Int32? Sex { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public String ZipCode { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public String PhotoUrl { get; set; }

        /// <summary>
        /// 账户状态
        /// </summary>
        public Int32? AccountStatus { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public Double? Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public Double? Latitude { get; set; }

        /// <summary>
        /// 邀请码
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 InviteCode { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// 数据来源
        /// </summary>
        public Int32? DataSource { get; set; }

        /// <summary>
        /// 第三方数据类型
        /// </summary>
        public int? ThirdType { get; set; }

        /// <summary>
        /// 第三方数据账号
        /// </summary>
        public string ThirdUserName { get; set; }
    }
}
