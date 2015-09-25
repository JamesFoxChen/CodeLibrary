using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Framework.Utils;

namespace CL.DAL.DataAccess
{
    public class SqlServerDBHelper : DBHelper<SqlParameter>
    {
        public override DataTable GetDataTable(string sqlStr, CommandType commandType = CommandType.Text)
        {
            var dtTemp = new DataTable();

            var con = new SqlConnection { ConnectionString = ConnectStr };

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();     //Open  //Second
                }

                //创建command对象
                var command = new SqlCommand { Connection = con, CommandText = sqlStr, CommandType = commandType };

                var da = new SqlDataAdapter { SelectCommand = command };
                da.Fill(dtTemp);

                command.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();

                LogTxtUtil.LogException(ex.Message);
                throw;
            }
            //123
            return dtTemp;
        }

        public override DataTable GetDataTable(string sqlStr, List<SqlParameter> listDbParameters,
                                               CommandType commandType = CommandType.Text)
        {
            var dtTemp = new DataTable();
            var con = new SqlConnection { ConnectionString = ConnectStr };
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                //创建command对象
                var command = new SqlCommand { Connection = con, CommandType = commandType, CommandText = sqlStr };

                foreach (SqlParameter t in listDbParameters)
                {
                    command.Parameters.Add(t);
                }

                var da = new SqlDataAdapter { SelectCommand = command };
                da.Fill(dtTemp);

                command.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                LogTxtUtil.LogException(ex.Message);
                throw;
            }

            return dtTemp;
        }

        public override DataSet GetDataSet(List<string> sqlList, CommandType commandType = CommandType.Text)
        {
            var dsTemp = new DataSet();
            var con = new SqlConnection { ConnectionString = ConnectStr };

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                //创建command对象
                var command = new SqlCommand { Connection = con, CommandType = commandType };

                var da = new SqlDataAdapter { SelectCommand = command };

                for (int i = 0; i < sqlList.Count; i++)
                {
                    command.CommandText = sqlList[i];
                    var dtTemp = new DataTable();
                    da.Fill(dtTemp);

                    dtTemp.TableName = "DataTable" + Convert.ToString(i + 1);
                    dsTemp.Tables.Add(dtTemp);
                }

                command.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                LogTxtUtil.LogException(ex.Message);
                throw;
            }

            return dsTemp;
        }


        public override DataSet GetDataSet(List<string> sqlList, List<List<SqlParameter>> listParameters,
                                           CommandType commandType = CommandType.Text)
        {
            var dsTemp = new DataSet();
            var con = new SqlConnection { ConnectionString = ConnectStr };

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                //创建command对象
                var command = new SqlCommand { Connection = con, CommandType = commandType };

                var da = new SqlDataAdapter { SelectCommand = command };

                for (int i = 0; i < sqlList.Count; i++)
                {
                    command.CommandText = sqlList[i];

                    //绑定每条sql语句所对应的参数变量
                    for (int j = 0; j < listParameters[i].Count; j++)
                    {
                        command.Parameters.Add(listParameters[i][j]);
                    }

                    var dtTemp = new DataTable();
                    da.Fill(dtTemp);
                    command.Parameters.Clear();

                    dtTemp.TableName = "DataTable" + Convert.ToString(i + 1);
                    dsTemp.Tables.Add(dtTemp);
                }

                command.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                LogTxtUtil.LogException(ex.Message);
                throw;
            }

            return dsTemp;
        }

        public override int ExecuteSql(string sqlStr, CommandType commandType = CommandType.Text)
        {
            int i;

            var con = new SqlConnection { ConnectionString = ConnectStr };

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                //创建command对象
                var command = new SqlCommand { Connection = con, CommandText = sqlStr, CommandType = commandType };

                i = command.ExecuteNonQuery();

                command.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                LogTxtUtil.LogException(ex.Message);
                throw;
            }

            return i;
        }

        public override int ExecuteSql(string sqlStr, List<SqlParameter> listParameters,
                                       CommandType commandType = CommandType.Text)
        {
            int i;

            var con = new SqlConnection { ConnectionString = ConnectStr };

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                //创建command对象
                var command = new SqlCommand { Connection = con, CommandType = commandType, CommandText = sqlStr };

                foreach (SqlParameter t in listParameters)
                {
                    command.Parameters.Add(t);
                }

                i = command.ExecuteNonQuery();

                command.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                LogTxtUtil.LogException(ex.Message);
                throw;
            }

            return i;
        }

        public override int ExecuteSqlArray(List<string> sqlList, CommandType commandType = CommandType.Text)
        {
            int i = 0;

            var con = new SqlConnection { ConnectionString = ConnectStr };
            SqlTransaction tran = null;

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                tran = con.BeginTransaction();

                //创建command对象
                var command = new SqlCommand { Connection = con, Transaction = tran, CommandType = commandType };

                foreach (string t in sqlList)
                {
                    command.CommandText = t;
                    i = command.ExecuteNonQuery();
                }

                command.Dispose();
                tran.Commit();
                tran.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                tran.Dispose();
                con.Close();

                LogTxtUtil.LogException(ex.Message);

                throw;
            }

            return i;
        }


        public override int ExecuteSqlArray(List<string> sqlList, List<List<SqlParameter>> listParameters,
                                            CommandType commandType = CommandType.Text)
        {
            int returnValue = 0; //记录影响的行数

            var con = new SqlConnection { ConnectionString = ConnectStr };
            SqlTransaction tran = null;

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                tran = con.BeginTransaction();

                //创建command对象
                var command = new SqlCommand { Connection = con, Transaction = tran, CommandType = commandType };

                for (int i = 0; i < sqlList.Count; i++)
                {
                    command.CommandText = sqlList[i];

                    //绑定每条sql语句所对应的参数变量
                    for (int j = 0; j < listParameters[i].Count; j++)
                    {
                        command.Parameters.Add(listParameters[i][j]);
                    }

                    int amount = command.ExecuteNonQuery();
                    returnValue += amount;

                    command.Parameters.Clear();
                }

                command.Dispose();
                tran.Commit();
                tran.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                tran.Dispose();
                con.Close();

                LogTxtUtil.LogException(ex.Message);
                throw;
            }

            return returnValue;
        }

        public override object ExecuteScalar(string sqlStr, CommandType commandType = CommandType.Text)
        {
            object i;

            var con = new SqlConnection { ConnectionString = ConnectStr };

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                //创建command对象
                var command = new SqlCommand { Connection = con, CommandText = sqlStr, CommandType = commandType };

                i = command.ExecuteScalar();

                command.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();

                LogTxtUtil.LogException(ex.Message);
                throw;
            }

            return i;
        }


        public override object ExecuteScalar(string sqlStr, List<SqlParameter> listDbParameters,
                                             CommandType commandType = CommandType.Text)
        {
            object i;

            var con = new SqlConnection { ConnectionString = ConnectStr };

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                //创建command对象
                var command = new SqlCommand { Connection = con, CommandType = commandType, CommandText = sqlStr };

                foreach (SqlParameter t in listDbParameters)
                {
                    command.Parameters.Add(t);
                }

                i = command.ExecuteScalar();

                command.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                LogTxtUtil.LogException(ex.Message);
                throw;
            }

            return i;
        }

        public override DbDataReader ExecuteReader(string sqlStr, CommandType commandType = CommandType.Text)
        {
            SqlDataReader dataReader = null;

            var con = new SqlConnection { ConnectionString = ConnectStr };

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                //创建command对象
                var command = new SqlCommand { Connection = con, CommandText = sqlStr, CommandType = commandType };

                dataReader = command.ExecuteReader(CommandBehavior.CloseConnection); //关闭dataReader时，自动关闭关联的connection

                command.Dispose();
            }
            catch (Exception ex)
            {
                dataReader.Close();
                con.Close();

                LogTxtUtil.LogException(ex.Message);
                throw;
            }

            return dataReader;
        }

        public override DbDataReader ExecuteReader(string sqlStr, List<SqlParameter> listDbParameters,
                                                   CommandType commandType = CommandType.Text)
        {
            SqlDataReader dataReader = null;

            var con = new SqlConnection { ConnectionString = ConnectStr };
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                //创建command对象
                var command = new SqlCommand { Connection = con, CommandType = commandType, CommandText = sqlStr };

                foreach (SqlParameter t in listDbParameters)
                {
                    command.Parameters.Add(t);
                }
                dataReader = command.ExecuteReader(CommandBehavior.CloseConnection); //关闭dataReader时，自动关闭关联的connection

                command.Dispose();
            }
            catch (Exception ex)
            {
                dataReader.Close();
                con.Close();

                LogTxtUtil.LogException(ex.Message);
                throw;
            }

            return dataReader;
        }
    }
}
