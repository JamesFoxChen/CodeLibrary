using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Test.DapperNet
{
    public class DapperConnection
    {
        /// <summary>
        /// 获取字符串链接
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperContext"].ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
