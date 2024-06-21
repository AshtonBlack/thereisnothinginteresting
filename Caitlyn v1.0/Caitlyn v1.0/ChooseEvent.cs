using System.Drawing;
using System.IO;
using System.Threading;

namespace Caitlyn_v1._0
{
    class ChooseEvent
    {
        FastCheck fc = new FastCheck();
        string RQPath = @"RQ\test";
        public void ChooseNormalEvent()
        {
            if (fc.ActiveEvent())
            {                
                NotePad.DoLog("вхожу в активный эвент");
                string[] conds = NotePad.ReadConditions();
                Condition.setDefaultTracks();
                Condition.eventRQ = NotePad.ReadRQ();
                Condition.MakeCondition(conds[0], conds[1]);
            }
            else
            {
                bool eventIsOK = false;
                do
                {
                    for (int i = 1; i < 5; i++)
                    {
                        SpecialEvents.ToClubs();
                        Thread.Sleep(500);
                        NotePad.DoLog("Проверяю условие " + i);
                        if (eventIsOK = Selection(i)) break;
                        Rat.Clk(PointsAndRectangles.allpoints["toeventlist"]);//Back
                        Thread.Sleep(3000);
                    }
                } while (!eventIsOK);
            }            
        }
        public bool Selection(int eventN)
        {
            Point[] events = { PointsAndRectangles.allpoints["eventN1"],
                PointsAndRectangles.allpoints["eventN2"],
                PointsAndRectangles.allpoints["eventN3"],
                PointsAndRectangles.allpoints["eventN4"] };

            NotePad.DoLog("Кликаю событие " + eventN);
            Rat.Clk(events[eventN - 1]);
            Thread.Sleep(4000);
            CommonLists.SkipAllSkipables();
            Thread.Sleep(2000);

            MasterOfPictures.MakePicture(PointsAndRectangles.allrectangles["Condition1Bounds"], @"Condition1\test");
            MasterOfPictures.MakePicture(PointsAndRectangles.allrectangles["Condition2Bounds"], @"Condition2\test");
            string cond1 = ConditionDB.GetFirstConditionByNumber(DefineFirstEvevntConditionByPicture());
            string cond2 = ConditionDB.GetSecondConditionByNumber(DefineSecondEvevntConditionByPicture());


            if (cond1 != "unknown" && cond2 != "unknown")//Исключаю неизвестный
            {
                Condition.MakeCondition(cond1, cond2);
                if (GotRQ() && (Condition.minRQ != 0))
                {
                    NotePad.DoLog("Требуемое рк для события " + Condition.eventRQ);
                    if (Condition.minRQ > Condition.eventRQ)
                    {
                        NotePad.DoLog("Минимальное рк для события больше требуемого");
                        if (eventN == 4) Rat.Clk(PointsAndRectangles.allpoints["buttonBack"]);
                        return false;
                    }
                    else
                    {
                        Condition.setDefaultTracks();
                    }
                }
                else
                {
                    if (eventN == 4) Rat.Clk(PointsAndRectangles.allpoints["buttonBack"]); 
                    return false;
                }
            }
            else return false;
            return true;
        }
        int DefineEventConditionByPicture(int conditionNumber)
        {
            int x;
            for (x = 0; x < 1000; x++)
            {
                if (File.Exists(@"C:\Bot\Condition" + conditionNumber + @"\" + x + ".jpg"))
                {
                    if (MasterOfPictures.Verify("Condition" + conditionNumber + @"\test", "Condition" + conditionNumber + @"\" + x))
                    {
                        NotePad.DoLog(conditionNumber + " условие: " + x);
                        break;
                    }
                }
                else
                {
                    NotePad.DoLog("Неизвестное условие");
                    for (int i = 1; i < 1000; i++)
                    {
                        if (File.Exists(@"C:\Bot\Condition" + conditionNumber + @"\UnknownCondition" + i + ".jpg"))
                        {
                            if (MasterOfPictures.Verify("Condition" + conditionNumber + @"\test", "Condition" + conditionNumber + @"\UnknownCondition" + i)) break;
                        }
                        else
                        {
                            File.Move(@"C:\Bot\Condition" + conditionNumber + @"\test" + ".jpg", @"C:\Bot\Condition" + conditionNumber + @"\UnknownCondition" + i + ".jpg");
                            break;
                        }
                    }
                    x = 1000;
                    break;
                }
            }

            return x;
        }
        int DefineFirstEvevntConditionByPicture()
        {
            return DefineEventConditionByPicture(1);
        }
        int DefineSecondEvevntConditionByPicture()
        {
            return DefineEventConditionByPicture(2);
        }
        bool GotRQ()
        {
            Condition.eventRQ = 0;
            MasterOfPictures.MakePicture(PointsAndRectangles.allrectangles["RQBounds"], RQPath);
            for (int i = 1; i < 501; i++)
            {
                if (File.Exists(@"C:\Bot\RQ\" + i + ".jpg"))
                {
                    if (MasterOfPictures.Verify(RQPath, @"RQ\" + i))
                    {
                        Condition.eventRQ = i;
                        NotePad.DoLog("рк =  " + Condition.eventRQ);
                        if (Condition.eventRQ < 95) return false; else return true;//temporary
                    }
                }
            }

            NotePad.DoLog("Unknown rq");
            for (int x = 1; x < 500; x++)
            {
                if (File.Exists(@"C:\Bot\RQ\UnknownRQ" + x + ".jpg"))
                {
                    if (MasterOfPictures.Verify(RQPath, @"RQ\UnknownRQ" + x))
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

            return false;
        }        
    }
}