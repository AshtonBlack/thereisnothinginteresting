using System;
using System.IO;
using System.Text;

namespace WindowsFormsApp1
{
    class AshtonTable
    {
        public int fieldN { get; set; }
        public int lineN { get; set; }
        public string fn { get; set; }

        public int ContainLines(string filename)
        {
            int linenumber = 0;
            using (StreamReader sr = new StreamReader(@"C:\Bot\" + filename + ".txt", System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    linenumber++;
                }
                sr.Close();
            }
            return linenumber;
        }

        public string[] Making1dArray(string filename)
        {
            string[] array1d = new string[ContainLines(filename)];
            using (StreamReader sr = new StreamReader(@"C:\Bot\" + filename + ".txt", System.Text.Encoding.Default))
            {
                for (int i = 0; i < array1d.Length; i++)
                {
                    array1d[i] = sr.ReadLine();
                }
                sr.Close();
            }
            return array1d;
        }

        public string[] Rebuild1dArray(string filename, char separator)
        {
            string[] a1 = Making1dArray(filename);

            bool[] usefullLines = new bool[a1.Length];
            for (int i = 0; i < usefullLines.Length; i++)
            {
                usefullLines[i] = false;
            }

            int fieldcountsStandart = 0;
            char[] firstline = a1[0].ToCharArray();
            for (int i = 0; i < firstline.Length; i++)
            {
                if (firstline[i] == separator) fieldcountsStandart++;
            }
            fieldN = fieldcountsStandart + 1;

            int newArrLength = 0;
            int fieldcounts;
            for (int i = 0; i < a1.Length; i++)
            {
                fieldcounts = 0;
                char[] line = a1[i].ToCharArray();
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == separator) fieldcounts++;
                }
                if (fieldcounts == fieldcountsStandart)
                {
                    usefullLines[i] = true;
                    newArrLength++;
                }
            }
            lineN = newArrLength;

            string[] a11 = new string[newArrLength];
            int iterator = 0;
            for (int i = 0; i < a1.Length; i++)
            {
                if (usefullLines[i])
                {
                    a11[iterator] = a1[i];
                    iterator++;
                }
            }

            return a11;
        }

        public string[,] Making2dArray(string filename, char separator)
        {
            fn = filename;
            string[] a1 = Rebuild1dArray(filename, separator);

            string[,] a2 = new string[a1.Length, fieldN];
            for(int i = 0; i < a1.Length; i++)
            {
                StringBuilder field = new StringBuilder();                
                int pos = 0;
                for(int j = 0; j < a1[i].Length; j++)
                {
                    if(a1[i][j] != separator)
                    {
                        field.Append(a1[i][j]);
                    }
                    else
                    {
                        a2[i, pos] = field.ToString();
                        field.Clear();
                        pos++;
                    }
                }
                if(pos < fieldN)
                {
                    a2[i, pos] = field.ToString();
                    field.Clear();
                }                
            }

            PrintArray(a2);

            return a2;
        }

        public void PrintArray(string[,] a)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\" + fn + "999.txt", false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < lineN; i++)
                {
                    for (int j = 0; j < fieldN; j++)
                    {
                        sw.Write(a[i, j] + " ");
                    }
                    sw.WriteLine();
                }
            }            
        }
    }
}