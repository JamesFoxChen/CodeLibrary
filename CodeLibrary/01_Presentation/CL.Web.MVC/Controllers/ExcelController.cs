using CL.Plugin.Excel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CL.Web.MVC.Controllers
{
    public class ExcelController : Controller
    {
        //
        // GET: /Excel/
        public ActionResult Write()
        {
            var workbook = new HSSFWorkbook();//从流内容创建Workbook对象
            ISheet sheet = ((HSSFWorkbook)workbook).CreateSheet("sheetOne");//创建工作表

            IRow row = sheet.CreateRow(0);//在工作表中添加一行
            ICell cell = row.CreateCell(0);//在行中添加一列
            cell.SetCellValue("test");//设置列的内容

            string filePath = Server.MapPath("~/ExportFiles/" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
            FileStream fs = new FileStream(filePath, FileMode.Create);
            workbook.Write(fs);
            fs.Close();

            return null;
        }
    }
}