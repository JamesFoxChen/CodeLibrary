using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.UI;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Web;

namespace CL.Framework.Utils
{
    /// <summary>
    /// Excel操作工具类（NPOI）
    /// </summary>
    public static class ExcelUtil
    {
        private static HSSFWorkbook hssfworkbook;

        /// <summary>
        /// 导出到Excel
        /// </summary>
        /// <param name="page"></param>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        public static void ExportToXls(Page page, DataTable data, string fileName = "", string sheetName = "")
        {
            page.Response.ContentType = "application/vnd.ms-excel";
            page.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", HttpUtility.UrlEncode(fileName) + ".xls"));
            page.Response.Clear();

            hssfworkbook = new HSSFWorkbook();
            generateData(data, sheetName);
            page.Response.BinaryWrite(writeToStream().GetBuffer());
            page.Response.End();
        }

        private static void generateData(DataTable data, string sheetName = "")
        {
            if (string.IsNullOrWhiteSpace(sheetName)) sheetName = "Sheet1";
            ISheet sheet1 = hssfworkbook.CreateSheet(sheetName);
            IRow titleRow = sheet1.CreateRow(0);
            for (int i = 0; i < data.Columns.Count; i++)
            {
                titleRow.CreateCell(i).SetCellValue(data.Columns[i].ColumnName);
            }

            for (int i = 0; i < data.Rows.Count; i++)
            {
                IRow contentRow = sheet1.CreateRow(i + 1);

                for (int j = 0; j < data.Columns.Count; j++)
                {
                    contentRow.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                }
            }
        }

        private static MemoryStream writeToStream()
        {
            //Write the stream data of workbook to the root directory
            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            return file;
        }
    }
}
