using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Framework.Utils.Security;

namespace CL.DAL.DataAccess.Common
{
    public class DBConnection
    {
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["CLDbContext"].ConnectionString);
            builder.Password = AESUtil.AESDecrypt(builder.Password);
            return builder.ConnectionString;
        }
    }
}
