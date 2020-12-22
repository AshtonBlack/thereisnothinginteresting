using System;
using System.Drawing;
using System.IO;

namespace WindowsFormsApp1 //universal but read info from txt files
{
    public class TrackInfo
    {
        Rectangle Track1 = new Rectangle(150, 525, 165, 35);
        Rectangle Track2 = new Rectangle(355, 525, 165, 35);
        Rectangle Track3 = new Rectangle(555, 525, 165, 35);
        Rectangle Track4 = new Rectangle(760, 525, 165, 35);
        Rectangle Track5 = new Rectangle(965, 525, 165, 35);

        Rectangle Ground1 = new Rectangle(198, 605, 115, 30);
        Rectangle Ground2 = new Rectangle(401, 605, 115, 30);
        Rectangle Ground3 = new Rectangle(605, 605, 115, 30);
        Rectangle Ground4 = new Rectangle(808, 605, 115, 30);
        Rectangle Ground5 = new Rectangle(1013, 605, 115, 30);

        Rectangle Weather1 = new Rectangle(198, 562, 75, 34);
        Rectangle Weather2 = new Rectangle(401, 562, 75, 34);
        Rectangle Weather3 = new Rectangle(605, 562, 75, 34);
        Rectangle Weather4 = new Rectangle(808, 562, 75, 34);
        Rectangle Weather5 = new Rectangle(1013, 562, 75, 34);

