using System.Data;
using System.Data.SqlClient;

namespace CL.Services.WinService
{
    public class AdoMng
    {
        private static string conStr = "Server=.;Database=Log_IIS;User Id=sa;Password=123;";
        public static int Execute(string sql)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                using (SqlCommand sqlcmd = connection.CreateCommand())
                {
                    string strCmd = sql;
                    sqlcmd.CommandText = strCmd;
                    return sqlcmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable Get(string sql)
        {
            var dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlDataAdapter sa = new SqlDataAdapter(sql, connection);
                sa.Fill(dt);
            }

            return dt;
        }
    }
}
