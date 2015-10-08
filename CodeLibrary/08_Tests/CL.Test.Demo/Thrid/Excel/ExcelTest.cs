using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Plugin.Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CL.Test.Demo.Thrid.Excel
{
    [TestClass]
    public class ExcelTest
    {
        [TestMethod]
        public void 下载()
        {
            var dt = new DataTable();
            dt.Columns.Add("总会员量");
            dt.Columns.Add("今日新增会员量");
            dt.Columns.Add("代理商数");
            dt.Columns.Add("批发商数");
            dt.Columns.Add("代理商和批发商比率");

            var eh = new ExcelHelper();
            dt.Rows.Add(new string[]
            {
               "lbl总会员量",
               "lbl今日新增会员量",
               "lbl代理商数",
               "lbl批发商数",
               "lbl代理商和批发商比率"
            });
            eh.FillDataNew("会员信息", dt, "会员信息", true);
            eh.ExportExcelFile("会员信息");
        }
    }
}
