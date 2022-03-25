using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace botDBUpdater
{
    class ExcelParcer
    {
        static int rows;
        static int columns;
        public static List<Car> Parse(string excelFilePath)
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
        static List<Car> HandleTable(object[,] fulltable)
        {
            List<Car> usefultable = new List<Car>();
            for (int i = 0; i < rows; i++)
            {
                Car car = new Car();
                car.country = fulltable[i + 1, 4].ToString();
                car.manufacturer = fulltable[i + 1, 5].ToString();
                car.model = fulltable[i + 1, 6].ToString();
                car.year = fulltable[i + 1, 7].ToString();
                usefultable.Add(car);
            }

            return usefultable;
        }
    }
}