        public int[] Tracks()
        {            
            int n;
            bool flag;
            Rectangle[] a = { Track1, Track2, Track3, Track4, Track5 };
            int[] a1 = new int[5];

            for (int i = 0; i < 5; i++)
            {
                flag = true;
                MasterOfPictures.TrackCapture(a[i], ("Track" + (i + 1) + "\\test"));
                n = 0;
                for (int i1 = 1; i1 < 100; i1++)
                {
                    if (File.Exists("C:\\Bot\\Track" + (i + 1) + "\\" + i1 + ".jpg"))
                    {
                        n = i1;
                    }
                    else break;
                }

                for (int i2 = 1; i2 < (n + 1); i2++)
                {
                    if (MasterOfPictures.VerifyBW(("Track" + (i + 1) + "\\" + i2), ("Track" + (i + 1) + "\\test"), 120))
                    {
                        a1[i] = i2;
                        File.Delete("C:\\Bot\\Track" + (i + 1) + "\\test.jpg");
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    a1[i] = 0;
                    NotePad.DoLog("Добавляю новый трэк");
                    File.Move("C:\\Bot\\Track" + (i + 1) + "\\test.jpg", "C:\\Bot\\Track" + (i + 1) + "\\" + (n + 1) + ".jpg");
                }
            }

            return a1;
        }

        public int[] Grounds()
        {
            Rectangle[] b = { Ground1, Ground2, Ground3, Ground4, Ground5 };
            int n;
            bool flag;
            int[] b1 = new int[5];
            for (int i = 0; i < 5; i++)
            {
                flag = true;
                MasterOfPictures.BW2Capture(b[i], ("Ground" + (i + 1) + "\\test"));
                n = 0;
                for (int i1 = 1; i1 < 100; i1++)
                {
                    if (File.Exists("C:\\Bot\\Ground" + (i + 1) + "\\" + i1 + ".jpg"))
                    {
                        n = i1;
                    }
                    else break;
                }

                for (int i2 = 1; i2 < (n + 1); i2++)
                {
                    if (MasterOfPictures.VerifyBW(("Ground" + (i + 1) + "\\" + i2), ("Ground" + (i + 1) + "\\test"), 150))
                    {
                        b1[i] = i2;
                        File.Delete("C:\\Bot\\Ground" + (i + 1) + "\\test.jpg");
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    b1[i] = 0;
                    NotePad.DoLog("Добавляю новое покрытие");
                    File.Move("C:\\Bot\\Ground" + (i + 1) + "\\test.jpg", "C:\\Bot\\Ground" + (i + 1) + "\\" + (n + 1) + ".jpg");
                }
            }

            return b1;
        }

        public int[] Weathers()
        {
            Rectangle[] c = { Weather1, Weather2, Weather3, Weather4, Weather5 };
            int n;
            bool flag;
            int[] c1 = new int[5];

            for (int i = 0; i < 5; i++)
            {
                flag = true;
                MasterOfPictures.BW2Capture(c[i], ("Weather" + (i + 1) + "\\test"));
                n = 0;
                for (int i1 = 1; i1 < 10; i1++)
                {
                    if (File.Exists("C:\\Bot\\Weather" + (i + 1) + "\\" + i1 + ".jpg"))
                    {
                        n = i1;
                    }
                    else break;
                }

                for (int i2 = 1; i2 < (n + 1); i2++)
                {
                    if (MasterOfPictures.VerifyBW(("Weather" + (i + 1) + "\\" + i2), ("Weather" + (i + 1) + "\\test"), 30))
                    {
                        c1[i] = i2;
                        File.Delete("C:\\Bot\\Weather" + (i + 1) + "\\test.jpg");
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    c1[i] = 0;
                    NotePad.DoLog("Добавляю новую погоду");
                    File.Move("C:\\Bot\\Weather" + (i + 1) + "\\test.jpg", "C:\\Bot\\Weather" + (i + 1) + "\\" + (n + 1) + ".jpg");
                }
            }

            return c1;
        }

        public string[,] TrackPackage(string[] a2, string[] b2, string[] c2)
        {
            string[,] d = new string[3, 5];
            for (int i = 0; i < 5; i++)
            {
                d[0, i] = a2[i];
                d[1, i] = b2[i];
                d[2, i] = c2[i];
            }
            for (int i = 0; i < 5; i++)
            {
                NotePad.DoLog((i + 1) + " Трэк: " + d[0, i] + " " + d[1, i] + " " + d[2, i]);
            }

            return d;
        }

        public string[] IdentifyGround(int[] b1)
        {
            string[] b2 = new string[5];
            for (int i = 0; i < 5; i++)
            {
                string name = "unknown";
                int length = NotePad.GetInfoFileLength("C:\\Bot\\Ground" + (i + 1) + "\\info.txt");
                string[,] theTable = NotePad.ReadInfoFromTXT("C:\\Bot\\Ground" + (i + 1) + "\\info.txt");
                for (int l = 0; l < length; l++)
                {
                    if (b1[i] == Convert.ToInt32(theTable[l, 0]))
                    {
                        name = theTable[l, 1];
                        break;
                    }
                }
                if (name == "unknown")
                {
                    NotePad.DoErrorLog("Неизвестное покрытие позиция " + (i + 1));
                    b2[i] = "Неизвестная покрытие";
                }
            }

            bool asphalt = false;
            bool mud = false;

            foreach (string x in b2)
            {
                if (x == "Асфальт")
                {
                    asphalt  = true;
                }
                else
                {
                    mud = true;
                }
            }

            if (asphalt)
            {
                Condition.coverage = "Асфальт";
                if (mud) Condition.coverage = "Смешанное";
            }
            else Condition.coverage = "Бездорожье";
            NotePad.LastCoverage(Condition.coverage);
            return b2;
        }

        public string[] IdentifyWeather(int[] c1)
        {
            string[] c2 = new string[5];
            for (int i = 0; i < 5; i++)
            {
                string name = "unknown";
                int length = NotePad.GetInfoFileLength("C:\\Bot\\Weather" + (i + 1) + "\\info.txt");
                string[,] theTable = NotePad.ReadInfoFromTXT("C:\\Bot\\Weather" + (i + 1) + "\\info.txt");
                for (int l = 0; l < length; l++)
                {
                    if (c1[i] == Convert.ToInt32(theTable[l, 0]))
                    {
                        name = theTable[l, 1];
                        break;
                    }
                }
                if (name == "unknown")
                {
                    NotePad.DoErrorLog("Неизвестная погода позиция " + (i + 1));
                    c2[i] = "Неизвестная погода";
                }
            }

            bool dry = false;
            bool wet = false;

            foreach (string x in c2)
            {
                if (x == "Дождь")
                {
                    wet = true;
                }

                if (x == "Солнечно")
                {
                    dry = true;
                }
            }

            Condition.weather = "ясно";
            if (wet)
            {
                if (dry) Condition.weather = "с прояснением";
                else Condition.weather = "дождь";
            }
            NotePad.LastWeather(Condition.weather);

            return c2;
        }

        public string[] IdentifyTracks(int[] a1)
        {
            string[] a2 = new string[5];            

            for (int i = 0; i < 5; i++)
            {
                string name = "unknown";
                int length = NotePad.GetInfoFileLength("C:\\Bot\\Track" + (i + 1) + "\\info.txt");
                string[,] theTable = NotePad.ReadInfoFromTXT("C:\\Bot\\Track" + (i + 1) + "\\info.txt");
                for (int l = 0; l < length; l++)
                {
                    if (a1[i] == Convert.ToInt32(theTable[l, 0]))
                    {
                        name = theTable[l, 1];
                        break;
                    }
                }
                if (name == "unknown")
                {
                    NotePad.DoErrorLog("Неизвестная трасса позиция " + (i + 1));
                    a2[i] = "Неизвестная трасса";
                }                
            }
            return a2;
        }

        public int[] TrackRank(string[] a2)
        {
            int[] a3 = new int[5];
            string[] ar = {"Улица ср",
                            "Улица мал",
                            "Подъем на холм",
                            "Горы подъем на холм",
                            "Трасса для мотокросса",
                            "50-150",
                            "75-125",
                            "0-100",
                            "0-100-0",
                            "1",
                            "1/2",
                            "1/4",
                            "0-60",
                            "Токио трасса",
                            "Трасса набережная",
                            "Тестовый круг",
                            "Токио мостик",
                            "Нюрбург 1",
                            "Нюрбург 2",
                            "Нюрбург 3",
                            "Нюрбург 4",
                            "Нюрбург 5",
                            "Токио петля",
                            "Горная экспедиция",
                            "Горы дорога с уклоном",
                            "Замерзшее озеро",
                            "Горы серпантин",
                            "Горы извилистая дорога",
                            "Извилистая дорога",
                            "Быстрая трасса",
                            "Highway",
                            "Монако длинные городские улицы",
                            "Каньон экспедиция",
                            "Серпантин",
                            "Монако серпантин",
                            "Извилистая трасса",
                            "Токио мост",
                            "Токио съезд",
                            "Монако городские",
                            "Обзор",
                            "Каньон грунтовая дорога",
                            "Каньон крутой холм",
                            "Лесная переправа",
                            "Ралли-кросс мал",
                            "Ралли-кросс ср",
                            "Лесная дорога",
                            "Монако узкие улицы",
                            "Монако тест на перегрузки",
                            "Токио тест на перегрузки",
                            "Трасса для картинга",
                            "Парковка",
                            "Лесной слалом",
                            "Закрытый картинг",
                            "Горы слалом",
                            "Слалом",
                            "Перегрузка",
                            "Неизвестная трасса"
            };//иерархия трасс
            for (int i = 0; i < 5; ++i)
            {
                int flag = 0;
                for (int j = 0; j < ar.Length; ++j)
                {
                    if (a2[i] == ar[j])
                    {
                        a3[i] = j + 1;
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    NotePad.DoErrorLog("Исправить название " + a2[i]);
                    a3[i] = 100;
                }
            }
            return a3;
        }        
    }
}