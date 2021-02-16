using System;
using System.Drawing;
using System.IO;
using System.Threading;

namespace WindowsFormsApp1 //not universal in DragnDpopHand
{
    public class HandMaking
    {
        Rectangle HandSlot1 = new Rectangle(85, 725, 115, 65);
        Rectangle HandSlot2 = new Rectangle(277, 725, 115, 65);
        Rectangle HandSlot3 = new Rectangle(469, 725, 115, 65);
        Rectangle HandSlot4 = new Rectangle(661, 725, 115, 65);
        Rectangle HandSlot5 = new Rectangle(853, 725, 115, 65);

        Rectangle Car1Bounds = new Rectangle(390, 325, 290, 150);
        Rectangle Car2Bounds = new Rectangle(390, 530, 290, 150);
        Rectangle Car3Bounds = new Rectangle(705, 325, 290, 150);
        Rectangle Car4Bounds = new Rectangle(705, 530, 290, 150);
        Rectangle Car5Bounds = new Rectangle(670, 325, 290, 150);
        Rectangle Car6Bounds = new Rectangle(670, 530, 290, 150);
        Rectangle Car7Bounds = new Rectangle(670, 325, 290, 150);
        Rectangle Car8Bounds = new Rectangle(670, 530, 290, 150);
        
        Point commoncondition = new Point(640, 265);

        Point filter = new Point(945, 265);
        Point clear = new Point(525, 785);
        Point accept = new Point(940, 785);
        Point rarity = new Point(200, 415);
        Point f = new Point(490, 450);
        Point e = new Point(700, 450);
        Point d = new Point(910, 450);
        Point c = new Point(1120, 450);
        Point b = new Point(490, 600);
        Point a = new Point(700, 600);
        Point s = new Point(910, 600);
        Point xy1 = new Point(180, 430);
        Point xy2 = new Point(180, 630);

        Point clearall = new Point(240, 795);//сброс
        Point sorting = new Point(1090, 265);//сортировка
        Point closesorting = new Point(840, 790);//закрыть сортировку
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

        Point GarageSlot1 = new Point(535, 400);
        Point GarageSlot2 = new Point(535, 590);
        Point GarageSlot3 = new Point(830, 400);
        Point GarageSlot4 = new Point(830, 590);
        Point ds1 = new Point(1010, 495);
        Point de1 = new Point(665, 495);
        Point GarageSlot5 = new Point(750, 400);
        Point GarageSlot6 = new Point(750, 590);
        Point ds2 = new Point(660, 495);
        Point de2 = new Point(330, 495);
        Point GarageSlot7 = new Point(750, 400);
        Point GarageSlot8 = new Point(750, 590);

        Point pHandSlot1 = new Point(170, 770);
        Point pHandSlot2 = new Point(350, 770);
        Point pHandSlot3 = new Point(540, 770);
        Point pHandSlot4 = new Point(730, 770);
        Point pHandSlot5 = new Point(910, 770);

        public int[] ConditionHandling()
        {
            int[] rqclass = new int[] { 19, 29, 39, 49, 64, 79, 100 }; //рк для классов 
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
            Condition.ActualRQ();
            NotePad.DoLog("Искомое РК " + Condition.actualRQ);
            
            int[] finger = Condition.LowestClassCars();
            for (int x = 0; x < 5; x++)
            {
                handrq += hand[x, finger[x]];
            }//начальная рука
            int n;
            while(Condition.actualRQ - handrq > 0)
            {
                do
                {
                    n = r.Next(0, 5);
                } while (finger[n] == Condition.maxclass);
                finger[n]++;

                handrq = 0;
                for (int x = 0; x < 5; x++)
                {
                    handrq += hand[x, finger[x]];
                }
            }//сборка руки
            
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

            int[] classcars = { 0, 0, 0, 0, 0, 0, 0 };//запись будет инвертирована            
            for (int k = 0; k < finger.Length; k++)
            {
                classcars[6 - finger[k]]++;
            }
            return classcars;//порядок S,A,B,C,D,E,F
        }

