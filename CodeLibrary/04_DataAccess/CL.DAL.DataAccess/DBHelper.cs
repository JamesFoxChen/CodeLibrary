using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.DAL.DataAccess.Common;

namespace CL.DAL.DataAccess
{
    public abstract class DBHelper<T>
    {
        #region 字段和属性
        protected static string connectStr;

        public static string ConnectStr
        {
            get { return connectStr ?? (connectStr = DBConnection.GetConnectionString()); }
        }
        #endregion

        #region 查询语句,返回DataTable

        /// <summary>
        /// 根据sql查询语句,返回datatable(默认CommandType为Text类型)
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="commandType"> </param>
        /// <returns>结果数据表</returns>
        public abstract DataTable GetDataTable(string sqlStr, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 根据sql查询语句,返回datatable
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="listParameters"> </param>
        /// <param name="parCommandType"> </param>
        /// <returns>结果数据表</returns>
        public abstract DataTable GetDataTable(string sqlStr, List<T> listParameters, CommandType parCommandType = CommandType.Text);
        #endregion

        #region 根据多条sql查询语句,返回dataset,其中包含多个DataTable

        /// <summary>
        /// 根据多条sql查询语句,返回dataset,其中包含多个DataTable(默认CommandType为Text类型)
        /// </summary>
        /// <param name="sqlList">sql语句集合 </param>
        /// <param name="commandType"> </param>
        /// <returns>结果数据集(各个datatable的名称依次为DataTable1,DataTable2,DataTable3...)</returns>
        public abstract DataSet GetDataSet(List<string> sqlList, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 根据多条sql查询语句和OracleParameters集合,返回dataset,其中包含多个DataTable
        /// </summary>
        /// <param name="sqlList"> sql语句集合</param>
        /// <param name="parListParameters">参数集合 </param>
        /// <param name="commandType"> </param>
        /// <returns>结果数据集(各个datatable的名称依次为DataTable1,DataTable2,DataTable3...)</returns>
        public abstract DataSet GetDataSet(List<string> sqlList, List<List<T>> parListParameters,
                                           CommandType commandType = CommandType.Text);

        #endregion

        #region 根据sql语句执行插入/修改/删除操作,返回影响的行数

        /// <summary>
        /// 根据sql语句执行插入/修改/删除操作,返回影响的行数(单条)(默认CommandType为Text类型)
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="commandType"> </param>
        /// <returns>影响的行数</returns>
        public abstract int ExecuteSql(string sqlStr, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 根据sql语句和DbParameters集合执行插入/修改/删除操作,返回影响的行数(单条)
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="listParameters"> </param>
        /// <param name="commandType"> </param>
        /// <returns>影响的行数</returns>
        public abstract int ExecuteSql(string sqlStr, List<T> listParameters, CommandType commandType = CommandType.Text);
        #endregion

        #region 根据sql语句执行插入/修改/删除操作,返回影响的行数(多条)

        /// <summary>
        /// 根据sql语句执行插入/修改/删除操作,返回影响的行数(多条)(默认CommandType为Text类型)
        /// </summary>
        /// <param name="sqlList">sql语句集合</param>
        /// <param name="commandType"> </param>
        /// <returns>成功：返回影响的行数；异常抛出</returns>
        public abstract int ExecuteSqlArray(List<string> sqlList, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 根据sql语句和DbParameters集合执行插入/修改/删除操作,返回影响的行数(多条)
        /// </summary>
        /// <param name="sqlList">sql语句集合</param>
        /// <param name="listParameters"> </param>
        /// <param name="commandType"> </param>
        /// <returns>最后影响的行数</returns>
        public abstract int ExecuteSqlArray(List<string> sqlList, List<List<T>> listParameters,
                                            CommandType commandType = CommandType.Text);

        #endregion

        #region 根据sql语句返回第一行第一列数据(单条)

        /// <summary>
        /// 根据sql语句返回第一行第一列数据(单条)(默认CommandType为Text类型)
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="commandType"> </param>
        /// <returns>第一行第一列数据</returns>
        public abstract object ExecuteScalar(string sqlStr, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 根据sql语句和DbParameters集合返回第一行第一列数据(单条)
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="commandType"> </param>
        /// <param name="listDbParameters"> </param>
        /// <returns>第一行第一列数据</returns>
        public abstract object ExecuteScalar(string sqlStr, List<T> listDbParameters,
                                             CommandType commandType = CommandType.Text);

        #endregion

        #region 根据sql语句返回DbDataReader

        /// <summary>
        /// 执行查询语句，返回DbDataReader(默认CommandType为Text类型)
        /// </summary>
        /// <param name="sqlStr">查询语句</param>
        /// <param name="commandType"> </param>
        /// <returns>DbDataReader</returns>
        public abstract DbDataReader ExecuteReader(string sqlStr, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 执行查询语句，返回DbDataReader
        /// </summary>
        /// <returns>DbDataReader</returns>
        public abstract DbDataReader ExecuteReader(string sqlStr, List<T> listDbParameters,
                                                     CommandType commandType = CommandType.Text);

        #endregion
    }
}
