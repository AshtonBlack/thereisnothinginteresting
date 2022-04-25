using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;

namespace Caytlin_v1._1
{
    internal class HandMaking
    {
        public CarForExcel[] ChooseCars()
        {            
            List<CarForExcel>[] carsForEveryFinger = new List<CarForExcel>[5];            
            for (int i = 0; i < 5; i++)
            {
                carsForEveryFinger[i] = CarsDB.DefinePreferedCarPull(Condition.previousTracks[i]);
            }

            int[] fingerCarNumber = new int[5];
            //NotePad.DoLog("максимальные авто:");//debug
            for (int i = 0; i < fingerCarNumber.Length; i++)
            {
                //NotePad.DoLog("подбираю тачку в " + i + " слот");//debug
                //NotePad.DoLog(carsForEveryFinger[i].Count + " отобранных тачек для первого слота");//debug
                for (int j = 0; j < carsForEveryFinger[i].Count; j++)
                {
                    //NotePad.DoLog("Проверяю тачку" + carsForEveryFinger[i][j].fullname());//debug
                    int index = Condition.selectedCars.IndexOf(carsForEveryFinger[i][j]);
                    if (Condition.selectedCars[index].inUse < Condition.selectedCars[index].amount)
                    {
                        fingerCarNumber[i] = j;
                        Condition.selectedCars[index].inUse++;
                        //NotePad.DoLog(Condition.selectedCars[index].fullname());//debug
                        break;
                    }
                }                
            }

            int handrq = 0;
            for (int x = 0; x < 5; x++)
            {
                handrq += Convert.ToInt32(carsForEveryFinger[x][fingerCarNumber[x]].rq);
            }

            int randomFinger;
            Random r = new Random();
            while (Condition.eventRQ - handrq < 0)
            {
                do
                {
                    randomFinger = r.Next(0, 5);
                } while (fingerCarNumber[randomFinger] > (carsForEveryFinger[randomFinger].Count - 2));

                int nextCarNumber = fingerCarNumber[randomFinger] + 1;
                CarForExcel targetCar = carsForEveryFinger[randomFinger][nextCarNumber];
                int index = Condition.selectedCars.IndexOf(targetCar);
                if (Condition.selectedCars[index].amount > Condition.selectedCars[index].inUse)
                {
                    int previousIndex = Condition.selectedCars.IndexOf(carsForEveryFinger[randomFinger][fingerCarNumber[randomFinger]]);
                    Condition.selectedCars[previousIndex].inUse--;
                    Condition.selectedCars[index].inUse++;
                    fingerCarNumber[randomFinger]++;
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += Convert.ToInt32(carsForEveryFinger[x][fingerCarNumber[x]].rq);                        
                    }
                }
                //NotePad.DoLog("RQ = " + handrq);//debug
            }//сборка руки
            NotePad.DoLog("Требуемое рк: " + Condition.eventRQ + "; рк руки: " + handrq);

