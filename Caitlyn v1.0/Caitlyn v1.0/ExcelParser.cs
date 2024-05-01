using System;
using System.Collections.Generic;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace Caitlyn_v1._0
{
    class ExcelParcer
    {
        static int rows;
        static int columns;
        public static List<CarForExcel> Parse(string excelFilePath)
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
            KillExcel();

            return arrData;
        }
        static void KillExcel()
        {
            Process[] processes = Process.GetProcessesByName("Microsoft Excel");
            foreach (Process process in processes)
            {
                try
                {
                    process.Kill();
                }
                catch (Exception)
                {

                }
            }
        }
        static List<CarForExcel> HandleTable(object[,] fulltable)
        {
            List<CarForExcel> cartable = new List<CarForExcel>();
            for (int i = 0; i < rows; i++)
            {
                CarForExcel car = new CarForExcel();
                car.pictureId = fulltable[i + 1, 1].ToString();
                car.country = fulltable[i + 1, 4].ToString();
                car.manufacturer = fulltable[i + 1, 5].ToString();
                car.model = fulltable[i + 1, 6].ToString();
                car.year = fulltable[i + 1, 7].ToString();
                car.rarity = fulltable[i + 1, 2].ToString();
                car.tires = fulltable[i + 1, 15].ToString();
                car.rq = fulltable[i + 1, 3].ToString();
                car.drive = fulltable[i + 1, 13].ToString().ToLower();
                car.fuel = fulltable[i + 1, 23].ToString();
                car.body = fulltable[i + 1, 24].ToString();
                car.seats = fulltable[i + 1, 25].ToString();
                if (fulltable[i + 1, 26] != null)
                {
                    car.tags = fulltable[i + 1, 26].ToString();
                }    
                car.clearance = fulltable[i + 1, 18].ToString();
                car.acceleration = fulltable[i + 1, 9].ToString();
                car.speed = fulltable[i + 1, 8].ToString();
                car.grip = fulltable[i + 1, 12].ToString();
                cartable.Add(car);
            }

            return cartable;
        }
    }
}