using System;
using System.IO;

namespace WindowsFormsApp1
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
                if(text != "ебучая реклама" && text != "не дождался улучшения за рекламу" && text != "Can't send message")
                {
                    Mail.MailMessage(text);
                }

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
            catch(Exception ex)
            {

            }
            
        }

        public static void Saves(int[] carsid)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Saves.txt", false, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine(Condition.eventrq);
                sw.WriteLine(Condition.conditionNumber);
                for (int i = 0; i < 5; i++)
                {
                    sw.WriteLine(carsid[i]);
                }
                sw.Close();
            }
        }

        public static int[] ReadSaves()
        {
            int[] a = new int[7];
            using (StreamReader sr = new StreamReader(@"C:\Bot\Saves.txt", System.Text.Encoding.Default))
            {
                for (int i = 0; i < 7; i++)
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

        public static string FindWeather()//merge with saves
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

        public static string FindCoverage()//merge with saves
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