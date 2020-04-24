using System;
using System.Drawing;
using System.IO;
using System.Threading;

namespace WindowsFormsApp1
{
    public class HandMaking
    {
        public int[] ConditionHandling()
        {
            int[] rqclass = new int[] { 6, 10, 14, 18, 22, 26, 30 }; //рк для классов 
            int[,] hand = new int[5, 7];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    hand[i, j] = rqclass[j];
                }
            }

            Random r = new Random();
            int handrq = 0;
            int actualRQ = Condition.ActualRQ();
            NotePad.DoLog("Искомое РК " + actualRQ);
            
            int[] finger = Condition.LowestClassCars();
            for (int x = 0; x < 5; x++)
            {
                handrq += hand[x, finger[x]];
            }
            int n;
            while( actualRQ - handrq > 3)
            {
                do
                {
                    n = r.Next(0, 5);
                } while (finger[n] == Condition.maxclass);
                finger[n]++;
                NotePad.DoLog("увеличил карту номер " + n);
                handrq += 4;
                NotePad.DoLog("текущее рк руки " + handrq);
            }
            NotePad.DoLog("требуемое рк: " + Condition.eventrq + ";   рк руки: " + handrq);            

            for (int l = 0; l < 4; l++)
            {
                for (int l1 = 0; l1 < (4 - l); l1++)
                    if (finger[l1] > finger[l1 + 1])
                    {
                        int remember = finger[l1];
                        finger[l1] = finger[l1 + 1];
                        finger[l1 + 1] = remember;
                    }
            }//сортировка карт по возрастанию

