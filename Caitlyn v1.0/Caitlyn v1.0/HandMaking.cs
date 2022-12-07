﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Caitlyn_v1._0
{
    internal class HandMaking
    {
        bool eventIsNotEnd = true;
        //new        
        public CarForExcel[] ChooseCars()
        {
            List<CarForExcel>[] carsForEveryFinger = new List<CarForExcel>[5];
            for (int finger = 0; finger < 5; finger++)
            {
                carsForEveryFinger[finger] = CarsDB.DefinePreferedCarPull(Condition.previousTracks[finger]);
            }

            int[] fingerCarNumber = new int[5];
            //NotePad.DoLog("максимальные авто:");//debug
            for (int finger = 0; finger < fingerCarNumber.Length; finger++)
            {
                //NotePad.DoLog("подбираю тачку в " + i + " слот");//debug
                //NotePad.DoLog(carsForEveryFinger[i].Count + " отобранных тачек для " + i + " слота");//debug
                for (int cardNumberInCollection = 0; cardNumberInCollection < carsForEveryFinger[finger].Count; cardNumberInCollection++)
                {
                    //NotePad.DoLog("Проверяю тачку" + carsForEveryFinger[i][j].fullname());//debug
                    int index = Condition.selectedCars.IndexOf(carsForEveryFinger[finger][cardNumberInCollection]);
                    if (Condition.selectedCars[index].inUse < Condition.selectedCars[index].amount)
                    {
                        fingerCarNumber[finger] = cardNumberInCollection;
                        Condition.selectedCars[index].inUse++;
                        //NotePad.DoLog(Condition.selectedCars[index].fullname());//debug
                        break;
                    }
                }
            }

            int handrq = 0;
            for (int finger = 0; finger < 5; finger++)
            {
                handrq += Convert.ToInt32(carsForEveryFinger[finger][fingerCarNumber[finger]].rq);
            }

            int randomFinger;
            Random r = new Random();
            while (Condition.eventRQ - handrq < 0)
            {
                do
                {
                    randomFinger = r.Next(0, 5);
                } while (fingerCarNumber[randomFinger] > (carsForEveryFinger[randomFinger].Count - 2));//to be investigated

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
                    for (int slot = 0; slot < 5; slot++)
                    {
                        handrq += Convert.ToInt32(carsForEveryFinger[slot][fingerCarNumber[slot]].rq);
                    }
                }
                //NotePad.DoLog("RQ = " + handrq);//debug
            }//сборка руки
            NotePad.DoLog("Требуемое рк: " + Condition.eventRQ + "; рк руки: " + handrq);

            CarForExcel[] resultedCars = new CarForExcel[5];
            NotePad.DoLog("Подобранные тачки:");
            for (int finger = 0; finger < 5; finger++)
            {
                resultedCars[finger] = carsForEveryFinger[finger][fingerCarNumber[finger]];
                NotePad.DoLog(resultedCars[finger].fullname() + " " + resultedCars[finger].rq + "rq (в наличии: " + resultedCars[finger].amount + ", использовано: " + resultedCars[finger].inUse + ")");
            }
            return resultedCars;
        }
        public List<(CarForExcel description, int count)> GroupCars(CarForExcel[] cars)
        {
            List<(CarForExcel description, int count)> carsDescriptions = new List<(CarForExcel description, int count)>
            {
                (cars[0], 0)//the first description is added by default
            };
            foreach(CarForExcel carDescription in cars)
            {
                for (int knownCarDescription = 0; knownCarDescription < carsDescriptions.Count; knownCarDescription++)
                {
                    if (carsDescriptions[knownCarDescription].description.rarity == carDescription.rarity
                    && carsDescriptions[knownCarDescription].description.drive == carDescription.drive
                    //&& carsDescription[j].description.clearance == additionalDescription.clearance
                    //&& carsDescription[j].description.country == additionalDescription.country
                    && carsDescriptions[knownCarDescription].description.tires == carDescription.tires)
                    {
                        carsDescriptions[knownCarDescription] = (carDescription, carsDescriptions[knownCarDescription].count + 1);
                    }
                    else
                    {
                        carsDescriptions.Add((carDescription, 1));
                    }
                }
            }
            return carsDescriptions;
        }
        
        public bool MakingHand()
        {
            if (CheckForEventIsOn()) ActivateCondition(); else return false;
            int usedhandslots = 0;
            foreach(var carsDescriptions in GroupCars(ChooseCars()))
            {
                if (eventIsNotEnd) Randomizer(); else return false;
                if (eventIsNotEnd) UseFilter(carsDescriptions.description); else return false;
                if (eventIsNotEnd) DragnDropHand(carsDescriptions.count, usedhandslots, CarsDB.SatisfyConditionAndDescription(carsDescriptions.description)); else return false;
                usedhandslots +=carsDescriptions.count;
            }//механизм расстановки

            if (eventIsNotEnd && VerifyHand())
            {
                int[] carsid = RememberHand();
                NotePad.Saves(carsid);
            } //сохранение руки
            else return false;
            return true;
        }
        
        //new
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
            while (Condition.actualRQ - handrq > 0)
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
        bool CheckForEventIsOn()
        {
            FastCheck fc = new FastCheck();
            SpecialEvents se = new SpecialEvents();
            se.MissClick();
            if (fc.EventEnds())
            {
                NotePad.DoLog("Событие закончилось");
                Rat.Clk(PointsAndRectangles.eventEndsAcceptance);//событие закончилось
                Thread.Sleep(2000);
            }
            if (fc.ClubMap())
            {
                NotePad.DoLog("вылетел на карту");
                eventIsNotEnd = false;
            }
            if (fc.Bounty())
            {
                eventIsNotEnd = false;
            }
            return true;
        }
        //legacy
        /*
        public bool MakingHand()
        {
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

            if(!ActivateCondition()) return false;//включить фильтр условия события.

            Point[] cls = { PointsAndRectangles.f,
                PointsAndRectangles.e,
                PointsAndRectangles.d,
                PointsAndRectangles.c,
                PointsAndRectangles.b,
                PointsAndRectangles.a,
                PointsAndRectangles.s };
            for (int i = 6; i > -1; i--)
            {

                if (classcars[i] > 0 && eventIsNotEnd)
                {
                    if (!Randomizer())
                    {
                        return false;
                    }
                    if (!UseFilter(cls[i]))
                    {
                        return false;
                    }                    
                    conditionAvailableCars = Condition.AvailableCars(i);

                    if (i == 0)//для серых нет возврата недобора
                    {
                        DragnDropHand(classcars[i], usedhandslots, conditionAvailableCars);
                    }
                    else
                    {
                        emptycars = 0;
                        emptycars += DragnDropHand(classcars[i], usedhandslots, conditionAvailableCars);
                        usedhandslots += classcars[i] - emptycars;
                        classcars[i - 1] += emptycars;
                    }
                }
            }//механизм расстановки
            if (eventIsNotEnd)
            {
                if (VerifyHand())
                {
                    int[] carsid = RememberHand();
                    NotePad.Saves(carsid);
                } //сохранение руки
            }
            
            return eventIsNotEnd;
        }
        */
        //legacy
        //new
        bool ActivateCondition()
        {
            FastCheck fc = new FastCheck();
            if (Condition.ConditionNumber1 != "empty"
                && Condition.ConditionNumber1 != "обычная х3"
                && !fc.ConditionActivated()
                && CheckForEventIsOn()
                && eventIsNotEnd)
            {
                if (fc.ItsGarage())
                {
                    if (Condition.ConditionNumber2 == "empty")
                    {
                        Rat.Clk(PointsAndRectangles.commonCondition);
                    }
                    else
                    {
                        Rat.Clk(PointsAndRectangles.commonCondition);
                        Thread.Sleep(1500);
                        Rat.Clk(PointsAndRectangles.cond1);
                        Thread.Sleep(500);
                        Rat.Clk(PointsAndRectangles.cond2);
                        Thread.Sleep(500);
                        Rat.Clk(PointsAndRectangles.commonConditionCross);
                    }
                }
                else return false;
            }
            return true;
        }//включить фильтр условия события.
        //new
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
            Thread.Sleep(2000);
            if (fc.AnyHandSlotIsEmpty()) return false;
            if (fc.RedReadytoRace())
            {
                NotePad.DoLog("Рука не соответствует условию");
                return false;
            }
            if (!CheckForEventIsOn()) return false;

            return true;
        }        
        public int[] RememberHand()
        {
            string currentHand = "CurrentHand";
            int[] carsid = new int[5];
            Rectangle[] handSlots = { PointsAndRectangles.HandSlot1, 
                PointsAndRectangles.HandSlot2, 
                PointsAndRectangles.HandSlot3, 
                PointsAndRectangles.HandSlot4, 
                PointsAndRectangles.HandSlot5 };

            for (int finger = 0; finger < 5; finger++)
            {
                MasterOfPictures.MakePicture(handSlots[finger], currentHand + "\\test" + finger);
            }
            
            CarPictureDataBase carPictureDataBase = new CarPictureDataBase();
            for (int finger = 0; finger < carsid.Length; finger++)
            {
                carsid[finger] = carPictureDataBase.FindThePictureInCollection(finger);
            }
            return carsid;
        }
        //legacy
        private bool UseFilter(Point cls)
        {
            FastCheck fc = new FastCheck();
            SpecialEvents se = new SpecialEvents();
            NotePad.DoLog("накладываю фильтры");
            do
            {
                if (!CheckForEventIsOn() || !eventIsNotEnd || !fc.ItsGarage())
                {
                    return false;
                }
                Rat.Clk(PointsAndRectangles.filter);
                Thread.Sleep(1000);
            } while (!fc.FilterIsOpenned());//100% FilterOpenner
            Thread.Sleep(200);
            Rat.Clk(PointsAndRectangles.clear);
            Thread.Sleep(1000);
            //Rat.DragnDropSlow(PointsAndRectangles.xy1, PointsAndRectangles.xy2, 8);
            Rat.Clk(PointsAndRectangles.rarity);
            Thread.Sleep(1000);
            Rat.Clk(cls);//выбрать класс             
            Thread.Sleep(500);
            Condition.ChooseTyres();
            Thread.Sleep(1000);
            int timer = 0;
            do
            {
                if (timer == 20) se.RestartBot();
                if (!CheckForEventIsOn() || !eventIsNotEnd)
                {
                    return false;
                }
                Rat.Clk(PointsAndRectangles.accept);
                Thread.Sleep(500);
                timer++;
            } while (fc.FilterIsOpenned());//100% FilterCloser        
            Thread.Sleep(2000);

            return true;
        }
        //legacy
        //new
        bool UseFilter(CarForExcel carDescription)
        {
            FastCheck fc = new FastCheck();
            SpecialEvents se = new SpecialEvents();
            NotePad.DoLog("накладываю фильтры");
            do
            {
                if (!CheckForEventIsOn() || !eventIsNotEnd || !fc.ItsGarage())
                {
                    return false;
                }
                Rat.Clk(PointsAndRectangles.filter);
                Thread.Sleep(1000);
            } while (!fc.FilterIsOpenned());//100% FilterOpenner
            Thread.Sleep(200);
            Rat.Clk(PointsAndRectangles.clear);
            Thread.Sleep(1000);
            //Rat.DragnDropSlow(PointsAndRectangles.xy1, PointsAndRectangles.xy2, 8);//legacy
            Rat.Clk(PointsAndRectangles.rarity);
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.rarityClasses[carDescription.rarity]);//выбрать класс
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.tiresMenu);
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.tires[carDescription.tires]);
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.drive[carDescription.drive]);
            Thread.Sleep(1000);
            //TODO choose country
            //TODO choose clearance
            int timer = 0;
            do
            {
                if (timer == 20) se.RestartBot();
                if (!CheckForEventIsOn() || !eventIsNotEnd)
                {
                    return false;
                }
                Rat.Clk(PointsAndRectangles.accept);
                Thread.Sleep(500);
                timer++;
            } while (fc.FilterIsOpenned());//100% FilterCloser               
            Thread.Sleep(2000);

            return true;
        }
        //new
        private bool Randomizer()
        {
            FastCheck fc = new FastCheck();

            Point[] a = new Point[] { PointsAndRectangles.r1,
                PointsAndRectangles.r2,
                PointsAndRectangles.r3,
                PointsAndRectangles.r4,
                PointsAndRectangles.r5,
                PointsAndRectangles.r6,
                PointsAndRectangles.r7,
                PointsAndRectangles.r8,
                PointsAndRectangles.r9,
                PointsAndRectangles.r10 };
            Random rand = new Random();
            NotePad.DoLog("рандомизирование");
            Thread.Sleep(1000);

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
                    if (!CheckForEventIsOn() || !eventIsNotEnd || !fc.ItsGarage())
                    {
                        return false;
                    }
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
                    if (!CheckForEventIsOn() || !eventIsNotEnd || !fc.ItsGarage())
                    {
                        return false;
                    }
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
                if (!fc.ItsGarage()) return false;
                Rat.Clk(PointsAndRectangles.closesorting);//закрыть сортировку
                Thread.Sleep(500);
            } while (fc.TypeIsOpenned());//100% SorterCloser            
            Thread.Sleep(4000);

            return true;
        }
        public int DragnDropHand(int n, int previouslyUsedHandSlots, int availableCars)
        {
            //n -needed cars
            FastCheck fc = new FastCheck();

            Point[] handSlots = new Point[] { PointsAndRectangles.pHandSlot1,
                PointsAndRectangles.pHandSlot2,
                PointsAndRectangles.pHandSlot3,
                PointsAndRectangles.pHandSlot4,
                PointsAndRectangles.pHandSlot5 };
            Point[] garageSlots = new Point[] { PointsAndRectangles.GarageSlot1,
                PointsAndRectangles.GarageSlot2,
                PointsAndRectangles.GarageSlot3,
                PointsAndRectangles.GarageSlot4,
                PointsAndRectangles.GarageSlot5,
                PointsAndRectangles.GarageSlot6,
                PointsAndRectangles.GarageSlot7,
                PointsAndRectangles.GarageSlot8 };
            int drag = 0; //сдвиги            
            int garageSlot = 0; //слот гаража
            int handSlot = 0; //слот руки, uhl использованные слоты в предыдущем подборе
            int neededcars = n;

            while (n > 0)
            {
                if (garageSlot == availableCars)
                {
                    break;
                } //x имеет значение и при нуле
                else
                {
                    if (!CheckForEventIsOn() || !eventIsNotEnd || !fc.ItsGarage())
                    {
                        break;
                    }
                    if (garageSlot > 3 && drag == 0)
                    {
                        Rat.DragnDropSlow(PointsAndRectangles.ds1, PointsAndRectangles.de1, 5);
                        drag = 1;
                        Thread.Sleep(1000);
                    }//сдвиг 

                    if (garageSlot > 5 && drag == 1)
                    {
                        Rat.DragnDropSlow(PointsAndRectangles.ds2, PointsAndRectangles.de2, 5);
                        drag = 2;
                        Thread.Sleep(1000);
                    }//сдвиг 

                    if (garageSlot > 7)
                    {
                        break;
                    }//прерывание цикла в случае множества сломанных

                    if (CarFixed(garageSlot))
                    {                        
                        NotePad.DoLog("Тачка " + (garageSlot + 1) + " исправна");
                        while (!fc.ItsGarage())
                        {
                            Thread.Sleep(2000);
                            if (!CheckForEventIsOn() || !eventIsNotEnd)
                            {
                                break;
                            }
                        }                            
                        Rat.DragnDropSlow(garageSlots[garageSlot], handSlots[handSlot + previouslyUsedHandSlots], 8);
                        handSlot++;
                        n--;
                    }
                    else
                    {
                        NotePad.DoLog("Тачка " + garageSlot + " не готова");
                    }
                    garageSlot++;
                }
            }

            int grayslots = fc.CheckHandSlot(previouslyUsedHandSlots + 1, previouslyUsedHandSlots + neededcars);
            NotePad.DoLog(grayslots + " слотов остались пустыми");
            return grayslots;
        }        
    }
}
