using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelParcer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Opacity = 0;
        }

        int rows;
        int columns;

        void DoLog(string text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\projects\bot\Log.txt", true, System.Text.Encoding.Default))//true для дописывания 
                {
                    sw.Write(text);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {

            }

        }

        void DoEndLine()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\projects\bot\Log.txt", true, System.Text.Encoding.Default))//true для дописывания 
                {
                    sw.WriteLine();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {

            }

        }

        List<ArrayList> HandleTable(object[,] fulltable)
        {
            int[] neededCells = { 2,3,4,5,6,7,8,9,12,14,17,20,22,23,24,25,26  };
            List<ArrayList> usefultable = new List<ArrayList>();
            for(int i = 0; i < rows; i++)
            {
                ArrayList car = new ArrayList();
                foreach (int cell in neededCells)
                {
                    car.Add(fulltable[i+1, cell]);
                }
                usefultable.Add(car);
            }

            return usefultable;
        }

        object[,] Parser(string excelFilePath)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            string excelFilePath = @"C:\projects\bot\cars.xlsx";
            List<ArrayList> table = HandleTable(Parser(excelFilePath));
            foreach(ArrayList line in table)
            {
                foreach(object cell in line)
                {
                    if(cell != null) DoLog(cell.ToString() + " ");
                }
                DoEndLine();
            }
        }
    }
}
