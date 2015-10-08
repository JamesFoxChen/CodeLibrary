using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CL.CrossDomain.DomainModel.Background.Other.Response;
using CL.DAL.DataAccess;

namespace CL.Biz.Background
{
    public class TableControlBiz
    {
        #region 数据表相关
        /// <summary>
        /// 查询数据表信息
        /// </summary>
        /// <param name="tableName">查询条件</param>
        public static List<DBTablesRepsosne> GetTables(string tableName)
        {
            tableName = tableName.ToLower();
            //DBViewUtil.SwitchDB(EnumDBType.Oracle);

            string strSql = string.Empty;

            //if (StaticBizUtil.DBType == EnumDBType.Oracle.GetHashCode())
            //{
            //    strSql =
            //        "SELECT ut.table_name TableName ,utc.comments,'' PascalName FROM user_tables ut " +
            //        "INNER JOIN user_tab_comments utc ON ut.table_name=utc.table_name";
            //    if (filterValue != string.Empty)
            //    {
            //        strSql += " WHERE LOWER(ut.table_name) LIKE '%" + filterValue + "%'";
            //    }
            //    strSql += " ORDER BY ut.table_name";
            //}
            //else if (StaticBizUtil.DBType == EnumDBType.SqlServer.GetHashCode())
            //{
            strSql =
                @"SELECT t.[name] as TableName,ep.[value] Comments,'' PascalName FROM sys.tables t
                                LEFT JOIN sys.extended_properties ep
                                ON t.[object_id]=ep.major_id AND ep.minor_id=0";
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                strSql += " WHERE LOWER(ep.[name]) LIKE '%" + tableName + "%'";
            }
            //}
            var db = new CLDbContext();
            List<DBTablesRepsosne> response = db.Database.SqlQuery<DBTablesRepsosne>(strSql,"").ToList();
            return response;
        }

        /// <summary>
        /// 获取主键信息
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static List<string> GetPrimayKeys(string tableName)
        {
            //DBViewUtil.SwitchDB(EnumDBType.Oracle);

            string sqlstr = string.Empty;

            //if (StaticBizUtil.DBType == 1)
            //{
            //sqlstr =
            //     string.Format(
            //    @"SELECT * FROM user_cons_columns ucc WHERE UPPER(ucc.table_name)='{0}' AND UPPER(ucc.constraint_name)=CONCAT('PK_','{1}')",
            //    tableName, tableName);
            //}
            //else if (StaticBizUtil.DBType == 2)
            //{
            sqlstr =
                string.Format(@" SELECT column_name FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME='{0}'",
                                   tableName);
            //}

            var db = new CLDbContext();
            List<string> response = db.Database.SqlQuery<string>(sqlstr, "").ToList();
            return response;
        }
        #endregion
    }
}
