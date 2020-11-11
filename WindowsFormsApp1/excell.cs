using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1
{
    public class excell
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public excell(string path, int Sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];

        }
        public string ReadCell(int i = 0, int j = 0)
        {
            i++; j++;
            if (ws.Cells[i, j].Value2 != null)
            {
                try
                {
                    return ws.Cells[i, j].Value2.ToString();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
                return "0";
        }

        public void kapat()
        {
            wb.Close();
        }
        //public void SelectWorksheet(int SheetNumber)
        //{
        //    this.ws = wb.Worksheets[SheetNumber];
        //}
        public void DeleteWorksheet(int SheetNumber)
        {
            ws.Rows[SheetNumber].Delete();
            wb.Save();
        }
    }
}
