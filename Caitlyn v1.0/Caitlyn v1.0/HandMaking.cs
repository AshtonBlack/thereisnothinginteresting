using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Caitlyn_v1._0
{
    internal class HandMaking
    {
        bool eventIsNotEnd = true;
        public CarForExcel[] ChooseCars()
        {
            CarsDB.MakeCondAuto();//для очистки параметра inUse
            List<CarForExcel>[] carsForEveryFinger = new List<CarForExcel>[5];
            for (int finger = 0; finger < 5; finger++)
            {
                carsForEveryFinger[finger] = CarsDB.DefinePreferedCarPull(Condition.previousTracks[finger]);
            }
            
            int[] fingerCarNumber = new int[5];
            NotePad.DoLogWithoutTime("максимальные авто:");//debug
            for (int finger = 0; finger < fingerCarNumber.Length; finger++)
            {
                for (int cardNumberInCollection = 0; cardNumberInCollection < carsForEveryFinger[finger].Count; cardNumberInCollection++)
                {
                    int index = Condition.selectedCars.IndexOf(carsForEveryFinger[finger][cardNumberInCollection]);
                    if (Condition.selectedCars[index].inUse < Condition.selectedCars[index].amount)
                    {
                        fingerCarNumber[finger] = cardNumberInCollection;
                        Condition.selectedCars[index].inUse++;
                        NotePad.DoLog(Condition.selectedCars[index].fullname());//debug
                        break;
                    }
                }
            }
            
            int handrq = 0;
            for (int finger = 0; finger < 5; finger++)
            {
                //handrq += Convert.ToInt32(carsForEveryFinger[finger][fingerCarNumber[finger]].rq);
                handrq += RoundRQAccordingToClass(carsForEveryFinger[finger][fingerCarNumber[finger]].rarity);                
            }
            NotePad.DoLogWithoutTime("rq максимальных авто: " + handrq);//debug

            //debug
            int inUse = 0;
            foreach(CarForExcel car in Condition.selectedCars)
            {
                inUse += car.inUse;
            }
            NotePad.DoLogWithoutTime("использованных авто: " + inUse);//debug

            int randomFinger;
            Random r = new Random();
            SpecialEvents se = new SpecialEvents();
            while (Condition.eventRQ - handrq < 0)
            {
                int attemptToRandomizeFinger = 0;
                do
                {
                    attemptToRandomizeFinger++;
                    if (attemptToRandomizeFinger == 100) se.RestartBot();
                    randomFinger = r.Next(0, 5);
                } while (fingerCarNumber[randomFinger] == carsForEveryFinger[randomFinger].Count - 1);

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
                        //handrq += Convert.ToInt32(carsForEveryFinger[slot][fingerCarNumber[slot]].rq);
                        handrq += RoundRQAccordingToClass(carsForEveryFinger[slot][fingerCarNumber[slot]].rarity);
                    }
                }
                //NotePad.DoLog("RQ = " + handrq);//debug
            }//сборка руки
            NotePad.DoLogWithoutTime("Требуемое рк: " + Condition.eventRQ + "; рк руки: " + handrq);
            
            CarForExcel[] resultedCars = new CarForExcel[5];
            
            NotePad.DoLogWithoutTime("Подобранные тачки:");
            for (int finger = 0; finger < 5; finger++)
            {
                resultedCars[finger] = carsForEveryFinger[finger][fingerCarNumber[finger]];
                NotePad.DoLogWithoutTime(resultedCars[finger].fullname() + " " + resultedCars[finger].rq + "rq (в наличии: " + resultedCars[finger].amount + ", использовано: " + resultedCars[finger].inUse + ")");
            }
            
            return resultedCars;
        }
        int RoundRQAccordingToClass(string rarity)
        {
            switch (rarity)
            {
                case "s": return 100;
                case "a": return 79;
                case "b": return 64;
                case "c": return 49;
                case "d": return 39;
                case "e": return 29;
            }
            return 19;
        }
        public List<(CarForExcel description, int count)> GroupCars(CarForExcel[] cars) //dependecies with CarsDB.SatisfyConditionAndDescription
        {
            List<(CarForExcel description, int count)> carsDescriptions = new List<(CarForExcel description, int count)>
            {
                (cars[0], 0)//the first description is added by default
            };
            foreach(CarForExcel carDescription in cars)
            {
                bool found = false;
                for (int knownCarDescription = 0; knownCarDescription < carsDescriptions.Count; knownCarDescription++)
                {
                    if (carsDescriptions[knownCarDescription].description.rarity == carDescription.rarity
                    && carsDescriptions[knownCarDescription].description.drive == carDescription.drive
                    && carsDescriptions[knownCarDescription].description.clearance == carDescription.clearance
                    //&& carsDescription[j].description.country == additionalDescription.country
                    && carsDescriptions[knownCarDescription].description.tires == carDescription.tires)
                    {
                        carsDescriptions[knownCarDescription] = (carsDescriptions[knownCarDescription].description, carsDescriptions[knownCarDescription].count + 1);
                        found = true;
                        break;
                    }                    
                }
                if (!found)
                {
                    carsDescriptions.Add((carDescription, 1));
                }
            }
            NotePad.DoLog("cars are grouped");
            return carsDescriptions;
        }        
        public bool MakingHand()
        {
            if (CheckForEventIsOn()) ActivateCondition(); else return false;            
            List<(CarForExcel description, int count)> carsDescriptions = GroupCars(ChooseCars());
            int usedhandslots = 0;
            foreach (var carDescription in carsDescriptions)
            {
                if (!Randomizer()) return false;
                if (!UseFilter(carDescription.description)) return false;
                if (DragnDropHand(carDescription.count, usedhandslots, CarsDB.SatisfyConditionAndDescription(carDescription.description)) > 0) return false; //temporary
                usedhandslots += carDescription.count;
            }//механизм расстановки

            if (eventIsNotEnd && VerifyHand())
            {
                int[] carsid = RememberHand();
                NotePad.Saves(carsid);
            } //сохранение руки            
            else return false;
            
            return true;
        }        
        public void MakingHand1()//for test
        {
            GroupCars(ChooseCars());
        }
        bool CheckForEventIsOn()
        {
            FastCheck fc = new FastCheck();
            CommonLists.SkipAllSkipables();
            if (fc.ClubMap())
            {
                NotePad.DoLog("вылетел на карту");
                eventIsNotEnd = false;
                return false;
            }
            if(!eventIsNotEnd) return false;
            return true;
        }        
        bool ActivateCondition()
        {
            FastCheck fc = new FastCheck();
            if (Condition.ConditionNumber1 != "empty"
                && Condition.ConditionNumber1 != "обычная х3"
                && !fc.ConditionActivated()
                && CheckForEventIsOn()
                && fc.ItsGarage())//itsGarage is for test
            {
                NotePad.DoLog("Активирую условия события");
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
            return true;
        }//включить фильтр условия события.
        public bool CarFixed(int slot)
        {
            string path = "Check//";

            Rectangle[] bounds = new Rectangle[] { PointsAndRectangles.Car1Bounds,
                PointsAndRectangles.Car2Bounds,
                PointsAndRectangles.Car3Bounds,
                PointsAndRectangles.Car4Bounds,
                PointsAndRectangles.Car5Bounds,
                PointsAndRectangles.Car6Bounds,
                PointsAndRectangles.Car7Bounds,
                PointsAndRectangles.Car8Bounds };
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
            if (!fc.ItsGarage()) return false; 
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
        bool UseFilter(CarForExcel carDescription)
        {
            FastCheck fc = new FastCheck();
            SpecialEvents se = new SpecialEvents();
            NotePad.DoLog("накладываю фильтры");
            int attempts = 0;
            do
            {
                attempts++;
                if(attempts == 10) se.RestartBot();       
                if (!CheckForEventIsOn())
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
            Rat.Clk(PointsAndRectangles.carAttributes);
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.tires[carDescription.tires]);
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.drive[carDescription.drive]);
            Thread.Sleep(1000);
            //TODO choose country
            Rat.DragnDropSlow(PointsAndRectangles.toClearanceFilterStart, PointsAndRectangles.toClearanceFilterFinish, 8);//legacy
            Thread.Sleep(1000);
            //Rat.Clk(PointsAndRectangles.others);
            //Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.clearance[carDescription.clearance]);//выбрать класс
            attempts = 0;
            do
            {
                attempts++;
                if (attempts == 10) se.RestartBot();
                if (!CheckForEventIsOn())
                {
                    return false;
                }
                Rat.Clk(PointsAndRectangles.accept);
                Thread.Sleep(1000);
            } while (fc.FilterIsOpenned());//100% FilterCloser               
            Thread.Sleep(2000);

            return true;
        }
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

            do
            {
                if (!CheckForEventIsOn() || !fc.ItsGarage())
                {
                    return false;
                }
                Rat.Clk(PointsAndRectangles.sorting);//сортировка
                Thread.Sleep(1000);
            } while (!fc.TypeIsOpenned());//100% SorterOpenner
            int r = rand.Next(10);
            if (rand.Next(2) == 1)
            {
                Rat.Clk(a[r]);//выбрать условие
                Thread.Sleep(500);
            }
            Rat.Clk(a[r]);//выбрать условие 

            Thread.Sleep(500);
            do
            {
                if (!fc.ItsGarage()) return false;
                Rat.Clk(PointsAndRectangles.closesorting);//закрыть сортировку
                Thread.Sleep(1000);
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
            int handSlot = 0;
            int neededcars = n;

            while (n > 0)
            {
                if (garageSlot == availableCars)
                {
                    break;
                } //x имеет значение и при нуле
                else
                {
                    if (!CheckForEventIsOn() || !fc.ItsGarage())
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
                        while (!fc.ItsGarage())
                        {
                            Thread.Sleep(2000);
                            if (!CheckForEventIsOn())
                            {
                                break;
                            }
                        }                            
                        Rat.DragnDropSlow(garageSlots[garageSlot], handSlots[handSlot + previouslyUsedHandSlots], 8);
                        handSlot++;
                        n--;
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