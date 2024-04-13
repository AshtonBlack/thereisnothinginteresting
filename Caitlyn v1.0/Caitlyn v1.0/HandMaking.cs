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
                carsForEveryFinger[finger] = CarsDB.DefinePreferedCarPull(Condition.tracks[finger]);
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
            while (Condition.eventRQ - handrq < 0)
            {
                int attemptToRandomizeFinger = 0;
                do
                {
                    attemptToRandomizeFinger++;
                    if (attemptToRandomizeFinger == 100) SpecialEvents.RestartBot();
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
                        handrq += RoundRQAccordingToClass(carsForEveryFinger[slot][fingerCarNumber[slot]].rarity);
                    }
                }
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
        public List<(CarForExcel description, int count)> GroupCars(CarForExcel[] cars)
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
                    && carsDescriptions[knownCarDescription].description.tires == carDescription.tires)
                    {
                        NotePad.DoLogWithoutTime("Машина со сходным описанием");//debug
                        NotePad.DoLogWithoutTime("Образец: ");//debug
                        NotePad.DoLogWithoutTime(carsDescriptions[knownCarDescription].description.rarity);//debug
                        NotePad.DoLogWithoutTime(carsDescriptions[knownCarDescription].description.drive);//debug
                        NotePad.DoLogWithoutTime(carsDescriptions[knownCarDescription].description.clearance);//debug
                        NotePad.DoLogWithoutTime(carsDescriptions[knownCarDescription].description.tires);//debug
                        NotePad.DoLogWithoutTime("Добавляемая: ");//debug
                        NotePad.DoLogWithoutTime(carDescription.rarity);//debug
                        NotePad.DoLogWithoutTime(carDescription.drive);//debug
                        NotePad.DoLogWithoutTime(carDescription.clearance);//debug
                        NotePad.DoLogWithoutTime(carDescription.tires);//debug
                        carsDescriptions[knownCarDescription] = (carsDescriptions[knownCarDescription].description, carsDescriptions[knownCarDescription].count + 1);
                        found = true;
                        break;
                    }                    
                }
                if (!found)
                {
                    NotePad.DoLogWithoutTime("Добавляю новое описание");//debug
                    NotePad.DoLogWithoutTime(carDescription.rarity);//debug
                    NotePad.DoLogWithoutTime(carDescription.drive);//debug
                    NotePad.DoLogWithoutTime(carDescription.clearance);//debug
                    NotePad.DoLogWithoutTime(carDescription.tires);//debug
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
            List <int> carsid = new List<int>();
            NotePad.DoLogWithoutTime("тачки после группировки по фильтрам");//debug
            foreach (var carDescription in carsDescriptions)
            {                
                if (!Randomizer()) return false;
                if (!UseFilter(carDescription.description)) return false;
                if (DragnDropHand(carDescription.count, usedhandslots, CarsDB.SatisfyConditionAndDescription(carDescription.description)) > 0) return false; //temporary
                usedhandslots += carDescription.count;
                for(int count = 0; count < carDescription.count; count++)
                {
                    NotePad.DoLogWithoutTime("Подобрал тачку с описанием похожим на: " + carDescription.description.fullname());//debug
                    carsid.Add(Convert.ToInt16(carDescription.description.pictureId));
                }
            }//механизм расстановки
            
            if (eventIsNotEnd && VerifyHand())
            {
                //int[] carsid = RememberHand(); //Опеределение тачек по картинке будет временно отключено в связи с отсутствием актуальной базы картинок
                NotePad.Saves(carsid.ToArray());
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
                && fc.ItsGarage())
            {
                NotePad.DoLog("Активирую условия события");
                Rat.Clk(PointsAndRectangles.allpoints["commonCondition"]);
                if (Condition.ConditionNumber2 != "empty")
                {                    
                    Thread.Sleep(1500);
                    Rat.Clk(PointsAndRectangles.allpoints["cond1"]);
                    Thread.Sleep(500);
                    Rat.Clk(PointsAndRectangles.allpoints["cond2"]);
                    Thread.Sleep(500);
                    Rat.Clk(PointsAndRectangles.allpoints["commonConditionCross"]);
                }
            }
            return true;
        }//включить фильтр условия события.
        public bool CarFixed(int slot)
        {
            string path = "Check//";

            Rectangle[] bounds = new Rectangle[] { PointsAndRectangles.allrectangles["Car1Bounds"],
                PointsAndRectangles.allrectangles["Car2Bounds"],
                PointsAndRectangles.allrectangles["Car3Bounds"],
                PointsAndRectangles.allrectangles["Car4Bounds"],
                PointsAndRectangles.allrectangles["Car5Bounds"],
                PointsAndRectangles.allrectangles["Car6Bounds"],
                PointsAndRectangles.allrectangles["Car7Bounds"],
                PointsAndRectangles.allrectangles["Car8Bounds"] };
            string[] n = new string[] { "1car", "2car", "3car", "4car", "5car", "6car", "7car", "8car" };
            MasterOfPictures.MakePicture(bounds[slot], path + n[slot] + "0");
            Thread.Sleep(2000);
            MasterOfPictures.MakePicture(bounds[slot], path + n[slot] + "1");
            return MasterOfPictures.Verify(path + n[slot] + "0", path + n[slot] + "1");
        }
        public bool HandCarFixed()
        {
            string path = "Check//";

            Rectangle[] bounds = new Rectangle[] { PointsAndRectangles.allrectangles["HandSlot1"], 
                PointsAndRectangles.allrectangles["HandSlot2"], 
                PointsAndRectangles.allrectangles["HandSlot3"], 
                PointsAndRectangles.allrectangles["HandSlot4"], 
                PointsAndRectangles.allrectangles["HandSlot5"] };
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
                    return false;
                }
            }
            return true;
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
            Rectangle[] handSlots = { PointsAndRectangles.allrectangles["HandSlot1"], 
                PointsAndRectangles.allrectangles["HandSlot2"], 
                PointsAndRectangles.allrectangles["HandSlot3"], 
                PointsAndRectangles.allrectangles["HandSlot4"], 
                PointsAndRectangles.allrectangles["HandSlot5"] };

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
            NotePad.DoLog("накладываю фильтры");
            int attempts = 0;
            do
            {
                attempts++;
                if(attempts == 10) SpecialEvents.RestartBot();       
                if (!CheckForEventIsOn())
                {
                    return false;
                }
                Rat.Clk(PointsAndRectangles.allpoints["filter"]);
                Thread.Sleep(1000);
            } while (!fc.FilterIsOpenned());//100% FilterOpenner
            Thread.Sleep(200);
            Rat.Clk(PointsAndRectangles.allpoints["clear"]);
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.allpoints["rarity"]);
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.allpoints["rarity" + carDescription.rarity]);//выбрать класс
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.allpoints["carAttributes"]);
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.allpoints["tires" + carDescription.tires]);
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.allpoints["drive" + carDescription.drive]);
            Thread.Sleep(1000);
            Rat.DragnDropSlow(PointsAndRectangles.allpoints["toClearanceFilterStart"], PointsAndRectangles.allpoints["toClearanceFilterFinish"], 8);//legacy
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.allpoints["clearance" + carDescription.clearance]);
            attempts = 0;
            do
            {
                attempts++;
                if (attempts == 10) SpecialEvents.RestartBot();
                if (!CheckForEventIsOn())
                {
                    return false;
                }
                Rat.Clk(PointsAndRectangles.allpoints["accept"]);
                Thread.Sleep(1000);
            } while (fc.FilterIsOpenned());//100% FilterCloser               
            Thread.Sleep(2000);

            return true;
        }
        private bool Randomizer()
        {
            FastCheck fc = new FastCheck();

            Point[] a = new Point[] { PointsAndRectangles.allpoints["sortrarity"],
                PointsAndRectangles.allpoints["sortrq"],
                PointsAndRectangles.allpoints["sortmaxspeed"],
                PointsAndRectangles.allpoints["sortacceleratioin"],
                PointsAndRectangles.allpoints["sorthandling"],
                PointsAndRectangles.allpoints["sortwheelsdrive"],
                PointsAndRectangles.allpoints["sortcountry"],
                PointsAndRectangles.allpoints["sortwidth"],
                PointsAndRectangles.allpoints["sortheight"],
                PointsAndRectangles.allpoints["sortweight"] };
            Random rand = new Random();
            NotePad.DoLog("рандомизирование");
            Thread.Sleep(1000);

            do
            {
                if (!CheckForEventIsOn() || !fc.ItsGarage())
                {
                    return false;
                }
                Rat.Clk(PointsAndRectangles.allpoints["sorting"]);//сортировка
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
                Rat.Clk(PointsAndRectangles.allpoints["closesorting"]);//закрыть сортировку
                Thread.Sleep(1000);
            } while (fc.TypeIsOpenned());//100% SorterCloser            
            Thread.Sleep(4000);

            return true;
        }
        public int DragnDropHand(int n, int previouslyUsedHandSlots, int availableCars)
        {
            //n -needed cars
            FastCheck fc = new FastCheck();

            Point[] handSlots = new Point[] { PointsAndRectangles.allpoints["pHandSlot1"],
                PointsAndRectangles.allpoints["pHandSlot2"],
                PointsAndRectangles.allpoints["pHandSlot3"],
                PointsAndRectangles.allpoints["pHandSlot4"],
                PointsAndRectangles.allpoints["pHandSlot5"] };
            Point[] garageSlots = new Point[] { PointsAndRectangles.allpoints["GarageSlot1"],
                PointsAndRectangles.allpoints["GarageSlot2"],
                PointsAndRectangles.allpoints["GarageSlot3"],
                PointsAndRectangles.allpoints["GarageSlot4"],
                PointsAndRectangles.allpoints["GarageSlot5"],
                PointsAndRectangles.allpoints["GarageSlot6"],
                PointsAndRectangles.allpoints["GarageSlot7"],
                PointsAndRectangles.allpoints["GarageSlot8"] };
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
                        Rat.DragnDropSlow(PointsAndRectangles.allpoints["ds1"], PointsAndRectangles.allpoints["de1"], 5);
                        drag = 1;
                        Thread.Sleep(1000);
                    }//сдвиг
                    if (garageSlot > 5 && drag == 1)
                    {
                        Rat.DragnDropSlow(PointsAndRectangles.allpoints["ds2"], PointsAndRectangles.allpoints["de2"], 5);
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