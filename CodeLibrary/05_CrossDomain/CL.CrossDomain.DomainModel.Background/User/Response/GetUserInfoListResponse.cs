using System;
using System.Collections.Generic;

namespace CL.CrossDomain.DomainModel.Background.User.Request
{
    public class GetUserInfoListResponse 
    {
        public List<GetUserInfoResponse> DataList { get; set; }

        public int  TotalCount { get; set; }
    }


    public class GetUserInfoResponse
    {
        /// <summary>
        /// 主键ID
        /// </summary>
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
        /// 真实名称
        /// </summary>
        public String TrueName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public String NickName { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public Int32? UserType { get; set; }

        /// <summary>
        /// 用户类型描述
        /// </summary>
        public string UserTypeDesc { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public String Addr { get; set; }

          /// <summary>
        /// 手机号码
        /// </summary>
        public String Mobile { get; set; }

        /// <summary>
        /// 账户状态
        /// </summary>
        public Int32? AccountStatus { get; set; }
        /// <summary>
        /// 账户状态
        /// </summary>
        public string AccountStatusDesc { get; set; }

        /// <summary>
        /// 数据来源编号
        /// </summary>
        public int? DataSource { get; set; }

        /// <summary>
        /// 数据来源描述
        /// </summary>
        public string DataSourceDesc { get; set; }

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
