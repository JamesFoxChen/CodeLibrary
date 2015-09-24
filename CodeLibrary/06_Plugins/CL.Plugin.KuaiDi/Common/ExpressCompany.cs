using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Plugin.KuaiDi.Common
{
    /// <summary>
    /// 快递公司
    /// </summary>
    public enum ExpressCompany
    {
        [Description("顺丰")]
        顺丰 = 1,
        [Description("百世汇通")]
        百世汇通 = 2
    }
}
