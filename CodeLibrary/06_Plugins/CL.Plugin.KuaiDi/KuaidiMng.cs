using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Framework.Utils;
using CL.Plugin.KuaiDi.Common;

namespace CL.Plugin.KuaiDi
{
    public static class KuaidiMng
    {
        /// <summary>
        /// 获取物流信息
        /// </summary>
        /// <param name="mailNo"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public static List<KuaidiResponse> GetWuli(string mailNo, ExpressCompany company)
        {
            var list = new List<KuaidiResponse>();
            try
            {
                if (company == ExpressCompany.百世汇通)
                {
                    list = Baishihuitong.GetWuliu(mailNo);
                }
            }
            catch (Exception ex)
            {
                TextLoggingService.ErrorWithException("获取物流信息(GetWuli)\r\nMsg：" + ex.Message + "\r\nStack：" + ex.StackTrace, ex);
            }

            return list;
        }
    }
}
