using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Test.DapperNet.Entities;
using Dapper;

namespace CL.Test.DapperNet.OperateDemo
{
    public class SelectDemo
    {
        public static List<AdminInfo> GetAdminInfoList(string filter, object param)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                filter = " 1 = 1";
            }
            string sql = string.Format(@"SELECT * FROM dbo.AdminInfo WHERE {0}", filter);
            using (var conn = DapperConnection.GetConnection())
            {
                return conn.Query<AdminInfo>(sql, param).ToList();
            }
        }

        public static int GetCount()
        {
            string sql = string.Format(@"SELECT COUNT(*) FROM dbo.Test1 WHERE ID=@ID");
            using (var conn = DapperConnection.GetConnection())
            {
                return conn.ExecuteScalar<int>(sql, new { ID = 4 });
            }
        }
    }
}
