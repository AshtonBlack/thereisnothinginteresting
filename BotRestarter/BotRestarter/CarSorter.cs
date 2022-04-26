using System;
using System.Drawing;
using System.IO;

namespace BotRestarter
{
    internal class CarSorter
    {
        public static bool started = false;
        int unknowncarsN = 0;
        int x0 = 32;
        int y0 = 7;
        int foundcars = 0;
        int predictcars = 0;
        string fingerDirectory = @"C:\Bot\Finger";        
        string finger1Path = @"C:\Bot\Finger1";
        string[] readFilesFromDirectory(string PathToFolder)
        {
            return Directory.GetFiles(PathToFolder);
        }
        void UpdatePicture(int fingerN, string pictureNameFromFinger, string pictureNameFromFinger1)
        {
            string oldPicture = fingerDirectory + fingerN + "\\old" + Path.GetFileName(pictureNameFromFinger1);
            string newPicture = fingerDirectory + fingerN + "\\" + Path.GetFileName(pictureNameFromFinger1);
            if (File.Exists(newPicture))
            {
                if (File.Exists(oldPicture))
                {
                    File.Delete(oldPicture);
                }
                File.Move(newPicture, oldPicture);
                NotePad.DoLog("Обновляю " + newPicture);
            }
            File.Move(pictureNameFromFinger, newPicture);
        }
        public void Sort()
        {
            started = true;
            NotePad.ClearLog();
            string[] picturesFromFinger1 = readFilesFromDirectory(finger1Path);
            NotePad.DoLog("В Finger1 " + picturesFromFinger1.Length + " файлов");
            for (int fingerN = 2; fingerN < 6; fingerN++)
            {
                string[] picturesFromFinger = readFilesFromDirectory(fingerDirectory + fingerN);
                NotePad.DoLog("В Finger" + fingerN + " " + picturesFromFinger.Length + " файлов");
                foreach (string pictureNameFromFinger in picturesFromFinger)
                {
                    if (pictureNameFromFinger.Contains("unsorted"))
                    {
                        unknowncarsN++;
                        Bitmap pictureFromFinger = new Bitmap(pictureNameFromFinger);
                        foreach(string pictureNameFromFinger1 in picturesFromFinger1)
                        {
                            if (pictureNameFromFinger1.Contains("jpg"))
                            {
                                Bitmap pictureFromFinger1 = new Bitmap(pictureNameFromFinger1);
                                int shadesdifs = 0;
                                for (int x = 0; x < 50; x++)
                                {
                                    for (int y = 0; y < 50; y++)
                                    {
                                        var colorValue0 = pictureFromFinger.GetPixel(x + x0, y + y0);
                                        var colorValue1 = pictureFromFinger1.GetPixel(x + x0, y + y0);
                                        shadesdifs += (Math.Abs((int)colorValue0.R - (int)colorValue1.R) +
                                            Math.Abs((int)colorValue0.G - (int)colorValue1.G) +
                                            Math.Abs((int)colorValue0.B - (int)colorValue1.B));
                                    }
                                }
                                pictureFromFinger1.Dispose();
                                if (shadesdifs < 60000)
                                {
                                    pictureFromFinger.Dispose();
                                    if (shadesdifs < 40000)
                                    {
                                        NotePad.DoLog("Считаю одинаковыми");
                                        foundcars++;
                                    }
                                    else
                                    {
                                        NotePad.DoLog("Вероятно, одинаковые");
                                        predictcars++;
                                    }
                                    NotePad.DoLog(pictureNameFromFinger);
                                    NotePad.DoLog("и " + pictureNameFromFinger1);
                                    NotePad.DoLog("Различие в " + shadesdifs + " оттенков");
                                    UpdatePicture(fingerN, pictureNameFromFinger, pictureNameFromFinger1);
                                    break;
                                }
                            }
                        }
                        pictureFromFinger.Dispose();
                    }                    
                }                
            }

            NotePad.DoLogWithTime("найдено машин: " + foundcars);
            NotePad.DoLogWithTime("вероятных совпадений " + predictcars);
            NotePad.DoLogWithTime("осталось неизвестных " + (unknowncarsN - foundcars));
        }
    }
}
