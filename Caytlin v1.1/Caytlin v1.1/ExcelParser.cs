using System;
using System.Collections.Generic;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace Caytlin_v1._1
{
    class ExcelParser
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

            return arrData;
        }
        static List<CarForExcel> HandleTable(object[,] fulltable)
        {
            List<CarForExcel> carTable = new List<CarForExcel>();
            for (int i = 0; i < rows; i++)
            {
                int line = i + 1;
                CarForExcel car = new CarForExcel();
                car.country = fulltable[line, 4].ToString();
                car.manufacturer = fulltable[line, 5].ToString();
                car.model = fulltable[line, 6].ToString();
                car.year = fulltable[line, 7].ToString();
                car.rarity = fulltable[line, 2].ToString();
                car.tires = fulltable[line, 15].ToString();
                car.rq = fulltable[line, 3].ToString();
                car.drive = fulltable[line, 13].ToString();
                car.fuel = fulltable[line, 23].ToString();
                car.body = fulltable[line, 24].ToString();
                car.seats = fulltable[line, 25].ToString();
                if(!(fulltable[line, 26] == null))
                {
                    car.tags = fulltable[line, 26].ToString();
                }
                car.clearance = fulltable[line, 18].ToString();
                car.acceleration = fulltable[line, 9].ToString();
                car.speed = fulltable[line, 8].ToString();
                car.grip = fulltable[line, 12].ToString();
                carTable.Add(car);
            }

            return carTable;
        }
    }
}