            int[] classcars = { 0, 0, 0, 0, 0, 0, 0 };            
            for (int k = 0; k < finger.Length; k++)
            {
                classcars[finger[k]]++;
            }
            return classcars;
        }

        public void MakingHand(int eventname)
        {
            FastCheck fc = new FastCheck();            

            int[] classcars = ConditionHandling();
            Thread.Sleep(1000);

            int var; //недобор
            int usedhandslots = 0;
            if (Condition.conditionNumber != 0 && Condition.conditionNumber != 3 && Condition.conditionNumber != 36 && !fc.ConditionActivated()) 
                Rat.Clk(640, 265); //включить фильтр условия события. Исключения: нет условий, 3 машины одной редкости, фильтр включен              
            char[] cls = { 's', 'a', 'b', 'c', 'd', 'e', 'f' };
            for (int i = 0; i < 7; i++)
            {
                if (classcars[i] > 0)
                {
                    if (i == 6)//для серых нет возврата недобора
                    {
                        Randomizer();
                        UseFilter(cls[i], classcars[i], usedhandslots);
                    }
                    else
                    {
                        Randomizer();
                        var = UseFilter(cls[i], classcars[i], usedhandslots);
                        usedhandslots += classcars[i] - var;
                        classcars[i + 1] += var;
                    }
                }
            }//механизм расстановки

            if (VerifyHand())
            {
                int[] carsid = RememberHand();
                NotePad.Saves(eventname, carsid);
            } //сохранение руки
        }

        public bool CarFixed(int slot)//величины не исправлены с версии 0.04
        {
            string path = "Check//";
            Rectangle Car1Bounds = new Rectangle(400, 370, 200, 20);
            Rectangle Car2Bounds = new Rectangle(400, 560, 200, 20);
            Rectangle Car3Bounds = new Rectangle(705, 370, 200, 20);
            Rectangle Car4Bounds = new Rectangle(705, 560, 200, 20);

            Rectangle Car5Bounds = new Rectangle(635, 370, 200, 20);
            Rectangle Car6Bounds = new Rectangle(635, 560, 200, 20);

            Rectangle Car7Bounds = new Rectangle(635, 370, 200, 20);
            Rectangle Car8Bounds = new Rectangle(635, 560, 200, 20);
            ///---------
            Rectangle Car9Bounds = new Rectangle(655, 370, 200, 20);
            Rectangle Car10Bounds = new Rectangle(655, 560, 200, 20);
            Rectangle[] bounds = new Rectangle[] { Car1Bounds, Car2Bounds, Car3Bounds, Car4Bounds, Car5Bounds, Car6Bounds, Car7Bounds, Car8Bounds, Car9Bounds, Car10Bounds };
            string[] n = new string[] { "1car", "2car", "3car", "4car", "5car", "6car", "7car", "8car", "9car", "10car" };
            MasterOfPictures.MakePicture(bounds[slot], path + n[slot] + "0");
            Thread.Sleep(2000);
            MasterOfPictures.MakePicture(bounds[slot], path + n[slot] + "1");
            return MasterOfPictures.Verify(path + n[slot] + "0", path + n[slot] + "1");
        }

        public bool HandCarFixed()//перепроверить величины
        {
            string path = "Check//";
            Rectangle finger1Bounds = new Rectangle(85, 725, 115, 65);//перепроверить величины
            Rectangle finger2Bounds = new Rectangle(280, 725, 115, 65);//перепроверить величины
            Rectangle finger3Bounds = new Rectangle(470, 725, 115, 65);//перепроверить величины
            Rectangle finger4Bounds = new Rectangle(660, 725, 115, 65);//перепроверить величины
            Rectangle finger5Bounds = new Rectangle(850, 725, 115, 65);//перепроверить величины
            bool x = true;
            Rectangle[] bounds = new Rectangle[] { finger1Bounds, finger2Bounds, finger3Bounds, finger4Bounds, finger5Bounds };
            string[] n = new string[] { "finger1", "finger2", "finger3", "finger4", "finger5" };
            for (int i = 0; i < 5; i++)
            {
                MasterOfPictures.MakePicture(bounds[i], path + n[i] + "0");
            }
            Thread.Sleep(1700);
            for (int j = 0; j < 5; j++)
            {
                MasterOfPictures.MakePicture(bounds[j], path + n[j] + "1");
            }

            for (int k = 0; k < 5; k++)
            {
                if (!MasterOfPictures.Verify(path + n[k] + "0", path + n[k] + "1"))
                {
                    NotePad.DoLog("Тачка на " + (k + 1) + " месте неисправна");
                    x = false;
                    break;
                }
            }
            return x;
        }

        public bool VerifyHand()
        {
            FastCheck fc = new FastCheck();

            Point HandSlot1 = new Point(160, 775);
            Point HandSlot2 = new Point(355, 775);
            Point HandSlot3 = new Point(545, 775);
            Point HandSlot4 = new Point(740, 775);
            Point HandSlot5 = new Point(930, 775);
            Point[] a = { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };
            bool x = true;
            string emptyslot = "Color [A=255, R=200, G=200, B=200]";
            Thread.Sleep(2000);

            for (int i = 0; i < 5; i++)
            {
                if (MasterOfPictures.PixelIndicator(a[i]) == emptyslot)
                {
                    NotePad.DoLog("Тачка на " + a[i] + " позиции отсутствует");
                    x = false;
                    break;
                }
            }

            if (fc.RedReadytoRace())
            {
                NotePad.DoLog("Рука не соответствует условию");
                x = false;
            }

            return x;
        }

        public int[] RememberHand()
        {
            Rectangle HandSlot1 = new Rectangle(85, 725, 115, 65);
            Rectangle HandSlot2 = new Rectangle(277, 725, 115, 65);
            Rectangle HandSlot3 = new Rectangle(469, 725, 115, 65);
            Rectangle HandSlot4 = new Rectangle(661, 725, 115, 65);
            Rectangle HandSlot5 = new Rectangle(853, 725, 115, 65);
            string carsDB = "Finger";
            int lastcar = 1000;
            int[] carsid = new int[5];
            bool flag;
            Rectangle[] b = { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };

            for (int i = 0; i < 5; i++)
            {
                MasterOfPictures.MakePicture(b[i], (carsDB + (i + 1) + "\\test"));
                flag = true;

                if (i == 0)//для первого пальца
                {
                    int maxknowncar = 0;
                    for (int i2 = 1; i2 < lastcar + 1; i2++)
                    {
                        if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\" + i2 + ".jpg"))
                        {
                            maxknowncar = i2;
                            if (MasterOfPictures.Verify(("Finger" + (i + 1) + "\\" + i2), ("Finger" + (i + 1) + "\\test")))
                            {
                                NotePad.DoLog("На " + (i + 1) + " месте " + i2 + " тачка");
                                carsid[i] = i2;
                                File.Delete("C:\\Bot\\Finger" + (i + 1) + "\\test.jpg");
                                flag = false;
                                break;
                            }
                        }
                    }
                    if (flag == true)
                    {
                        NotePad.DoLog("Добавляю новую тачку");
                        carsid[i] = maxknowncar + 1;
                        File.Move("C:\\Bot\\Finger" + (i + 1) + "\\test.jpg", "C:\\Bot\\Finger" + (i + 1) + "\\" + carsid[i] + ".jpg");
                    }
                }
                else
                {
                    for (int i2 = 1; i2 < lastcar; i2++)
                    {
                        if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\" + i2 + ".jpg")) //поиск в сортированных
                        {
                            if (MasterOfPictures.Verify(("Finger" + (i + 1) + "\\" + i2), ("Finger" + (i + 1) + "\\test")))
                            {
                                NotePad.DoLog("На " + (i + 1) + " месте " + i2 + " тачка");
                                carsid[i] = i2;
                                File.Delete("C:\\Bot\\Finger" + (i + 1) + "\\test.jpg");
                                flag = false;
                                break;
                            }
                        }
                    }

                    if (flag == true)
                    {
                        int emptySpaceForCar = 0;
                        for (int i2 = 1; i2 < lastcar; i2++)
                        {
                            if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\unsorted" + i2 + ".jpg")) //поиск в сортированных
                            {
                                if (MasterOfPictures.Verify(("Finger" + (i + 1) + "\\unsorted" + i2), ("Finger" + (i + 1) + "\\test")))
                                {
                                    NotePad.DoLog("На " + (i + 1) + " месте " + i2 + " неотсортированная тачка");
                                    carsid[i] = 10000; //неотсортированная
                                    File.Delete("C:\\Bot\\Finger" + (i + 1) + "\\test.jpg");
                                    flag = false;
                                    break;
                                }
                            }
                            else if (emptySpaceForCar == 0) emptySpaceForCar = i2;
                        }
                        if (flag == true)
                        {
                            NotePad.DoLog("Добавляю новую тачку");
                            carsid[i] = 10000; //неотсортированная
                            File.Move("C:\\Bot\\Finger" + (i + 1) + "\\test.jpg", "C:\\Bot\\Finger" + (i + 1) + "\\unsorted" + emptySpaceForCar + ".jpg");
                        }
                    }
                }
            }

            return carsid;
        }

        private int UseFilter(char cls, int n, int uhslts)
        {
            Waiting wait = new Waiting();

            Point filter = new Point(945, 265);
            Point clear = new Point(340, 785);
            Point accept = new Point(940, 785);
            Point rarity = new Point(200, 415);

            Point f = new Point(490, 450);
            Point e = new Point(700, 450);
            Point d = new Point(910, 450);
            Point c = new Point(1120, 450);
            Point b = new Point(490, 600);
            Point a = new Point(700, 600);
            Point s = new Point(910, 600);

            Rat.Clk(filter);
            wait.Filter();
            Rat.Clk(clear);
            Thread.Sleep(1000);
            Rat.Clk(rarity);
            Thread.Sleep(1000);
            switch (cls)
            {
                case 'f':
                    Rat.Clk(f);//выбрать класс                    
                    break;
                case 'e':
                    Rat.Clk(e);//выбрать класс                    
                    break;
                case 'd':
                    Rat.Clk(d);//выбрать класс                    
                    break;
                case 'c':
                    Rat.Clk(c);//выбрать класс                    
                    break;
                case 'b':
                    Rat.Clk(b);//выбрать класс                    
                    break;
                case 'a':
                    Rat.Clk(a);//выбрать класс                    
                    break;
                case 's':
                    Rat.Clk(s);//выбрать класс
                    break;
            }
            Thread.Sleep(500);
            Condition.ChooseTyres();
            Thread.Sleep(1000);
            Rat.Clk(accept);
            Thread.Sleep(2000);
            int emptycars = Rat.DragnDpopHand(n, uhslts);

            return emptycars;
        }

        private void Randomizer()
        {
            Waiting wait = new Waiting();
            FastCheck fc = new FastCheck();
            Point r1 = new Point(100, 410);//rarity
            Point r2 = new Point(100, 475);//rq
            Point r3 = new Point(100, 545);//max speed
            Point r4 = new Point(100, 615);//0-60
            Point r5 = new Point(430, 410);//handling
            Point r6 = new Point(430, 475);//wheels drive
            Point r7 = new Point(430, 545);//country
            Point r8 = new Point(430, 615);//width
            Point r9 = new Point(765, 410);//height
            Point r10 = new Point(765, 475);//weight
            Point[] a = new Point[] { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10 };
            Random rand = new Random();
            while (!fc.ItsGarage()) Thread.Sleep(2000);

            if ((Condition.conditionNumber == 11 && Condition.eventrq < 110)//условие определееной редкости
                || (Condition.conditionNumber == 10 && Condition.eventrq < 70)
                || (Condition.conditionNumber == 6 && Condition.eventrq < 50)
                || (Condition.conditionNumber == 40 && Condition.eventrq < 90)
                || Condition.eventrq < 30)
            {
                NotePad.DoLog("сортирую по рк");
                Thread.Sleep(200);
                Rat.Clk(1090, 265);//сортировка
                Thread.Sleep(1000);
                Rat.Clk(240, 795);//сброс
                Thread.Sleep(1000);
                Rat.Clk(1090, 265);//сортировка
                Thread.Sleep(1000);
                Rat.Clk(100, 475);//сортировка по рк  
            }
            else
            {
                Thread.Sleep(200);
                Rat.Clk(1090, 265);//сортировка
                wait.Type();
                int r = rand.Next(10);
                if (rand.Next(2) == 1)
                {
                    Rat.Clk(a[r].X, a[r].Y);//выбрать условие
                    Thread.Sleep(200);
                }
                Rat.Clk(a[r].X, a[r].Y);//выбрать условие 
            }

            Thread.Sleep(500);
            Rat.Clk(840, 790);//закрыть сортировку
            Thread.Sleep(4000);
        }
    }
}