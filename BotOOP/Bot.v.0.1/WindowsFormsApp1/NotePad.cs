using System;
using System.IO;

namespace WindowsFormsApp1
{
    class NotePad
    {
        public static void DoErrorLog(string text)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Errors.txt", true, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine(text);
                sw.Close();
            }
        }

        public static void DoLog(string text)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Log.txt", true, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine(text + "  " + DateTime.Now.ToLongTimeString());
                sw.Close();
            }
        }

        public static void Saves(int eventname, int[] carsid)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Saves.txt", false, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine(Condition.eventrq);
                sw.WriteLine(Condition.conditionNumber);
                sw.WriteLine(eventname);
                for (int i = 0; i < 5; i++)
                {
                    sw.WriteLine(carsid[i]);
                }
                sw.Close();
            }
        }

        public static int[] ReadSaves()
        {
            int[] a = new int[8];
            using (StreamReader sr = new StreamReader(@"C:\Bot\Saves.txt", System.Text.Encoding.Default))
            {
                for (int i = 0; i < 8; i++)
                {
                    a[i] = Convert.ToInt32(sr.ReadLine());//rq, condition, tires, carsid(5)
                }
                sr.Close();
            }
            return a;
        }

        public static void ClearLog()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Log.txt", false, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine("Начинаю новую сессию");
                sw.Close();
            }
        }

        public static void LastWeather(string weather)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Weather.txt", false, System.Text.Encoding.Default))
            {
                sw.WriteLine(weather);
                sw.Close();
            }
        }

        public static string FindWeather()
        {
            string weather;
            using (StreamReader sr = new StreamReader(@"C:\Bot\Weather.txt", System.Text.Encoding.Default))
            {
                weather = sr.ReadLine();
                sr.Close();
            }
            return weather;
        }

        public static void LastCoverage(string coverage)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Coverage.txt", false, System.Text.Encoding.Default))
            {
                sw.WriteLine(coverage);
                sw.Close();
            }
        }

        public static string FindCoverage()
        {
            string coverage;
            using (StreamReader sr = new StreamReader(@"C:\Bot\Coverage.txt", System.Text.Encoding.Default))
            {
                coverage = sr.ReadLine();
                sr.Close();
            }
            return coverage;
        }
    }
}