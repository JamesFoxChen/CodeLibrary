using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Biz.Common
{
    /// <summary>
    /// 用户账户状态
    /// </summary>
    public enum UserAccountStatus
    {
        [Description("正常")]
        正常 = 1,
        [Description("冻结")]
        冻结 = 2
    }

    /// <summary>
    /// 用户类型
    /// </summary>
    public enum UserType
    {
        [Description("代理商")]
        代理商 = 1,
        [Description("批发商")]
        批发商 = 2
    }

    /// <summary>
    /// 移动端图片展示类型
    /// </summary>
    public enum MPollImageType
    {
        [Description("首页")]
        首页 = 0,
        [Description("食品馆")]
        食品馆 = 1,
        [Description("图书馆")]
        图书馆 = 2,
        [Description("旅游馆")]
        旅游馆 = 3
    }
}
