using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL.CrossDomain.Utils
{
    public class StringUtil
    {
        /// <summary>
        /// 判断请求数据中必填字段是否有空值
        /// 有：返回true 没有：返回false
        /// </summary>
        /// <param name="data">请求字段</param>
        /// <returns></returns>
        public static bool IsRequestDataEmpty(params string[] data)
        {
            foreach (var item in data)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
