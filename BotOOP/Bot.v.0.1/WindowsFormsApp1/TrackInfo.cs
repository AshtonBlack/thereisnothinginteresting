using System.Drawing;
using System.IO;

namespace WindowsFormsApp1
{
    public class TrackInfo
    {
        public int[] Tracks()
        {
            Rectangle Track1 = new Rectangle(150, 525, 165, 35);
            Rectangle Track2 = new Rectangle(355, 525, 165, 35);
            Rectangle Track3 = new Rectangle(555, 525, 165, 35);
            Rectangle Track4 = new Rectangle(760, 525, 165, 35);
            Rectangle Track5 = new Rectangle(965, 525, 165, 35);

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
            Rectangle Ground1 = new Rectangle(198, 605, 115, 30);
            Rectangle Ground2 = new Rectangle(401, 605, 115, 30);
            Rectangle Ground3 = new Rectangle(605, 605, 115, 30);
            Rectangle Ground4 = new Rectangle(808, 605, 115, 30);
            Rectangle Ground5 = new Rectangle(1013, 605, 115, 30);

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
            Rectangle Weather1 = new Rectangle(198, 562, 75, 34);
            Rectangle Weather2 = new Rectangle(401, 562, 75, 34);
            Rectangle Weather3 = new Rectangle(605, 562, 75, 34);
            Rectangle Weather4 = new Rectangle(808, 562, 75, 34);
            Rectangle Weather5 = new Rectangle(1013, 562, 75, 34);

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
                switch (i)
                {
                    case 0:
                        switch (b1[i])
                        {
                            case 1:
                                b2[i] = "Асфальт";
                                break;
                            case 2:
                                b2[i] = "Грунт";
                                break;
                            case 3:
                                b2[i] = "Трава";
                                break;
                            case 4:
                                b2[i] = "Гравий";
                                break;
                            case 5:
                                b2[i] = "Песок";
                                break;
                            case 6:
                                b2[i] = "Снег";
                                break;
                            case 7:
                                b2[i] = "Лед";
                                break;
                            case 8:
                                b2[i] = "Смешанное";
                                break;
                            case 9:
                                b2[i] = "Смешанное";
                                break;
                            case 12:
                                b2[i] = "Асфальт";
                                break;
                            case 14:
                                b2[i] = "Асфальт";
                                break;
                            case 15:
                                b2[i] = "Асфальт";
                                break;
                            case 16:
                                b2[i] = "Снег";
                                break;
                            default:
                                b2[i] = "неизвестное покрытие";
                                break;
                        }
                        break;
                    case 1:
                        switch (b1[i])
                        {
                            case 1:
                                b2[i] = "Асфальт";
                                break;
                            case 2:
                                b2[i] = "Грунт";
                                break;
                            case 3:
                                b2[i] = "Трава";
                                break;
                            case 4:
                                b2[i] = "Гравий";
                                break;
                            case 5:
                                b2[i] = "Песок";
                                break;
                            case 6:
                                b2[i] = "Смешанное";
                                break;
                            case 7:
                                b2[i] = "Снег";
                                break;
                            case 8:
                                b2[i] = "Лед";
                                break;
                            case 9:
                                b2[i] = "Асфальт";
                                break;
                            case 10:
                                b2[i] = "Асфальт";
                                break;
                            default:
                                b2[i] = "неизвестное покрытие";
                                break;
                        }
                        break;
                    case 2:
                        switch (b1[i])
                        {
                            case 1:
                                b2[i] = "Асфальт";
                                break;
                            case 2:
                                b2[i] = "Трава";
                                break;
                            case 3:
                                b2[i] = "Грунт";
                                break;
                            case 4:
                                b2[i] = "Гравий";
                                break;
                            case 5:
                                b2[i] = "Снег";
                                break;
                            case 6:
                                b2[i] = "Песок";
                                break;
                            case 7:
                                b2[i] = "Смешанное";
                                break;
                            case 8:
                                b2[i] = "Лед";
                                break;
                            case 9:
                                b2[i] = "Асфальт";
                                break;
                            case 10:
                                b2[i] = "Песок";
                                break;
                            default:
                                b2[i] = "неизвестное покрытие";
                                break;
                        }
                        break;
                    case 3:
                        switch (b1[i])
                        {
                            case 1:
                                b2[i] = "Асфальт";
                                break;
                            case 2:
                                b2[i] = "Трава";
                                break;
                            case 3:
                                b2[i] = "Грунт";
                                break;
                            case 4:
                                b2[i] = "Снег";
                                break;
                            case 5:
                                b2[i] = "Песок";
                                break;
                            case 6:
                                b2[i] = "Смешанное";
                                break;
                            case 7:
                                b2[i] = "Гравий";
                                break;
                            case 8:
                                b2[i] = "Лед";
                                break;
                            case 9:
                                b2[i] = "Асфальт";
                                break;
                            default:
                                b2[i] = "неизвестное покрытие";
                                break;
                        }
                        break;
                    case 4:
                        switch (b1[i])
                        {
                            case 1:
                                b2[i] = "Асфальт";
                                break;
                            case 2:
                                b2[i] = "Грунт";
                                break;
                            case 3:
                                b2[i] = "Гравий";
                                break;
                            case 4:
                                b2[i] = "Снег";
                                break;
                            case 5:
                                b2[i] = "Песок";
                                break;
                            case 6:
                                b2[i] = "Смешанное";
                                break;
                            case 7:
                                b2[i] = "Лед";
                                break;
                            default:
                                b2[i] = "неизвестное покрытие";
                                break;
                        }
                        break;
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
                switch (i)
                {
                    case 0:
                        switch (c1[i])
                        {
                            case 1:
                                c2[i] = "Солнечно";
                                break;
                            case 2:
                                c2[i] = "Дождь";
                                break;
                            case 3:
                                c2[i] = "Солнечно";
                                break;
                            case 4:
                                c2[i] = "Солнечно";
                                break;
                            case 5:
                                c2[i] = "Дождь";
                                break;
                            default:
                                c2[i] = "неопределенная погода";
                                break;
                        }
                        break;
                    case 1:
                        switch (c1[i])
                        {
                            case 1:
                                c2[i] = "Солнечно";
                                break;
                            case 2:
                                c2[i] = "Дождь";
                                break;
                            case 3:
                                c2[i] = "Солнечно";
                                break;
                            case 4:
                                c2[i] = "Солнечно";
                                break;
                            case 5:
                                c2[i] = "Солнечно";
                                break;
                            case 6:
                                c2[i] = "Дождь";
                                break;
                            case 7:
                                c2[i] = "Дождь";
                                break;
                            default:
                                c2[i] = "неопределенная погода";
                                break;
                        }
                        break;
                    case 2:
                        switch (c1[i])
                        {
                            case 1:
                                c2[i] = "Солнечно";
                                break;
                            case 2:
                                c2[i] = "Дождь";
                                break;
                            case 3:
                                c2[i] = "Солнечно";
                                break;
                            case 4:
                                c2[i] = "Солнечно";
                                break;
                            case 5:
                                c2[i] = "Дождь";
                                break;
                            default:
                                c2[i] = "неопределенная погода";
                                break;
                        }
                        break;
                    case 3:
                        switch (c1[i])
                        {
                            case 1:
                                c2[i] = "Солнечно";
                                break;
                            case 2:
                                c2[i] = "Дождь";
                                break;
                            case 3:
                                c2[i] = "Солнечно";
                                break;
                            case 4:
                                c2[i] = "Солнечно";
                                break;
                            case 5:
                                c2[i] = "Дождь";
                                break;
                            case 6:
                                c2[i] = "Солнечно";
                                break;
                            case 7:
                                c2[i] = "Солнечно";
                                break;
                            case 8:
                                c2[i] = "Дождь";
                                break;
                            default:
                                c2[i] = "неопределенная погода";
                                break;
                        }
                        break;
                    case 4:
                        switch (c1[i])
                        {
                            case 1:
                                c2[i] = "Солнечно";
                                break;
                            case 2:
                                c2[i] = "Дождь";
                                break;
                            case 3:
                                c2[i] = "Солнечно";
                                break;
                            case 4:
                                c2[i] = "Солнечно";
                                break;
                            case 5:
                                c2[i] = "Дождь";
                                break;
                            case 6:
                                c2[i] = "Солнечно";
                                break;
                            case 7:
                                c2[i] = "Солнечно";
                                break;
                            case 8:
                                c2[i] = "Дождь";
                                break;
                            default:
                                c2[i] = "неопределенная погода";
                                break;
                        }
                        break;
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
                switch (i)
                {
                    case 0:
                        switch (a1[i])
                        {
                            case 1:
                                a2[i] = "Улица мал";
                                break;
                            case 2:
                                a2[i] = "Лесной слалом";
                                break;
                            case 3:
                                a2[i] = "0-100";
                                break;
                            case 4:
                                a2[i] = "1/2";
                                break;
                            case 5:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 6:
                                a2[i] = "Серпантин";
                                break;
                            case 7:
                                a2[i] = "Слалом";
                                break;
                            case 8:
                                a2[i] = "Подъем на холм";
                                break;
                            case 9:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 10:
                                a2[i] = "1";
                                break;
                            case 11:
                                a2[i] = "0-100-0";
                                break;
                            case 12:
                                a2[i] = "Парковка";
                                break;
                            case 13:
                                a2[i] = "Улица ср";
                                break;
                            case 14:
                                a2[i] = "Highway";
                                break;
                            case 15:
                                a2[i] = "Перегрузка";
                                break;
                            case 16:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 17:
                                a2[i] = "Тестовый круг";
                                break;
                            case 18:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 19:
                                a2[i] = "Мотокросс";
                                break;
                            case 20:
                                a2[i] = "Токио тест на перегрузки";
                                break;
                            case 21:
                                a2[i] = "Токио петля";
                                break;
                            case 22:
                                a2[i] = "Каньон экспедиция";
                                break;
                            case 23:
                                a2[i] = "Обзор";
                                break;
                            case 24:
                                a2[i] = "Лесная дорога";
                                break;
                            case 25:
                                a2[i] = "Трасса набережная";
                                break;
                            case 26:
                                a2[i] = "Токио мостик";
                                break;
                            case 27:
                                a2[i] = "Токио трасса";
                                break;
                            case 28:
                                a2[i] = "Токио мост";
                                break;
                            case 29:
                                a2[i] = "Ралли-кросс мал";
                                break;
                            case 30:
                                a2[i] = "Монако городские";
                                break;
                            case 31:
                                a2[i] = "Монако серпантин";
                                break;
                            case 32:
                                a2[i] = "Ралли-кросс ср";
                                break;
                            case 33:
                                a2[i] = "Каньон крутой холм";
                                break;
                            case 34:
                                a2[i] = "Лесная переправа";
                                break;
                            case 35:
                                a2[i] = "Монако узкие улицы";
                                break;
                            case 36:
                                a2[i] = "Горная экспедиция";
                                break;
                            case 37:
                                a2[i] = "Горы извилистая дорога";
                                break;
                            case 38:
                                a2[i] = "Нюрбург 1";
                                break;
                            case 39:
                                a2[i] = "Горы извилистая дорога";
                                break;
                            case 40:
                                a2[i] = "Горы слалом";
                                break;
                            default:
                                a2[i] = "Неизвестная трасса";
                                break;
                        }
                        break;
                    case 1:
                        switch (a1[i])
                        {
                            case 1:
                                a2[i] = "0-100";
                                break;
                            case 2:
                                a2[i] = "1/2";
                                break;
                            case 3:
                                a2[i] = "Лесная дорога";
                                break;
                            case 4:
                                a2[i] = "Лесной слалом";
                                break;
                            case 5:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 6:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 7:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 8:
                                a2[i] = "Улица мал";
                                break;
                            case 9:
                                a2[i] = "Улица ср";
                                break;
                            case 10:
                                a2[i] = "1";
                                break;
                            case 11:
                                a2[i] = "Мотокросс";
                                break;
                            case 12:
                                a2[i] = "Слалом";
                                break;
                            case 13:
                                a2[i] = "Перегрузка";
                                break;
                            case 14:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 15:
                                a2[i] = "Серпантин";
                                break;
                            case 16:
                                a2[i] = "Закрытый картинг";
                                break;
                            case 17:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 18:
                                a2[i] = "Слалом";
                                break;
                            case 19:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 20:
                                a2[i] = "Замерзшее озеро";
                                break;
                            case 21:
                                a2[i] = "Подъем на холм";
                                break;
                            case 22:
                                a2[i] = "0-100-0";
                                break;
                            case 23:
                                a2[i] = "Тестовый круг";
                                break;
                            case 24:
                                a2[i] = "Ралли-кросс мал";
                                break;
                            case 25:
                                a2[i] = "Токио тест на перегрузки";
                                break;
                            case 26:
                                a2[i] = "Токио мост";
                                break;
                            case 27:
                                a2[i] = "Каньон грунтовая дорога";
                                break;
                            case 28:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 29:
                                a2[i] = "Грунтовая дорога";
                                break;
                            case 30:
                                a2[i] = "1/2";
                                break;
                            case 31:
                                a2[i] = "Токио съезд";
                                break;
                            case 32:
                                a2[i] = "Закрытый картинг";
                                break;
                            case 33:
                                a2[i] = "Highway";
                                break;
                            case 34:
                                a2[i] = "Подъем на холм";
                                break;
                            case 35:
                                a2[i] = "Монако тест на перегрузки";
                                break;
                            case 36:
                                a2[i] = "Монако серпантин";
                                break;
                            case 37:
                                a2[i] = "Парковка";
                                break;
                            case 38:
                                a2[i] = "Монако узкие улицы";
                                break;
                            case 39:
                                a2[i] = "Трасса набережная";
                                break;
                            case 40:
                                a2[i] = "Перегрузка";
                                break;
                            case 41:
                                a2[i] = "Ралли-кросс ср";
                                break;
                            case 42:
                                a2[i] = "Замерзшее озеро";
                                break;
                            case 43:
                                a2[i] = "Лесная переправа";
                                break;
                            case 44:
                                a2[i] = "Горы слалом";
                                break;
                            case 45:
                                a2[i] = "Нюрбург 2";
                                break;
                            case 46:
                                a2[i] = "Горы серпантин";
                                break;
                            case 47:
                                a2[i] = "Горы извилистая дорога";
                                break;
                            default:
                                a2[i] = "Неизвестная трасса";
                                break;
                        }
                        break;
                    case 2:
                        switch (a1[i])
                        {
                            case 1:
                                a2[i] = "Перегрузка";
                                break;
                            case 2:
                                a2[i] = "Лесная дорога";
                                break;
                            case 3:
                                a2[i] = "Лесной слалом";
                                break;
                            case 4:
                                a2[i] = "Серпантин";
                                break;
                            case 5:
                                a2[i] = "Закрытый картинг";
                                break;
                            case 6:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 7:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 8:
                                a2[i] = "1/2";
                                break;
                            case 9:
                                a2[i] = "Слалом";
                                break;
                            case 10:
                                a2[i] = "Подъем на холм";
                                break;
                            case 11:
                                a2[i] = "1";
                                break;
                            case 12:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 13:
                                a2[i] = "Улица мал";
                                break;
                            case 14:
                                a2[i] = "Парковка";
                                break;
                            case 15:
                                a2[i] = "Слалом";
                                break;
                            case 16:
                                a2[i] = "Улица ср";
                                break;
                            case 17:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 18:
                                a2[i] = "Highway";
                                break;
                            case 19:
                                a2[i] = "0-100-0";
                                break;
                            case 20:
                                a2[i] = "Токио тест на перегрузки";
                                break;
                            case 21:
                                a2[i] = "0-100";
                                break;
                            case 22:
                                a2[i] = "1/4";
                                break;
                            case 23:
                                a2[i] = "Тестовый круг";
                                break;
                            case 24:
                                a2[i] = "Токио мост";
                                break;
                            case 25:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 26:
                                a2[i] = "Крутой холм";
                                break;
                            case 27:
                                a2[i] = "Грунтовая дорога";
                                break;
                            case 28:
                                a2[i] = "Монако узкие улицы";
                                break;
                            case 29:
                                a2[i] = "75-125";
                                break;
                            case 30:
                                a2[i] = "Мотокросс";
                                break;
                            case 31:
                                a2[i] = "Токио мостик";
                                break;
                            case 32:
                                a2[i] = "Трасса набережная";
                                break;
                            case 33:
                                a2[i] = "Ралли-кросс мал";
                                break;
                            case 34:
                                a2[i] = "Ралли-кросс ср";
                                break;
                            case 35:
                                a2[i] = "Монако длинные городские улицы";
                                break;
                            case 36:
                                a2[i] = "Каньон грунтовая дорога";
                                break;
                            case 37:
                                a2[i] = "Лесная переправа";
                                break;
                            case 38:
                                a2[i] = "Закрытый картинг";
                                break;
                            case 39:
                                a2[i] = "Монако городские";
                                break;
                            case 40:
                                a2[i] = "Горы слалом";
                                break;
                            case 41:
                                a2[i] = "Нюрбург 3";
                                break;
                            case 42:
                                a2[i] = "1/4";
                                break;
                            case 43:
                                a2[i] = "Горы извилистая дорога";
                                break;
                            default:
                                a2[i] = "Неизвестная трасса";
                                break;
                        }
                        break;
                    case 3:
                        switch (a1[i])
                        {
                            case 1:
                                a2[i] = "Улица ср";
                                break;
                            case 2:
                                a2[i] = "Лесной слалом";
                                break;
                            case 3:
                                a2[i] = "1/4";
                                break;
                            case 4:
                                a2[i] = "Лесная дорога";
                                break;
                            case 5:
                                a2[i] = "Перегрузка";
                                break;
                            case 6:
                                a2[i] = "Слалом";
                                break;
                            case 7:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 8:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 9:
                                a2[i] = "1";
                                break;
                            case 10:
                                a2[i] = "Улица мал";
                                break;
                            case 11:
                                a2[i] = "Замерзшее озеро";
                                break;
                            case 12:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 13:
                                a2[i] = "Серпантин";
                                break;
                            case 14:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 15:
                                a2[i] = "Парковка";
                                break;
                            case 16:
                                a2[i] = "0-100-0";
                                break;
                            case 17:
                                a2[i] = "Слалом";
                                break;
                            case 18:
                                a2[i] = "Тестовый круг";
                                break;
                            case 19:
                                a2[i] = "1/2";
                                break;
                            case 20:
                                a2[i] = "Ралли-кросс ср";
                                break;
                            case 21:
                                a2[i] = "Токио петля";
                                break;
                            case 22:
                                a2[i] = "Подъем на холм";
                                break;
                            case 23:
                                a2[i] = "Токио съезд";
                                break;
                            case 24:
                                a2[i] = "Токио тест на перегрузки";
                                break;
                            case 25:
                                a2[i] = "Каньон экспедиция";
                                break;
                            case 26:
                                a2[i] = "0-100";
                                break;
                            case 27:
                                a2[i] = "Грунтовая дорога";
                                break;
                            case 28:
                                a2[i] = "Лесная дорога";
                                break;
                            case 29:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 30:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 31:
                                a2[i] = "Токио трасса";
                                break;
                            case 32:
                                a2[i] = "Монако серпантин";
                                break;
                            case 33:
                                a2[i] = "Трасса набережная";
                                break;
                            case 34:
                                a2[i] = "Монако узкие улицы";
                                break;
                            case 35:
                                a2[i] = "Мотокросс";
                                break;
                            case 36:
                                a2[i] = "75-125";
                                break;
                            case 37:
                                a2[i] = "Слалом";
                                break;
                            case 38:
                                a2[i] = "Перегрузка";
                                break;
                            case 39:
                                a2[i] = "Горы серпантин";
                                break;
                            case 40:
                                a2[i] = "Нюрбург 4";
                                break;
                            case 41:
                                a2[i] = "Горы слалом";
                                break;
                            default:
                                a2[i] = "Неизвестная трасса";
                                break;
                        }
                        break;
                    case 4:
                        switch (a1[i])
                        {
                            case 1:
                                a2[i] = "1/2";
                                break;
                            case 2:
                                a2[i] = "Серпантин";
                                break;
                            case 3:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 4:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 5:
                                a2[i] = "Лесная дорога";
                                break;
                            case 6:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 7:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 8:
                                a2[i] = "Улица ср";
                                break;
                            case 9:
                                a2[i] = "Улица мал";
                                break;
                            case 10:
                                a2[i] = "Подъем на холм";
                                break;
                            case 11:
                                a2[i] = "Тестовый круг";
                                break;
                            case 12:
                                a2[i] = "0-100-0";
                                break;
                            case 13:
                                a2[i] = "Парковка";
                                break;
                            case 14:
                                a2[i] = "50-150";
                                break;
                            case 15:
                                a2[i] = "1";
                                break;
                            case 16:
                                a2[i] = "Highway";
                                break;
                            case 17:
                                a2[i] = "Слалом";
                                break;
                            case 18:
                                a2[i] = "Перегрузка";
                                break;
                            case 19:
                                a2[i] = "Перегрузка";
                                break;
                            case 20:
                                a2[i] = "Токио мост";
                                break;
                            case 21:
                                a2[i] = "Закрытый картинг";
                                break;
                            case 22:
                                a2[i] = "Слалом";
                                break;
                            case 23:
                                a2[i] = "Токио съезд";
                                break;
                            case 24:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 25:
                                a2[i] = "Обзор";
                                break;
                            case 26:
                                a2[i] = "Крутой холм";
                                break;
                            case 27:
                                a2[i] = "Лесной слалом";
                                break;
                            case 28:
                                a2[i] = "Токио трасса";
                                break;
                            case 29:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 30:
                                a2[i] = "Токио петля";
                                break;
                            case 31:
                                a2[i] = "Токио тест на перегрузки";
                                break;
                            case 32:
                                a2[i] = "Монако серпантин";
                                break;
                            case 33:
                                a2[i] = "Монако городские";
                                break;
                            case 34:
                                a2[i] = "Монако тест на перегрузки";
                                break;
                            case 35:
                                a2[i] = "Трасса набережная";
                                break;
                            case 36:
                                a2[i] = "0-100";
                                break;
                            case 37:
                                a2[i] = "Ралли-кросс мал";
                                break;
                            case 38:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 39:
                                a2[i] = "Мотокросс";
                                break;
                            case 40:
                                a2[i] = "Обзор";
                                break;
                            case 41:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 42:
                                a2[i] = "Лесная переправа";
                                break;
                            case 43:
                                a2[i] = "Монако длинные городские улицы";
                                break;
                            case 44:
                                a2[i] = "Лесная переправа";
                                break;
                            case 45:
                                a2[i] = "Подъем на холм";
                                break;
                            case 46:
                                a2[i] = "Горы извилистая дорога";
                                break;
                            case 47:
                                a2[i] = "Горы слалом";
                                break;
                            case 48:
                                a2[i] = "Нюрбург 5";
                                break;
                            case 49:
                                a2[i] = "1";
                                break;
                            default:
                                a2[i] = "Неизвестная трасса";
                                break;
                        }
                        break;
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
                            "Мотокросс",
                            "50-150",
                            "75-125",
                            "0-100",
                            "0-100-0",
                            "1",
                            "1/2",
                            "1/4",
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
                            "Грунтовая дорога",
                            "Каньон крутой холм",
                            "Лесная переправа",
                            "Ралли-кросс мал",
                            "Ралли-кросс ср",
                            "Крутой холм",
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