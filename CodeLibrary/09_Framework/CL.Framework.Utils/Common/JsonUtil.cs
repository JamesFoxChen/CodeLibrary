using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Framework.Utils
{
    public class JsonUtil
    {
        /// <summary>
        /// Dictionary转换为json格式字符串并返回
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string GetJson(Dictionary<string, string> dic)
        {
            return JsonConvert.SerializeObject(dic, Formatting.Indented);
        }
    }
}