        public void MakingHand()
        {
            FastCheck fc = new FastCheck();            

            int[] classcars = ConditionHandling();
            NotePad.DoLog("Собираю " + classcars[0] + "S, " + classcars[1] + "A, " + classcars[2] + "B, " + classcars[3] + "C, " + classcars[4] + "D, " + classcars[5] + "E, " + classcars[6] + "F");
            Thread.Sleep(1000);

            int emptycars; //недобор
            int conditionAvailableCars;
            int usedhandslots = 0;
            if (Condition.conditionNumber != 0 && Condition.conditionNumber != 3 && Condition.conditionNumber != 36 && !fc.ConditionActivated()) 
                Rat.Clk(commoncondition); //включить фильтр условия события. Исключения: нет условий, 3 машины одной редкости, фильтр включен              
            char[] cls = { 's', 'a', 'b', 'c', 'd', 'e', 'f' };
            for (int i = 0; i < 7; i++)
            {
                if (classcars[i] > 0)
                {
                    Randomizer();
                    UseFilter(cls[i]);
                    conditionAvailableCars = Condition.AvailableCars(cls[i]);

                    if (i == 6)//для серых нет возврата недобора
                    {                                                                       
                        DragnDpopHand(classcars[i], usedhandslots, conditionAvailableCars);
                    }
                    else
                    {
                        emptycars = 0;                               
                        emptycars += DragnDpopHand(classcars[i], usedhandslots, conditionAvailableCars);
                        usedhandslots += classcars[i] - emptycars;
                        classcars[i + 1] += emptycars;
                    }
                }
            }//механизм расстановки

            if (VerifyHand())
            {
                int[] carsid = RememberHand();
                NotePad.Saves(carsid);
            } //сохранение руки
        }

        public bool CarFixed(int slot)
        {
            string path = "Check//";            

            Rectangle[] bounds = new Rectangle[] { Car1Bounds, Car2Bounds, Car3Bounds, Car4Bounds, Car5Bounds, Car6Bounds, Car7Bounds, Car8Bounds };
            string[] n = new string[] { "1car", "2car", "3car", "4car", "5car", "6car", "7car", "8car" };
            MasterOfPictures.MakePicture(bounds[slot], path + n[slot] + "0");
            Thread.Sleep(2000);
            MasterOfPictures.MakePicture(bounds[slot], path + n[slot] + "1");
            return MasterOfPictures.Verify(path + n[slot] + "0", path + n[slot] + "1");
        }

        public bool HandCarFixed()
        {
            string path = "Check//";
            
            bool x = true;
            Rectangle[] bounds = new Rectangle[] { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };
            string[] n = new string[] { "finger1", "finger2", "finger3", "finger4", "finger5" };
            for (int i = 0; i < 5; i++)
            {
                MasterOfPictures.MakePicture(bounds[i], path + n[i] + "0");
            }
            Thread.Sleep(2000);
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

            bool x = true;
            
            Thread.Sleep(2000);

            if(fc.AnyHandSlotIsEmpty()) x = false;

            if (fc.RedReadytoRace())
            {
                NotePad.DoLog("Рука не соответствует условию");
                x = false;
            }

            return x;
        }

