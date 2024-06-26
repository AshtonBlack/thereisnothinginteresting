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
            SecondConditions = NotePad.ReadInfoFile(@"C:\Bot\Condition2\info.txt");
            GroupConditions();
            FirstConditions = NotePad.ReadInfoFile(@"C:\Bot\Condition1\info.txt");
            CollectPictureNames();
        }
        static void CollectPictureNames()
        {
            FirstConditionPictureNames = new List<string>();
            FirstUnknownConditionPictureNames= new List<string>();
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
        public static void GroupConditions()
        {
            List<(int number, string condName)> initialConditions = NotePad.ReadInfoFile(@"C:\Bot\Condition1\info.txt");
            List<(int number, string condName)> updatedConditions = new List<(int number, string condName)>();
            List<string> handledConditionsList = new List<string>();
            List<int> picturesToDelete= new List<int>();
            foreach ((int number, string condName) line in initialConditions)
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
                foreach ((int number, string condName) line1 in initialConditions)
                {
                    if (line.condName == line1.condName)
                    {
                        numbers.Add(line1.number);
                    }
                }
                numbers.Sort();
                numbers.Reverse();
                int index = 0;
                foreach(int number in numbers)
                {
                    if(index < 2) updatedConditions.Add((number, line.condName));
                    else picturesToDelete.Add(number);
                    index++;
                }
            }

            foreach (int pictureToDelete in picturesToDelete)
            {
                if (File.Exists(@"C:\Bot\Condition1\" + pictureToDelete.ToString() + ".jpg"))
                    File.Delete(@"C:\Bot\Condition1\" + pictureToDelete.ToString() + ".jpg");
            }

            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Condition1\info.txt", false, Encoding.UTF8))
            {
                int index = 0;                
                foreach ((int number, string condName) line in updatedConditions)
                {
                    sw.WriteLine(index.ToString() + ' ' + line.condName);
                    if (!index.ToString().Equals(line.number.ToString()))
                    {
                        if (File.Exists(@"C:\Bot\Condition1\" + line.number.ToString() + ".jpg"))
                            File.Move(@"C:\Bot\Condition1\" + line.number.ToString() + ".jpg",
                                @"C:\Bot\Condition1\" + index.ToString() + ".jpg");
                    }                    
                    index++;
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
