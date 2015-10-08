using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Biz.Background.Other
{
    public class DataTypeConvertBiz
    {
        /// <summary>
        /// 将数据库类型转换为.Net类型
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="length"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static string ConvertType(string dataType, string length, string scale)
        {
            //if (StaticBizUtil.DBType == 1)
            //{
            //    return ConvertTypeOracle(dataType, length, scale);
            //}
            //else if (StaticBizUtil.DBType == 2)
            //{
                return ConvertType2008SqlServer(dataType, length, scale);
            //}
            return "";
        }

        /// <summary>
        /// 将数据库字段类型转换为.Net类型(Oracle)
        /// </summary>
        /// <param name="dataType">DataBase Field Type</param>
        /// <param name="tempLength"> </param>
        /// <param name="tempScale"> </param>
        /// <returns></returns>
        private static string ConvertTypeOracle(string dataType, string tempLength, string tempScale)
        {
            string type = dataType.ToUpper();
            string ret = "string";

            if (type == "NVARCHAR2" || type == "VARCHAR2" || type == "CHAR")
            {
                ret = "string";
            }
            else if (type == "NUMBER" || type == "NUMERIC")
            {
                int length = 11;
                if (tempLength != string.Empty)
                {
                    length = Convert.ToInt32(tempLength);
                }
                int scale = 11;
                if (tempLength != string.Empty)
                {
                    scale = Convert.ToInt32(tempScale);
                }
                if (scale > 0)
                {
                    ret = "decimal?";
                }
                else if (length <= 10)
                {
                    ret = "int?";
                }
                else
                {
                    ret = "long?";
                }
            }
            else if (type == "DATE")
            {
                ret = "DateTime?";
            }

            return ret;
        }

        /// <summary>
        /// 将数据库字段类型转换为.Net类型(SqlServer)
        /// </summary>
        /// <param name="dbtype">DataBase Field Type</param>
        /// <param name="tempLength"> </param>
        /// <param name="tempScale"> </param>
        /// <returns></returns>
        private static string ConvertType2008SqlServer(string dbtype, string tempLength, string tempScale)
        {
            string type = dbtype.ToUpper();
            string ret = "string";

            if (type == "NVARCHAR" || type == "VARCHAR" || type == "CHAR" || type == "NTEXT")
            {
                ret = "string";
            }
            else if (type == "INT" || type == "smallint".ToUpper() || type == "UnitPrice".ToUpper() || type == "Discount".ToUpper())
            {
                int length = Convert.ToInt32(tempLength);
                int scale = Convert.ToInt32(tempScale);
                if (scale > 0)
                {
                    ret = "decimal?";
                }
                else if (length <= 10)
                {
                    ret = "int?";
                }
                else
                {
                    ret = "long?";
                }
            }
            else if (type == "IMAGE")
            {
                ret = "byte[]";
            }
            else if (type == "DATETIME")
            {
                ret = "DateTime?";
            }

            return ret;
        }
    }
}