        public int[] RememberHand()
        {            
            string carsDB = "Finger";
            int lastcar = 3000;
            int[] carsid = new int[5];
            bool flag;
            Rectangle[] b = { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };

            for (int i = 0; i < 5; i++)
            {
                MasterOfPictures.MakePicture(b[i], (carsDB + (i + 1) + "\\test"));
                flag = true;

                if (i == 0)//для первого пальца
                {
                    int emptySpaceForCar = 0;
                    for (int i2 = 1; i2 < lastcar ; i2++)
                    {
                        if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\" + i2 + ".jpg"))
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
                        else if (emptySpaceForCar == 0) emptySpaceForCar = i2;
                    }
                    if (flag == true)
                    {
                        NotePad.DoLog("Добавляю новую тачку");
                        carsid[i] = emptySpaceForCar;
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

        private void UseFilter(char cls)
        {
            FastCheck fc = new FastCheck();
                        
            do
            {
                Rat.Clk(filter);
                Thread.Sleep(1000);
            } while (!fc.FilterIsOpenned());//100% FilterOpenner
            Thread.Sleep(200);
            Rat.Clk(clear);
            Thread.Sleep(1000);
            Rat.DragnDropSlow(xy1, xy2, 8);
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
            do
            {
                Rat.Clk(accept);
                Thread.Sleep(500);
            } while (fc.FilterIsOpenned());//100% FilterCloser            
            Thread.Sleep(2000);            
        }

        private void Randomizer()
        {            
            FastCheck fc = new FastCheck();
            
            Point[] a = new Point[] { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10 };
            Random rand = new Random();
            while (!fc.ItsGarage()) Thread.Sleep(2000);

            if ((Condition.conditionNumber == 11 && Condition.eventrq < 320)//условие определееной редкости
                || (Condition.conditionNumber == 10 && Condition.eventrq < 195)
                || (Condition.conditionNumber == 6 && Condition.eventrq < 145)
                || (Condition.conditionNumber == 40 && Condition.eventrq < 245)
                || Condition.eventrq < 95)
            {
                NotePad.DoLog("сортирую по рк");
                Thread.Sleep(200);
                do
                {
                    Rat.Clk(sorting);//сортировка
                    Thread.Sleep(1000);
                } while (!fc.TypeIsOpenned());//100% SorterOpenner
                Thread.Sleep(200);
                Rat.Clk(clearall);//сброс
                Thread.Sleep(1000);
                Rat.Clk(sorting);//сортировка
                Thread.Sleep(1000);
                Rat.Clk(r2);//сортировка по рк  
            }
            else
            {
                Thread.Sleep(200); 
                do
                {
                    Rat.Clk(sorting);//сортировка
                    Thread.Sleep(1000);
                } while (!fc.TypeIsOpenned());//100% SorterOpenner
                Thread.Sleep(200);
                int r = rand.Next(10);
                if (rand.Next(2) == 1)
                {
                    Rat.Clk(a[r]);//выбрать условие
                    Thread.Sleep(200);
                }
                Rat.Clk(a[r]);//выбрать условие 
            }

            Thread.Sleep(500);
            do
            {
                Rat.Clk(closesorting);//закрыть сортировку
                Thread.Sleep(500);
            } while (fc.TypeIsOpenned());//100% SorterCloser            
            Thread.Sleep(4000);
        }

        public int DragnDpopHand(int n, int uhl, int caCars)
        {
            //caCars - cond available cars
            //n -needed cars
            FastCheck fc = new FastCheck();
            HandMaking hm = new HandMaking();
            
            Point[] a = new Point[] { pHandSlot1, pHandSlot2, pHandSlot3, pHandSlot4, pHandSlot5 };
            Point[] b = new Point[] { GarageSlot1, GarageSlot2, GarageSlot3, GarageSlot4, GarageSlot5, GarageSlot6, GarageSlot7, GarageSlot8 };            
            int drag = 0; //сдвиги            
            int x = 0; //слот гаража
            int h = 0; //слот руки, uhl использованные слоты в предыдущем подборе
            int neededcars = n;
            
            while (n > 0)
            {
                if(x == caCars)
                {
                    break;
                } //x имеет значение и при нуле
                else
                {
                    if (x > 3 && drag == 0)
                    {
                        Rat.DragnDropSlow(ds1, de1, 5); 
                        drag = 1;
                        Thread.Sleep(500);
                    }//сдвиг 

                    if (x > 5 && drag == 1)
                    {
                        Rat.DragnDropSlow(ds2, de2, 5);
                        drag = 2;
                        Thread.Sleep(500);
                    }//сдвиг 

                    if (x > 7)
                    {
                        break;
                    }//прерывание цикла в случае множества сломанных

                    if (hm.CarFixed(x))
                    {
                        NotePad.DoLog("Тачка " + (x + 1) + " исправна");
                        while (!fc.ItsGarage()) Thread.Sleep(2000);
                        Rat.DragnDropSlow(b[x], a[h + uhl], 8);
                        h++;
                        n--;
                    }
                    else
                    {
                        NotePad.DoLog("Тачка " + x + " не готова");
                    }
                    x++;
                }                
            }

            int grayslots = fc.CheckHandSlot(uhl+1, uhl+neededcars);
            NotePad.DoLog(grayslots + " слотов остались пустыми");
            return grayslots;
        }
    }
}