using System;
using System.Drawing;
using System.IO;
using System.Threading;

namespace Caytlin_v1._1
{
    internal class ChooseEvent
    {
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

                if(fc.ClubMap()) Rat.Clk(PointsAndRectangles.clkoutofClubs);//после проверке всех вариантов выйти из клубов для обновления списка (работает как защита от пустого списка)
            }
        }
        public bool Selection(int eventN)
        {
            SpecialEvents se = new SpecialEvents();
            Point[] events = { PointsAndRectangles.eventN1, PointsAndRectangles.eventN2, PointsAndRectangles.eventN3, PointsAndRectangles.eventN4 };
            
            bool flag;
            do
            {
                flag = true;
                NotePad.DoLog("Кликаю событие " + eventN);
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

            MasterOfPictures.BW2Capture(PointsAndRectangles.Condition1Bounds, @"Condition1\test");
            MasterOfPictures.BW2Capture(PointsAndRectangles.Condition2Bounds, @"Condition2\test");
            MasterOfPictures.BW2Capture(PointsAndRectangles.RQBounds, RQPath);

            string cond1 = ConvertPictureToCond(DefineFirstEvevntConditionByPicture(), 1);
            string cond2 = ConvertPictureToCond(DefineSecondEvevntConditionByPicture(), 2);
            Condition.setEventRQ(DefineRQByPicture());

            if (cond1 != "unknown" && cond2 != "unknown" && Condition.eventRQ != 0)//Исключаю неизвестный
            {
                Condition.MakeCondition(cond1, cond2);
                if (Condition.minRQ != 0)
                {
                    NotePad.DoLog("Требуемое рк для события: " + Condition.eventRQ + ", минимальное: " + Condition.minRQ);
                    if (Condition.minRQ > Condition.eventRQ) NotePad.DoLog("Минимальное рк для события больше требуемого");
                    else
                    {
                        Condition.setDefaultTracks();
                        return true;
                    }
                }
            }
            return false;
        }
        int DefineEvevntConditionByPicture(int conditionNumber)
        {
            for (int x = 0; x < 500; x++)
            {
                if (File.Exists(@"C:\Bot\Condition" + conditionNumber + @"\C" + x + ".jpg"))
                {
                    if (MasterOfPictures.VerifyBW("Condition" + conditionNumber + @"\test", ("Condition" + conditionNumber + @"\C" + x), 12))
                    {
                        NotePad.DoLog(conditionNumber + " условие: " + x);
                        return x;
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
                }
            }
            return 500;
        }
        int DefineFirstEvevntConditionByPicture()
        {
            return DefineEvevntConditionByPicture(1);
        }
        int DefineSecondEvevntConditionByPicture()
        {
            return DefineEvevntConditionByPicture(2);
        }
        int DefineRQByPicture()
        { 
            for (int rq = 1; rq < 501; rq++)
            {
                if (File.Exists(@"C:\Bot\RQ\" + rq + ".jpg"))
                {
                    if (MasterOfPictures.VerifyBW(RQPath, @"RQ\" + rq, 5))
                    {   
                        NotePad.DoLog("рк =  " + rq);
                        return rq;
                    }
                }
            }

            NotePad.DoLog("Unknown rq");
            for (int x = 1; x < 500; x++)
            {
                if (File.Exists(@"C:\Bot\RQ\UnknownRQ" + x + ".jpg"))
                {
                    if (MasterOfPictures.Verify(RQPath, (@"RQ\UnknownRQ" + x))) break;
                }
                else
                {
                    File.Move(@"C:\Bot\" + RQPath + ".jpg", @"C:\Bot\RQ\UnknownRQ" + x + ".jpg");
                    break;
                }
            }

            return 0;
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
