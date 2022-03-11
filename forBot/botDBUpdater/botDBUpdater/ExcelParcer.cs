using System;
using System.Collections;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace botDBUpdater
{
    class ExcelParcer
    {
        static int rows;
        static int columns;
        public static List<ArrayList> Parse(string excelFilePath)
        { 
            return HandleTable(Parser(excelFilePath));            
        }

        static object[,] Parser(string excelFilePath)
        {
            Excel.Application ObjWorkExcel = new Excel.Application();
            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(excelFilePath);
            Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1]; //получить 1-й лист
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//последнюю ячейку
            rows = lastCell.Row;
            columns = lastCell.Column;
            var arrData = (object[,])ObjWorkSheet.Range["A1:Z" + lastCell.Row].Value;
            ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
            ObjWorkExcel.Quit(); // выйти из Excel
            GC.Collect(); // убрать за собой

            return arrData;
        }

        static List<ArrayList> HandleTable(object[,] fulltable)
        {
            int[] neededCells = { 2, 3, 4, 5, 6, 7, 8, 9, 12, 14, 17, 20, 22, 23, 24, 25, 26 };
            List<ArrayList> usefultable = new List<ArrayList>();
            for (int i = 0; i < rows; i++)
            {
                ArrayList car = new ArrayList();
                foreach (int cell in neededCells)
                {
                    car.Add(fulltable[i + 1, cell]);
                }
                usefultable.Add(car);
            }

            return usefultable;
        }
    }
}
