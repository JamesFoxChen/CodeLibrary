using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Biz.Common
{
     /// <summary>
    /// 根据编码获取名称
    /// </summary>
    public static class CodeValueUtil
    {
        /// <summary>
        /// 删除状态描述
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetIsDeleteDesc(int? key)
        {
            return getValueCommon(key, IsDelete.否);
        }

        /// <summary>
        /// 上下级状态描述
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetShowStatusDesc(int? key)
        {
            return getValueCommon(key, ShowStatus.上架);
        }

        /// <summary>
        /// 是否状态描述
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetYesNoDesc(int? key)
        {
            return getValueCommon(key, YesNo.是);
        }


        /// <summary>
        /// 订单完成状态描述
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetOrderCompleteStatusDesc(int? key)
        {
            return getValueCommon(key, YesNo.是);
        }

        /// <summary>
        /// 获取用户类型
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetUserType(int? key)
        {
            string value = "";
            if (key == null) return value;
            switch (key)
            {
                case 1:
                    value = "代理商";
                    break;
                case 2:
                    value = "批发商";
                    break;
            }
            return value;
        }

   
        /// <summary>
        /// 数据来源描述
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetDataSourceTypeDesc(int? key)
        {
            return getValueCommon(key, DataSourceType.移动端);
        }

        /// <summary>
        /// 用户状态描述
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetUserAccountStatusDesc(int? key)
        {
            string value = "";
            if (key == null) return value;
            switch (key)
            {
                case 1:
                    value = "正常";
                    break;
                case 2:
                    value = "冻结";
                    break;
            }
            return value;
        }
        #region 公共
        private static string getValueCommon(int? key,Enum enumValue)
        {
            string value = "";
            if (key == null) return value;

            var dic = enumValue.GetEumKeyValue();
            if (!dic.ContainsKey(key.Value.ToString())) return "";

            return dic[key.Value.ToString()];
        }
        #endregion
    }
}
