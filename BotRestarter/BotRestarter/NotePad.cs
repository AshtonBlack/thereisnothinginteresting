using System;
using System.IO;

namespace BotRestarter
{
    class NotePad
    {
        string timePath = @"C:\Bot\time.txt";
        public void WriteTime(DateTime[] times)
        {
            using (StreamWriter sw = new StreamWriter(timePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(times[0]);
                sw.Close();
            }
            using (StreamWriter sw = new StreamWriter(timePath, true, System.Text.Encoding.Default))
            {
                for(int i = 1; i < times.Length; i++)
                {
                    sw.WriteLine(times[i]);
                }                
                sw.Close();
            }
        }        
        public DateTime[] ReadTime()
        {
            int linenumber = 0;
            using (StreamReader sr = new StreamReader(timePath, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null && line != " " && line != "")
                {
                    linenumber++;
                }
                sr.Close();
            }
            DateTime[] thetime = new DateTime[linenumber];
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
        public static void ClearLog()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Log.txt", false, System.Text.Encoding.Default)) 
            {
                sw.WriteLine("Начинаю новую сессию");
                sw.Close();
            }
        }
        public static void DoLog(string text)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\CarSorting.txt", true, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine(text);
                sw.Close();
            }
        }
        public static void DoLogWithTime(string text)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\CarSorting.txt", true, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine(text + "  " + DateTime.Now.ToLongTimeString());
                sw.Close();
            }
        }
    }
}