using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Plugin.Excel
{
    public interface IExcelWrite
    {
        object CreateWorkBook();

        object CreateSheet(object workbook, string sheetName);

        object CreateRow(object sheet, string row);

        object CreateCell(object row, string cell);

        void WriteFile(object workbook, string fileName);
    }
}
