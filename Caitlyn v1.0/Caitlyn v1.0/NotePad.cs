using System;
using System.IO;
using System.Text;

namespace Caitlyn_v1._0
{
    class NotePad
    {
        public static void DoErrorLog(string text)
        {
            DoLog("Найдена ошибка: " + text);
            bool match = false;
            if (File.Exists(@"C:\Bot\Errors.txt"))
            {
                using (StreamReader sr = new StreamReader(@"C:\Bot\Errors.txt", System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == text)
                        {
                            match = true;
                            DoLog("повторная ошибка: " + text);
                            break;
                        }
                    }
                    sr.Close();
                }
            }
            if (!match)
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Bot\Errors.txt", true, System.Text.Encoding.Default))//true для дописывания 
                {
                    sw.WriteLine(text);
                    sw.Close();
                }
            }
        }

        public static void DoLog(string text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Bot\Log.txt", true, System.Text.Encoding.Default))//true для дописывания 
                {
                    sw.WriteLine(text + "  " + DateTime.Now.ToLongTimeString());
                    sw.Close();
                }
            }
            catch (Exception ex)
            {

            }

        }

        public static void Saves(int[] carsid)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Saves.txt", false, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine(Condition.eventrq);
                sw.WriteLine(Condition.ConditionNumber1);
                sw.WriteLine(Condition.ConditionNumber2);
                for (int i = 0; i < 5; i++)
                {
                    sw.WriteLine(carsid[i]);
                }
                sw.Close();
            }
        }

        public static string[] ReadSaves()
        {
            string[] a = new string[8];
            using (StreamReader sr = new StreamReader(@"C:\Bot\Saves.txt", System.Text.Encoding.Default))
            {
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = sr.ReadLine();//rq, condition1, condition2, carsid(5)
                }
                sr.Close();
            }
            return a;
        }

        public static int[] ReadCars()
        {
            int[] cars = new int[5];
            string[] a = ReadSaves();

            for (int i = 0; i < cars.Length; i++)
            {
                cars[i] = Convert.ToInt32(a[i + 3]);//rq, condition1, condition2, carsid(5)
            }

            return cars;
        }

        public static string[] ReadConditions()
        {
            string[] conds = new string[2];
            string[] a = ReadSaves();
            conds[0] = a[1];
            conds[1] = a[2];
            return conds;
        }

        public static int ReadRQ()
        {
            string[] a = ReadSaves();
            int rq = Convert.ToInt32(a[0]);
            return rq;
        }

        public static void ClearLog()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Log.txt", false, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine("Начинаю новую сессию " + DateTime.Now.ToLongTimeString());
                sw.Close();
            }
        }

        public static void LastWeather(string weather)//merge with saves
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Weather.txt", false, System.Text.Encoding.Default))
            {
                sw.WriteLine(weather);
                sw.Close();
            }
        }

        public static string FindWeather1()//merge with saves
        {
            string weather;
            using (StreamReader sr = new StreamReader(@"C:\Bot\Weather.txt", System.Text.Encoding.Default))
            {
                weather = sr.ReadLine();
                sr.Close();
            }
            return weather;
        }

        public static void LastCoverage(string coverage)//merge with saves
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Coverage.txt", false, System.Text.Encoding.Default))
            {
                sw.WriteLine(coverage);
                sw.Close();
            }
        }

        public static string FindCoverage1()//merge with saves
        {
            string coverage;
            using (StreamReader sr = new StreamReader(@"C:\Bot\Coverage.txt", System.Text.Encoding.Default))
            {
                coverage = sr.ReadLine();
                sr.Close();
            }
            return coverage;
        }

        public static int GetInfoFileLength(string path)
        {
            int length = 0;
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null && line != " " && line != "")
                {
                    length++;
                }
                sr.Close();
            }
            return length;
        }

        public static string[,] ReadInfoFromTXT(string path)
        {
            int length = GetInfoFileLength(path);
            string[,] picturetoname = new string[length, 2];

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                for (int i = 0; i < length; i++)
                {
                    string theline = sr.ReadLine();
                    picturetoname[i, 0] = Transform(theline, 1);
                    picturetoname[i, 1] = Transform(theline, 2);
                }
                sr.Close();
            }

            return picturetoname;
        }

        public static string Transform(string line, int wordN)
        {
            char[] word = line.Trim().ToCharArray();
            StringBuilder firstWord = new StringBuilder();
            StringBuilder secondWord = new StringBuilder();

            bool firstwordcomplete = false;
            foreach (char literal in word)
            {
                if (firstwordcomplete)
                {
                    secondWord.Append(literal);
                }
                else
                {
                    if (literal != ' ')
                    {
                        firstWord.Append(literal);
                    }
                    else firstwordcomplete = true;
                }                
            }

            if (wordN == 1)
            {
                return firstWord.ToString();
            }
            else
            {
                return secondWord.ToString();
            }
        }
        public static string timePath = @"C:\Bot\time.txt";
        public static DateTime[] ReadTime()
        {
            DateTime[] thetime = new DateTime[GetInfoFileLength(timePath)];
            using (StreamReader sr = new StreamReader(timePath, System.Text.Encoding.Default))
            {
                for (int i = 0; i < thetime.Length; i++)
                {
                    thetime[i] = Convert.ToDateTime(sr.ReadLine());
                }

                sr.Close();
            }

            return thetime;
        }
    }
}