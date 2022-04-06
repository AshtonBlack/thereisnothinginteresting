using System;
using System.Drawing;
using System.IO;

namespace BotRestarter
{
    internal class CarSorter
    {
        public bool started = false;
        int unknowncarsN = 0;
        int lastcar = 2000;
        int x0 = 32;
        int y0 = 7;
        int foundcars = 0;
        int predictcars = 0;
        void UpdatePicture(int fingerN, int unsortedPictureN, int pictureInFinger1)
        {
            if (File.Exists("C:\\Bot\\Finger" + fingerN + "\\" + pictureInFinger1 + ".jpg"))
            {
                if (File.Exists("C:\\Bot\\Finger" + fingerN + "\\old" + pictureInFinger1 + ".jpg"))
                {
                    File.Delete("C:\\Bot\\Finger" + fingerN + "\\old" + pictureInFinger1 + ".jpg");
                }
                File.Move("C:\\Bot\\Finger" + fingerN + "\\" + pictureInFinger1 + ".jpg",
                    "C:\\Bot\\Finger" + fingerN + "\\old" + pictureInFinger1 + ".jpg");
                NotePad.DoLog("Обновляю C:\\Bot\\Finger" + fingerN + "\\" + pictureInFinger1 + ".jpg");
            }
            File.Move("C:\\Bot\\Finger" + fingerN + "\\unsorted" + unsortedPictureN + ".jpg",
                "C:\\Bot\\Finger" + fingerN + "\\" + pictureInFinger1 + ".jpg");
        }
        public void Sort()
        {
            started = true;
            NotePad.ClearLog();            
            for (int fingerN = 2; fingerN < 6; fingerN++)
            {
                for (int unsortedPictureN = 1; unsortedPictureN < lastcar + 1; unsortedPictureN++)
                {
                    string unsortedPicture = "C:\\Bot\\Finger" + fingerN + "\\unsorted" + unsortedPictureN + ".jpg";
                    if (File.Exists(unsortedPicture)) //несортированные
                    {
                        unknowncarsN++;
                        Bitmap picture = new Bitmap(unsortedPicture);
                        for (int pictureInFinger1 = 1; pictureInFinger1 < lastcar; pictureInFinger1++)
                        {
                            string testPictureFromFinger1 = "C:\\Bot\\Finger1\\" + pictureInFinger1 + ".jpg";
                            if (File.Exists(testPictureFromFinger1))
                            {
                                Bitmap picturetest = new Bitmap(testPictureFromFinger1);
                                int shadesdifs = 0;
                                for (int x = 0; x < 50; x++)
                                {
                                    for (int y = 0; y < 50; y++)
                                    {
                                        var colorValue0 = picture.GetPixel(x + x0, y + y0);
                                        var colorValue1 = picturetest.GetPixel(x + x0, y + y0);
                                        shadesdifs += (Math.Abs((int)colorValue0.R - (int)colorValue1.R) +
                                            Math.Abs((int)colorValue0.G - (int)colorValue1.G) +
                                            Math.Abs((int)colorValue0.B - (int)colorValue1.B));
                                    }
                                }                                
                                picturetest.Dispose();
                                if (shadesdifs < 60000)
                                {
                                    picture.Dispose();
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
                                    NotePad.DoLog("Finger" + fingerN + "\\unsorted" + unsortedPictureN + " и Finger1\\" + pictureInFinger1);
                                    NotePad.DoLog("Различие в " + shadesdifs + " оттенков");
                                    UpdatePicture(fingerN, unsortedPictureN, pictureInFinger1);
                                    break;
                                }                                
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
