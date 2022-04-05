using System;
using System.Drawing;
using System.IO;

namespace BotRestarter
{
    internal class CarSorter
    {
        public bool started = false;
        public void Sort()
        {
            started = true;
            NotePad.ClearLog();
            int unknowncarsN = 0;
            int lastcar = 2000;
            int x0 = 32;
            int y0 = 7;            
            int foundcars = 0;
            int predictcars = 0;
            for (int i = 1; i < 5; i++)
            {
                for (int i1 = 1; i1 < lastcar + 1; i1++)
                {
                    if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\unsorted" + i1 + ".jpg")) //несортированные
                    {
                        unknowncarsN++;
                        if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\" + i1 + "old.jpg"))
                        {
                            File.Move("C:\\Bot\\Finger" + (i + 1) + "\\" + i1 + "old.jpg", "C:\\Bot\\Finger" + (i + 1) + "\\old" + i1 + ".jpg");
                        }
                        Bitmap picture = new Bitmap("C:\\Bot\\Finger" + (i + 1) + "\\unsorted" + i1 + ".jpg");
                        Console.WriteLine("проверяю: позиция " + (i + 1) + ", unsorted " + i1);
                        for (int i0 = 1; i0 < lastcar; i0++)
                        {
                            if (File.Exists("C:\\Bot\\Finger1\\" + i0 + ".jpg"))
                            {
                                Bitmap picturetest = new Bitmap("C:\\Bot\\Finger1\\" + i0 + ".jpg");
                                int shadesdifs0 = 0;
                                for (int x = 0; x < 50; x++)
                                {
                                    for (int y = 0; y < 50; y++)
                                    {
                                        var colorValue0 = picture.GetPixel(x + x0, y + y0);
                                        var colorValue1 = picturetest.GetPixel(x + x0, y + y0);
                                        int shadesdifs1 = (Math.Abs((int)colorValue0.R - (int)colorValue1.R) +
                                            Math.Abs((int)colorValue0.G - (int)colorValue1.G) +
                                            Math.Abs((int)colorValue0.B - (int)colorValue1.B));
                                        shadesdifs0 += shadesdifs1;
                                    }
                                }
                                picture.Dispose();
                                if (shadesdifs0 < 40000)
                                {                                    
                                    NotePad.DoLog("");
                                    NotePad.DoLog("Считаю одинаковыми Finger" + (i + 1) + "\\unsorted" + i1);
                                    NotePad.DoLog("и Finger1\\" + i0);
                                    NotePad.DoLog("Различие в " + shadesdifs0 + " оттенков");
                                    if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\" + i0 + ".jpg"))
                                    {
                                        if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\old" + i0 + ".jpg"))
                                        {
                                            File.Delete("C:\\Bot\\Finger" + (i + 1) + "\\old" + i0 + ".jpg");
                                        }
                                        File.Move("C:\\Bot\\Finger" + (i + 1) + "\\" + i0 + ".jpg",
                                            "C:\\Bot\\Finger" + (i + 1) + "\\old" + i0 + ".jpg");
                                        NotePad.DoLog("Обновляю C:\\Bot\\Finger" + (i + 1) + "\\" + i0 + ".jpg" + i0);
                                        Console.WriteLine("Обновляю C:\\Bot\\Finger" + (i + 1) + "\\" + i0 + ".jpg" + i0);
                                    }
                                    File.Move("C:\\Bot\\Finger" + (i + 1) + "\\unsorted" + i1 + ".jpg",
                                        "C:\\Bot\\Finger" + (i + 1) + "\\" + i0 + ".jpg");
                                    foundcars++;
                                    break;
                                }
                                if (shadesdifs0 >= 40000 && shadesdifs0 < 60000)
                                {
                                    NotePad.DoLog("");
                                    NotePad.DoLog("Вероятно, одинаковые Finger" + (i + 1) + "\\unsorted" + i1);
                                    NotePad.DoLog("и Finger1\\" + i0);
                                    NotePad.DoLog("Различие в " + shadesdifs0 + " оттенков");
                                    if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\" + i0 + ".jpg"))
                                    {
                                        if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\old" + i0 + ".jpg"))
                                        {
                                            File.Delete("C:\\Bot\\Finger" + (i + 1) + "\\old" + i0 + ".jpg");
                                        }
                                        File.Move("C:\\Bot\\Finger" + (i + 1) + "\\" + i0 + ".jpg",
                                            "C:\\Bot\\Finger" + (i + 1) + "\\old" + i0 + ".jpg");
                                        NotePad.DoLog("Обновляю C:\\Bot\\Finger" + (i + 1) + "\\" + i0 + ".jpg" + i0);
                                        Console.WriteLine("Обновляю C:\\Bot\\Finger" + (i + 1) + "\\" + i0 + ".jpg" + i0);
                                    }
                                    File.Move("C:\\Bot\\Finger" + (i + 1) + "\\unsorted" + i1 + ".jpg",
                                        "C:\\Bot\\Finger" + (i + 1) + "\\" + i0 + ".jpg");
                                    predictcars++;
                                    break;
                                }
                                picturetest.Dispose();
                            }
                            else break;
                        }
                        picture.Dispose();
                    }
                }
            }

            NotePad.DoLogWithTime("найдено машин: " + foundcars);
            NotePad.DoLogWithTime("вероятных совпадений " + predictcars);
            NotePad.DoLogWithTime("осталось неизвестных " + (unknowncarsN - foundcars));
        }
    }
}