            CarForExcel[] resultedCars = new CarForExcel[5];
            NotePad.DoLog("Подобранные тачки:");
            for(int i = 0; i < 5; i++)
            {
                resultedCars[i] = carsForEveryFinger[i][fingerCarNumber[i]];
                NotePad.DoLog(resultedCars[i].fullname() + " " + resultedCars[i].rq + "rq (в наличии: " + resultedCars[i].amount + ", использовано: " + resultedCars[i].inUse + ")");
            }
            return resultedCars;
        }
        public List<(string rarity, string tires, string drive, string country, string clearance, int count)> GroupCars(CarForExcel[] car)
        {
            List<(string rarity, string tires, string drive, string country, string clearance, int count)> carsDescription = new List<(string rarity, string tires, string drive, string country, string clearace, int count)>();
            carsDescription.Add((car[0].rarity, car[0].tires, car[0].drive, car[0].clearance, car[0].country, 1));   
            for(int i = 1; i < car.Length; i++)
            {
                for(int j = 0; j < carsDescription.Count; j++)
                {
                    if(carsDescription[j].rarity == car[i].rarity &&
                        carsDescription[j].tires == car[i].tires &&
                        carsDescription[j].drive == car[i].drive &&
                        carsDescription[j].country == car[i].country &&
                        carsDescription[j].clearance == car[i].clearance)
                    {
                        carsDescription[j] = (carsDescription[j].rarity, carsDescription[j].tires, carsDescription[j].drive, carsDescription[j].country, carsDescription[j].clearance, carsDescription[j].count+1);
                    }
                    else
                    {
                        carsDescription.Add((car[i].rarity, car[i].tires, car[i].drive, car[i].country, car[i].clearance, 1));
                    }
                }
            }
            return carsDescription;
        }
        public void MakingHand()
        {
            ActivateCondition();
            int usedhandslots =0;
            foreach(var carsDescriptions in GroupCars(ChooseCars()))
            {
                Randomizer();
                UseFilter(carsDescriptions.rarity, carsDescriptions.tires, carsDescriptions.drive, carsDescriptions.country, carsDescriptions.clearance);
                DragnDpopHand(carsDescriptions.count, usedhandslots);
                usedhandslots+=carsDescriptions.count;
            }//механизм расстановки

            if (VerifyHand())
            {
                int[] carsid = RememberHand();
                NotePad.Saves(carsid);
            } //сохранение руки
        }
        void ActivateCondition()
        {
            FastCheck fc = new FastCheck();
            if (Condition.ConditionNumber1 != "empty"
                && Condition.ConditionNumber1 != "обычная х3"
                && !fc.ConditionActivated())
            {
                if (Condition.ConditionNumber2 == "empty")
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
            }
        }//включить фильтр условия события.
        bool CarFixed(int slot)
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
            Rectangle[] bounds = new Rectangle[] { PointsAndRectangles.HandSlot1, PointsAndRectangles.HandSlot2, PointsAndRectangles.HandSlot3, PointsAndRectangles.HandSlot4, PointsAndRectangles.HandSlot5 };
            string[] n = new string[] { "finger1", "finger2", "finger3", "finger4", "finger5" };
            for (int i = 0; i < 5; i++)
            {
                MasterOfPictures.MakePicture(bounds[i], path + n[i] + "0");
            }
            Thread.Sleep(2000);
            for (int i = 0; i < 5; i++)
            {
                MasterOfPictures.MakePicture(bounds[i], path + n[i] + "1");
                if (!MasterOfPictures.Verify(path + n[i] + "0", path + n[i] + "1"))
                {
                    NotePad.DoLog("Тачка на " + (i + 1) + " месте неисправна");
                    return false;
                }
            }
            return true;
        }
        public bool VerifyHand()
        {
            FastCheck fc = new FastCheck();
            Thread.Sleep(2000);
            if (fc.AnyHandSlotIsEmpty())
            {
                NotePad.DoLog("В руке имеется пустой слот");
                return false;
            }
            if (fc.RedReadytoRace())
            {
                NotePad.DoLog("Рука не соответствует условию");
                return false;
            }
            return true;
        }
        int[] RememberHand()
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
                    for (int i2 = 1; i2 < lastcar; i2++)
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
        void UseFilter(string rarity, string tires, string drive, string country, string clearance)
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
            //Rat.DragnDropSlow(PointsAndRectangles.xy1, PointsAndRectangles.xy2, 8);
            Rat.Clk(PointsAndRectangles.rarity);
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.rarityClasses[rarity]);//выбрать класс
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.tiresMenu);
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.tires[tires]);
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.drive[drive]);
            Thread.Sleep(1000);
            //TODO choose country
            do
            {
                Rat.Clk(PointsAndRectangles.accept);
                Thread.Sleep(500);
            } while (fc.FilterIsOpenned());//100% FilterCloser            
            Thread.Sleep(2000);
        }
        void Randomizer()
        {
            FastCheck fc = new FastCheck();

            Point[] a = new Point[] { PointsAndRectangles.r1, PointsAndRectangles.r2, PointsAndRectangles.r3, PointsAndRectangles.r4, PointsAndRectangles.r5, PointsAndRectangles.r6, PointsAndRectangles.r7, PointsAndRectangles.r8, PointsAndRectangles.r9, PointsAndRectangles.r10 };
            Random rand = new Random();
            while (!fc.ItsGarage()) Thread.Sleep(2000);

            if ((Condition.ConditionNumber1 == "экстремальная" && Condition.eventRQ < 320)//условие определееной редкости
            || (Condition.ConditionNumber1 == "редкостная" && Condition.eventRQ < 195)
            || (Condition.ConditionNumber1 == "необычная" && Condition.eventRQ < 145)
            || (Condition.ConditionNumber1 == "суперская" && Condition.eventRQ < 245)
            || Condition.eventRQ < 95)
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
        void DragnDpopHand(int n, int usedhandslots)
        {
            FastCheck fc = new FastCheck();
            HandMaking hm = new HandMaking();

            Point[] a = new Point[] { PointsAndRectangles.pHandSlot1,
                PointsAndRectangles.pHandSlot2,
                PointsAndRectangles.pHandSlot3,
                PointsAndRectangles.pHandSlot4,
                PointsAndRectangles.pHandSlot5 };
            Point[] b = new Point[] { PointsAndRectangles.GarageSlot1,
                PointsAndRectangles.GarageSlot2,
                PointsAndRectangles.GarageSlot3,
                PointsAndRectangles.GarageSlot4,
                PointsAndRectangles.GarageSlot5,
                PointsAndRectangles.GarageSlot6,
                PointsAndRectangles.GarageSlot7,
                PointsAndRectangles.GarageSlot8 };
            int drag = 0; //сдвиги            
            int x = 0; //слот гаража

            while (n > 0)
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

                if (hm.CarFixed(x))
                {
                    NotePad.DoLog("Тачка " + (x + 1) + " исправна");
                    while (!fc.ItsGarage()) Thread.Sleep(1000);
                    Rat.DragnDropSlow(b[x], a[usedhandslots], 8);
                    usedhandslots++;
                    n--;
                }
                else
                {
                    NotePad.DoLog("Тачка " + x + " не готова");
                }
                x++;
            }
        }
    }
}
