using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Biz.Common
{
    public class UtilityBiz
    {
        /// <summary>
        /// 生成唯一编号
        /// </summary>
        private static object lockObj = new object();

        /// <summary>
        /// 生成商品DisplayID
        /// </summary>
        /// <returns></returns>
        public static string GenerateProductDisplayID()
        {
            lock (lockObj)
            {
                return DateTime.Now.ToString("yyMMddHHmmssfff");
            }
        }

        /// <summary>
        /// 生成订单DisplayID
        /// </summary>
        /// <returns></returns>
        public static string GenerateOrderDisplayID()
        {
            lock (lockObj)
            {
                return DateTime.Now.ToString("yyMMddHHmmssfff");
            }
        }

        /// <summary>
        /// 生成邀请码
        /// </summary>
        /// <returns></returns>
        public static string GenerateInviteCode(string mobile = "")
        {
            lock (lockObj)
            {
                return DateTime.Now.ToString("yyMMddHHmmssfff");
            }
        }

        /// <summary>
        /// 获取用户默认图片地址
        /// </summary>
        /// <returns></returns>
        public static string GetRegisterUserLogoImage()
        {
            return "DefaultAvatar.jpg";
        }

        /// <summary>
        /// 获取计算的运费
        /// </summary>
        /// <param name="weight">重量</param>
        /// <param name="districtId">地区编号</param>
        /// <returns></returns>
        public static int GetPostage(int weight, string districtId)
        {
            if (weight == 0)
            {
                return 0;
            }
            if (string.IsNullOrWhiteSpace(districtId))
            {
                return 0;
            }
            //浙江330000,上海310000,江苏320000,安徽340000
            //北京110000,广东440000,福建350000,山东370000//河南410000,河北130000,湖南430000,湖北420000,江西360000,天津120000
            //广西450000,山西140000,陕西610000
            //重庆500000,云南530000,贵州520000//四川510000,辽宁210000,吉林220000,黑龙江230000
            //内蒙古150000,青海630000,甘肃620000,宁夏640000,海南460000
            //新疆650000//西藏540000
            //----------香港
            int weightkg = weight / 1000;
            int kgyue = weight % 1000;
            if (kgyue > 0) //取余重量大于0，则多算一公斤
            {
                weightkg++;
            }
            //重量小于1000克时，以1公斤计算运费
            if (weight < 1000)
            {
                weightkg = 1;
            }

            if (districtId == "330000" || districtId == "310000" || districtId == "320000" || districtId == "340000")
            {
                return 4 + (weightkg - 1) * 1; //首重1KG 4元  超出1KG 1元
            }
            if (districtId == "110000" || districtId == "440000" || districtId == "350000" || districtId == "370000" ||
                districtId == "410000" || districtId == "130000" || districtId == "430000" || districtId == "420000" ||
                districtId == "360000" || districtId == "120000")
            {
                return 6 + (weightkg - 1) * 3; //首重1KG 6元  超出1KG 3元
            }
            if (districtId == "450000" || districtId == "140000" || districtId == "610000")
            {
                return 8 + (weightkg - 1) * 5; //首重1KG 8元  超出1KG 5元
            }
            if (districtId == "500000" || districtId == "530000" || districtId == "520000" || districtId == "510000" ||
                districtId == "210000" || districtId == "220000" || districtId == "230000")
            {
                return 8 + (weightkg - 1) * 6; //首重1KG 8元  超出1KG 6元
            }
            if (districtId == "150000" || districtId == "630000" || districtId == "620000" || districtId == "640000" ||
                districtId == "460000")
            {
                return 9 + (weightkg - 1) * 6; //首重1KG 9元  超出1KG 6元
            }
            if (districtId == "650000" || districtId == "540000")
            {
                return 10 + (weightkg - 1) * 8; //首重1KG 10元  超出1KG 8元
            }
            return 0;
        }
    }
}
