using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL.Framework.Utils
{
    public class PagerUtil
    {
        /// <summary>
        /// 获取翻页查询Sql语句
        /// </summary>
        /// <param name="sqlstr">未加翻页条件的sql语句</param>
        /// <param name="pageIndex">当前页序号</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <returns>添加翻页条件的sql语句</returns>
        public static string GetPageSql(string sqlstr, int pageIndex, int pageSize)
        {
            int startIndex = (pageIndex - 1) * pageSize;
            int endIndex = pageSize * pageIndex;

            var sbPage = new StringBuilder(" select * from (").
                Append("select t.*, ROWNUM rn from (").
                Append(sqlstr).
                Append(" ) t").
                AppendFormat(" )  where rn >{0} AND rn<={1}", startIndex, endIndex);

            return sbPage.ToString();
        }

        /// <summary>
        /// 获取总记录数查询Sql语句
        /// </summary>
        /// <param name="sqlstr">现在的sql语句</param>
        /// <returns>获得总记录行的sql语句</returns>
        public static string GetTotalCountsSql(string sqlstr)
        {
            return string.Format("SELECT COUNT(1) FROM ({0}) t", sqlstr);
        }

        /// <summary>
        /// 获得重构后的当前页序号
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public static int GetPageIndex(string pageIndex)
        {
            return string.IsNullOrWhiteSpace(pageIndex) ? 1 : Convert.ToInt32(pageIndex);
        }

        /// <summary>
        /// 获得重构后的每页显示数量
        /// </summary>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static int GetPageSize(string pageSize)
        {
            //return string.IsNullOrWhiteSpace(pageSize) ? ConfigUtil.PageSize : Convert.ToInt32(pageSize);
            return 0;
        }
    }
}
