using System;
using System.Drawing;
using System.IO;
using System.Threading;

namespace WindowsFormsApp1 //universal
{
    public class HandMaking
    {
        public int[] ConditionHandling()
        {
            int[] rqclass = new int[] { 19, 29, 39, 49, 64, 79, 100 }; //рк для классов 
            
            Random r = new Random();
            int handrq = 0;
            Condition.ActualRQ();
            NotePad.DoLog("Искомое РК " + Condition.actualRQ);
            
            int[] finger = Condition.LowestClassCars();
            for (int x = 0; x < 5; x++)
            {
                handrq += rqclass[finger[x]];
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
                    handrq += rqclass[finger[x]];
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

            int[] classcars = { 0, 0, 0, 0, 0, 0, 0 };           
            for (int k = 0; k < finger.Length; k++)
            {
                classcars[finger[k]]++;
            }
            return classcars;//порядок F,E,D,C,B,A,S
        }

        public void MakingHand()
        {
            FastCheck fc = new FastCheck();            

            int[] classcars = ConditionHandling();
            NotePad.DoLog("Собираю " + classcars[0] + "F, " 
                + classcars[1] + "E, "
                + classcars[2] + "D, "
                + classcars[3] + "C, "
                + classcars[4] + "B, "
                + classcars[5] + "A, "
                + classcars[6] + "S");
            Thread.Sleep(1000);

            int emptycars; //недобор
            int conditionAvailableCars;
            int usedhandslots = 0;
            
            if (Condition.ConditionNumber1 != "empty"
                && Condition.ConditionNumber1 != "обычная х3"
                && !fc.ConditionActivated())
            {
                if(Condition.ConditionNumber2 == "empty")
                {
                    Rat.Clk(PointsAndRectangles.commonCondition);
                }
                else
                {
                    Rat.Clk(PointsAndRectangles.commonCondition);
                    Thread.Sleep(1000);
                    Rat.Clk(PointsAndRectangles.cond1);
                    Thread.Sleep(200);
                    Rat.Clk(PointsAndRectangles.cond2);
                    Thread.Sleep(200);
                    Rat.Clk(PointsAndRectangles.commonConditionCross);
                }
            } //включить фильтр условия события.

            Point[] cls = { PointsAndRectangles.f, PointsAndRectangles.e, PointsAndRectangles.d, PointsAndRectangles.c, PointsAndRectangles.b, PointsAndRectangles.a, PointsAndRectangles.s };
            for (int i = 6; i > -1; i--)
            {
                if (classcars[i] > 0)
                {
                    Randomizer();
                    UseFilter(cls[i]);
                    conditionAvailableCars = Condition.AvailableCars(i);

                    if (i == 0)//для серых нет возврата недобора
                    {                                                                       
                        DragnDpopHand(classcars[i], usedhandslots, conditionAvailableCars);
                    }
                    else
                    {
                        emptycars = 0;                               
                        emptycars += DragnDpopHand(classcars[i], usedhandslots, conditionAvailableCars);
                        usedhandslots += classcars[i] - emptycars;
                        classcars[i - 1] += emptycars;
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

            Rectangle[] bounds = new Rectangle[] { PointsAndRectangles.Car1Bounds, PointsAndRectangles.Car2Bounds, PointsAndRectangles.Car3Bounds, PointsAndRectangles.Car4Bounds, PointsAndRectangles.Car5Bounds, PointsAndRectangles.Car6Bounds, PointsAndRectangles.Car7Bounds, PointsAndRectangles.Car8Bounds };
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
            Rectangle[] bounds = new Rectangle[] { PointsAndRectangles.HandSlot1, PointsAndRectangles.HandSlot2, PointsAndRectangles.HandSlot3, PointsAndRectangles.HandSlot4, PointsAndRectangles.HandSlot5 };
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
            Rectangle[] b = { PointsAndRectangles.HandSlot1, PointsAndRectangles.HandSlot2, PointsAndRectangles.HandSlot3, PointsAndRectangles.HandSlot4, PointsAndRectangles.HandSlot5 };

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

        private void UseFilter(Point cls)
        {
            FastCheck fc = new FastCheck();
                        
            do
            {
                Rat.Clk(PointsAndRectangles.filter);
                Thread.Sleep(1000);
            } while (!fc.FilterIsOpenned());//100% FilterOpenner
            Thread.Sleep(200);
            Rat.Clk(PointsAndRectangles.clear);
            Thread.Sleep(1000);
            Rat.DragnDropSlow(PointsAndRectangles.xy1, PointsAndRectangles.xy2, 8);
            Rat.Clk(PointsAndRectangles.rarity);
            Thread.Sleep(1000);
            Rat.Clk(cls);//выбрать класс             
            Thread.Sleep(500);
            Condition.ChooseTyres();
            Thread.Sleep(1000);
            do
            {
                Rat.Clk(PointsAndRectangles.accept);
                Thread.Sleep(500);
            } while (fc.FilterIsOpenned());//100% FilterCloser            
            Thread.Sleep(2000);            
        }

        private void Randomizer()
        {            
            FastCheck fc = new FastCheck();
            
            Point[] a = new Point[] { PointsAndRectangles.r1, PointsAndRectangles.r2, PointsAndRectangles.r3, PointsAndRectangles.r4, PointsAndRectangles.r5, PointsAndRectangles.r6, PointsAndRectangles.r7, PointsAndRectangles.r8, PointsAndRectangles.r9, PointsAndRectangles.r10 };
            Random rand = new Random();
            while (!fc.ItsGarage()) Thread.Sleep(2000);
            
            if ((Condition.ConditionNumber1 == "экстремальная" && Condition.eventrq < 320)//условие определееной редкости
            || (Condition.ConditionNumber1 == "редкостная" && Condition.eventrq < 195)
            || (Condition.ConditionNumber1 == "необычная" && Condition.eventrq < 145)
            || (Condition.ConditionNumber1 == "суперская" && Condition.eventrq < 245)
            || Condition.eventrq < 95)
            {
                NotePad.DoLog("сортирую по рк");
                Thread.Sleep(200);
                do
                {
                    Rat.Clk(PointsAndRectangles.sorting);//сортировка
                    Thread.Sleep(1000);
                } while (!fc.TypeIsOpenned());//100% SorterOpenner
                Thread.Sleep(200);
                Rat.Clk(PointsAndRectangles.clearall);//сброс
                Thread.Sleep(1000);
                Rat.Clk(PointsAndRectangles.sorting);//сортировка
                Thread.Sleep(1000);
                Rat.Clk(PointsAndRectangles.r2);//сортировка по рк  
            }
            else
            {
                Thread.Sleep(200); 
                do
                {
                    Rat.Clk(PointsAndRectangles.sorting);//сортировка
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
                Rat.Clk(PointsAndRectangles.closesorting);//закрыть сортировку
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
            
            Point[] a = new Point[] { PointsAndRectangles.pHandSlot1, PointsAndRectangles.pHandSlot2, PointsAndRectangles.pHandSlot3, PointsAndRectangles.pHandSlot4, PointsAndRectangles.pHandSlot5 };
            Point[] b = new Point[] { PointsAndRectangles.GarageSlot1, PointsAndRectangles.GarageSlot2, PointsAndRectangles.GarageSlot3, PointsAndRectangles.GarageSlot4, PointsAndRectangles.GarageSlot5, PointsAndRectangles.GarageSlot6, PointsAndRectangles.GarageSlot7, PointsAndRectangles.GarageSlot8 };            
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
                        Rat.DragnDropSlow(PointsAndRectangles.ds1, PointsAndRectangles.de1, 5); 
                        drag = 1;
                        Thread.Sleep(1000);
                    }//сдвиг 

                    if (x > 5 && drag == 1)
                    {
                        Rat.DragnDropSlow(PointsAndRectangles.ds2, PointsAndRectangles.de2, 5);
                        drag = 2;
                        Thread.Sleep(1000);
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