using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.CrossDomain.DomainModel.Background.Other.Response;
using CL.DAL.DataAccess;
using CL.Framework.Utils;

namespace CL.Biz.Background.Other
{
    /// <summary>
    /// ColumnControl 的摘要说明
    /// </summary>
    public class ColumnControlBiz
    {

        #region 数据列相关
        /// <summary>
        /// 根据表名获取表中数据列
        /// </summary>
        /// <param name="dbTableName"></param>
        /// <returns></returns>
        public static List<DBTablesColumnRepsosne> GetColumnsByTableName(string dbTableName)
        {
            string sqlstr = String.Empty;
            //            if (StaticBizUtil.DBType == EnumDBType.Oracle.GetHashCode())
            //            {
            //                sqlstr = String.Format(
            //                          @"SELECT utc.*,ucc.comments,'' PascalName,dtc.data_default DefaultValue
            //                            FROM user_tab_columns utc
            //                            INNER JOIN user_col_comments ucc ON utc.table_name=ucc.table_name AND utc.column_name=ucc.column_name
            //                            INNER JOIN dba_tab_cols dtc ON utc.table_name=dtc.table_name AND utc.column_name=dtc.column_name
            //                            WHERE UPPER(utc.table_name)='{0}'", dbTableName);
            //            }
            //            else if (StaticBizUtil.DBType == EnumDBType.SqlServer.GetHashCode())
            //            {
            sqlstr = String.Format(
                 @"Declare @tblName nvarchar(1000)
                                set @tblName='{0}'
                                declare @TblID int
                                set @TblID=(select [object_id] as tblID  from sys.all_objects where [type] ='U' and [name]<>'dtproperties' and [name]=@tblName) 
                                select syscolumns.name as Column_Name,
                                systypes.name as DATA_TYPE,
                                syscolumns.length as DATA_LENGTH,
                                syscolumns.prec as DATA_PRECISION,  --xprec
                                syscolumns.scale as DATA_SCALE, --xscale
                                syscolumns.isnullable as Nullable, 
                                syscomments.text AS DefaultValue,
        	                    (SELECT   [value] FROM  ::fn_listextendedproperty(NULL, 'user', 'dbo', 'table', object_name(@TblID), 'column', syscolumns.name)  as e where e.name='MS_Description') as Comments,
                                '' PascalName
        	                        from sysColumns 
        	                        left join sysTypes on sysTypes.xtype = sysColumns.xtype and sysTypes.xusertype = sysColumns.xusertype 
        	                        left join sysobjects on sysobjects.id = syscolumns.cdefault and sysobjects.type='D' 
        	                        left join syscomments on syscomments.id = sysobjects.id 
                                where syscolumns.id=@TblID
                                ORDER BY Column_Name", dbTableName);

            var dbHelper = new SqlServerDBHelper();
            var dtColumns = dbHelper.GetDataTable(sqlstr);
            var response = ReflectionUtil.ConvertDataTableToModelList<DBTablesColumnRepsosne>(dtColumns);
            return response;
        }

        ///// <summary>
        ///// 根据数据库列名填充Pascal列名
        ///// </summary>
        ///// <param name="dtColumns"></param>
        ///// <returns>所有列都有对应关系返回true; 否则返回false</returns>
        //public static bool GetColRelaPascalName(DataTable dtColumns)
        //{
        //    var dic = new BackEntities().ST_Correspondings.ToDictionary(p => p.OriName, p => p.PascalName);

        //    for (int i = 0; i < dtColumns.Rows.Count; i++)
        //    {
        //        string colName = dtColumns.Rows[i]["Column_Name"].ToString().ToUpper();
        //        if (dic.ContainsKey(colName))
        //        {
        //            dtColumns.Rows[i]["PascalName"] = dic[colName];
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// 根据表名获取数据列原型及变形信息
        ///// </summary>
        ///// <param name="dbTableName"></param>
        ///// <returns></returns>
        //public static DataTable GetTableColumn(string dbTableName)
        //{
        //    DataTable dtColumns = GetTableColumnsByTableName(dbTableName);

        //    var dic = new BackEntities().ST_Correspondings.ToDictionary(p => p.OriName, p => p.PascalName);

        //    for (int i = 0; i < dtColumns.Rows.Count; i++)
        //    {
        //        string name = dtColumns.Rows[i]["Column_Name"].ToString().ToUpper();
        //        if (dic.ContainsKey(name))
        //        {
        //            dtColumns.Rows[i]["PascalName"] = dic[name];
        //        }
        //    }
        //    dtColumns.AcceptChanges();
        //    return dtColumns;
        //}
        #endregion


        #region Xml相关
        ///// <summary>
        ///// 根据数据库列名填充Pascal列名
        ///// </summary>
        ///// <param name="dtColumns"></param>
        ///// <returns>所有列都有对应关系返回true; 否则返回false</returns>
        //public static bool GetColRelaPascalNameForXml(DataTable dtColumns)
        //{
        //    Dictionary<string, string> dic = XmlControl.ReadXmlToDictionary();

        //    for (int i = 0; i < dtColumns.Rows.Count; i++)
        //    {
        //        string colName = dtColumns.Rows[i]["Column_Name"].ToString().ToUpper();
        //        if (dic.ContainsKey(colName))
        //        {
        //            dtColumns.Rows[i]["PascalName"] = dic[colName];
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //public static DataTable GetColumnAndPascalNameFromXml(string dbTableName)
        //{
        //    DataTable dtColumns = GetTableColumnsByTableName(dbTableName);

        //    var dic = XmlControl.ReadXmlToDictionary();

        //    for (int i = 0; i < dtColumns.Rows.Count; i++)
        //    {
        //        string name = dtColumns.Rows[i]["Column_Name"].ToString().ToUpper();
        //        if (dic.ContainsKey(name))
        //        {
        //            dtColumns.Rows[i]["PascalName"] = dic[name];
        //        }
        //    }
        //    dtColumns.AcceptChanges();
        //    return dtColumns;
        //}
        #endregion
    }
}
