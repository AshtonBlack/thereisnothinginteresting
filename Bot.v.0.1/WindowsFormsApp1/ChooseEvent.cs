using System;
using System.Drawing;
using System.IO;
using System.Threading;

namespace WindowsFormsApp1 //universal
{
    class ChooseEvent
    {
        int accountLVL = Condition.accountLVL;
        FastCheck fc = new FastCheck();
        string RQPath = @"RQ\test";

        public void ChooseNormalEvent()
        {
            SpecialEvents se = new SpecialEvents();
            NotePad.DoLog("Проверяю событие");
            bool eventIsOK = false;
            while (!eventIsOK)
            {
                for (int i = 1; i < 5; i++)
                {
                    do
                    {
                        se.MissClick();
                        se.ToClubs();
                    } while (!fc.ClubMap());

                    Thread.Sleep(500);
                    NotePad.DoLog("Проверяю условие " + i);
                    eventIsOK = Selection(i);

                    if (!eventIsOK)
                    {
                        Rat.Clk(PointsAndRectangles.toeventlist);//Back
                        Thread.Sleep(3000);                        
                    }
                    else break;
                }                
            }
        }

        public bool Selection(int eventN)
        {
            SpecialEvents se = new SpecialEvents();            
            Point[] events = { PointsAndRectangles.eventN1, PointsAndRectangles.eventN2, PointsAndRectangles.eventN3, PointsAndRectangles.eventN4 };

            bool eventIsOK = false;

            bool flag;
            do
            {
                flag = true;
                NotePad.DoLog("Кликаю условие " + eventN);
                Rat.Clk(events[eventN - 1]);
                Thread.Sleep(4000);                
                if (fc.EventPage())
                {
                    NotePad.DoLog("Вылетел из клубов");
                    Rat.Clk(PointsAndRectangles.clktoClubs);//Clubs
                    flag = false;
                    Thread.Sleep(15000);
                }
                se.UniversalErrorDefense();
                Thread.Sleep(2000);
            } while (flag == false);//клик эвента и обработка ошибок

            MasterOfPictures.MakePicture(PointsAndRectangles.Condition1Bounds, @"Condition1\test");
            MasterOfPictures.MakePicture(PointsAndRectangles.Condition2Bounds, @"Condition2\test");
            string cond1 = ConvertPictureToCond(DefineFirstEvevntConditionByPicture(), 1);
            string cond2 = ConvertPictureToCond(DefineSecondEvevntConditionByPicture(), 2);
                        
            if (cond1 != "unknown" && cond2 != "unknown")//Исключаю неизвестный
            {
                eventIsOK = true;
                Condition.MakeCondition(cond1, cond2);
                if (GotRQ() && Condition.minrq != 0)
                {
                    NotePad.DoLog("Минимальное рк для условия " + Condition.minrq);
                    NotePad.DoLog("Требуемое рк для условия " + Condition.eventrq);
                    if (Condition.minrq > Condition.eventrq || Condition.minrq > accountLVL)
                    {
                        NotePad.DoLog("Минимальное рк для условия больше требуемого");
                        eventIsOK = false;
                    }
                }
                else
                {
                    eventIsOK = false;
                    if (eventN == 4) Rat.Clk(PointsAndRectangles.clkoutofClubs);
                }
            }
            
            return eventIsOK;
        }

        int DefineEvevntConditionByPicture(int conditionNumber)
        { 
            int x;
            for (x = 0; x < 500; x++)
            {
                if (File.Exists(@"C:\Bot\Condition" + conditionNumber + @"\C" + x + ".jpg"))
                {
                    if (MasterOfPictures.Verify("Condition" + conditionNumber + @"\test", ("Condition" + conditionNumber + @"\C" + x)))
                    {
                        NotePad.DoLog(conditionNumber + " условие: " + x);
                        break;
                    }
                }
                else
                {
                    NotePad.DoLog("Неизвестное условие");
                    for (int i = 1; i < 500; i++)
                    {
                        if (File.Exists(@"C:\Bot\Condition" + conditionNumber + @"\UnknownCondition" + i + ".jpg"))
                        {
                            if (MasterOfPictures.Verify("Condition" + conditionNumber + @"\test", ("Condition" + conditionNumber + @"\UnknownCondition" + i))) break;
                        }
                        else
                        {
                            File.Move(@"C:\Bot\" + "Condition" + conditionNumber + @"\test" + ".jpg", @"C:\Bot\Condition" + conditionNumber + @"\UnknownCondition" + i + ".jpg");
                            break;
                        }
                    }
                    x = 500;
                    break;
                }
            }

            return x;
        }

        int DefineFirstEvevntConditionByPicture()
        {            
            return DefineEvevntConditionByPicture(1);
        }

        int DefineSecondEvevntConditionByPicture()
        {
            return DefineEvevntConditionByPicture(2);
        }

        bool GotRQ()
        {
            bool isRqKnown = false;
            Condition.eventrq = 0;
            MasterOfPictures.MakePicture(PointsAndRectangles.RQBounds, RQPath);
            for (int i = 1; i < 501; i++)
            {
                if(File.Exists(@"C:\Bot\RQ\" + i + ".jpg"))
                {
                    if (MasterOfPictures.Verify(RQPath, @"RQ\" + i))
                    {
                        Condition.eventrq = i;
                        NotePad.DoLog("рк =  " + Condition.eventrq);
                        break;
                    }
                }                
            }

            if (Condition.eventrq == 0)
            {
                NotePad.DoLog("Unknown rq");
                for (int x = 1; x < 500; x++)
                {
                    if (File.Exists(@"C:\Bot\RQ\UnknownRQ" + x + ".jpg"))
                    {
                        if (MasterOfPictures.Verify(RQPath, (@"RQ\UnknownRQ" + x)))
                        {
                            break;
                        }
                    }
                    else
                    {
                        File.Move(@"C:\Bot\" + RQPath + ".jpg", @"C:\Bot\RQ\UnknownRQ" + x + ".jpg");
                        break;
                    }
                }
            }
            else isRqKnown = true;

            return isRqKnown;
        }        

        public string ConvertPictureToCond(int picture, int cond)
        {
            string name = "unknown";
            int length = NotePad.GetInfoFileLength(@"C:\Bot\Condition" + cond + @"\info.txt");
            string[,] theTable = NotePad.ReadInfoFromTXT(@"C:\Bot\Condition" + cond + @"\info.txt");
            for (int i = 0; i < length; i++)
            {
                if (picture == Convert.ToInt32(theTable[i, 0]))
                {
                    name = theTable[i, 1];
                    NotePad.DoLog(cond + " условие: " + name);
                    break;
                }
            }
            if (name == "unknown")
            {
                NotePad.DoErrorLog("Неизвестное условие");
            }

            return name;
        }
    }
}