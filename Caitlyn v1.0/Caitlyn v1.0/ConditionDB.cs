using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Caitlyn_v1._0
{
    static class ConditionDB
    {
        static List<(int number, string condName)> FirstConditions { get; set; }
        static List<string> FirstConditionPictureNames { get; set; }
        static List<string> FirstUnknownConditionPictureNames { get; set; }
        static List<(int number, string condName)> SecondConditions { get; set; }
        static ConditionDB()
        {
            FirstConditions = NotePad.ReadInfoFile(@"C:\Bot\Condition1\info.txt");
            SecondConditions = NotePad.ReadInfoFile(@"C:\Bot\Condition2\info.txt");
            GroupConditions();
            CollectPictureNames();
        }
        static void CollectPictureNames()
        {
            List<string> allFiles = new List<string>(Directory.GetFiles(@"C:\Bot\Condition1"));
            foreach (string file in allFiles)
            {
                if (!file.Contains("txt") && !file.Contains("test"))
                {
                    if (!file.ToLower().Contains("unknown"))
                    {
                        FirstConditionPictureNames.Add(file);
                    } 
                    else
                    {
                        FirstUnknownConditionPictureNames.Add(file);
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(@"C:\Bot\CollectPictureNamesTest.txt", false, Encoding.UTF8))//true для дописывания
            {
                foreach (string line in FirstConditionPictureNames)
                {
                    sw.WriteLine(line);
                }
                sw.Close();
            }
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\CollectPictureNamesTest.txt", true, Encoding.UTF8))//true для дописывания
            {
                foreach (string line in FirstUnknownConditionPictureNames)
                {
                    sw.WriteLine(line);
                }
                sw.Close();
            }
        }
        static void GroupConditions()
        {
            List<(int number, string condName)> updatedConditions = new List<(int number, string condName)>();
            List<string> handledConditionsList = new List<string>();
            foreach ((int number, string condName) line in FirstConditions)
            {
                if (handledConditionsList.Count == 0)
                {
                    handledConditionsList.Add(line.condName);
                }
                else
                {
                    if (handledConditionsList.Contains(line.condName)) continue;
                    handledConditionsList.Add(line.condName);
                }
                List<int> numbers = new List<int>();
                foreach ((int number, string condName) line1 in FirstConditions)
                {
                    if (line.condName == line1.condName)
                    {
                        numbers.Add(line1.number);
                    }
                }
                numbers.Sort();
                numbers.Reverse();
                updatedConditions.Add((numbers[0], line.condName));
                if (numbers.Count > 1)
                {
                    updatedConditions.Add((numbers[1], line.condName));
                }
            }

            using (StreamWriter sw = new StreamWriter(@"C:\Bot\uniqueCondTest.txt", false, Encoding.UTF8))//true для дописывания
            {
                foreach (string line in handledConditionsList)
                {
                    sw.WriteLine(line);
                }
                sw.Close();
            }

            using (StreamWriter sw = new StreamWriter(@"C:\Bot\updateCondTest.txt", false, Encoding.UTF8))//true для дописывания
            {
                foreach ((int number, string condName) line in updatedConditions)
                {
                    sw.WriteLine(line.number + ' ' + line.condName);
                }
                sw.Close();
            }
        }
        public static string GetFirstConditionByNumber(int picture)
        {            
            foreach ((int number, string condName) line in FirstConditions)
            {
                if (picture == line.number)
                {
                    NotePad.DoLog("1 условие: " + line.condName);
                    return line.condName;
                }
            }
            NotePad.DoErrorLog("Неизвестное условие");
            return "unknown";
        }
        public static string GetSecondConditionByNumber(int picture)
        {
            foreach ((int number, string condName) line in SecondConditions)
            {
                if (picture == line.number)
                {
                    NotePad.DoLog("2 условие: " + line.condName);
                    return line.condName;
                }
            }
            NotePad.DoErrorLog("Неизвестное условие");
            return "unknown";        
        }                
    }
}
