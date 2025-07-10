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
                        Thread.Sleep(2000);
                    }
                    if (fc.ClubMap() && !eventIsOK) Rat.Clk(PointsAndRectangles.allpoints["buttonBack"]);//после проверке всех вариантов выйти из клубов для обновления списка (работает как защита от пустого списка)
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
            Thread.Sleep(1000);
            CommonLists.SkipAllSkipables();
            Thread.Sleep(3000);

            MasterOfPictures.BW2Capture(PointsAndRectangles.allrectangles["Condition1Bounds"], @"Condition1\test");
            MasterOfPictures.BW2Capture(PointsAndRectangles.allrectangles["Condition2Bounds"], @"Condition2\test");
            MasterOfPictures.BW2Capture(PointsAndRectangles.allrectangles["RQBounds"], RQPath);

            string cond1 = ConditionDB.GetFirstConditionByNumber(DefineFirstEvevntConditionByPicture());
            string cond2 = ConditionDB.GetSecondConditionByNumber(DefineSecondEvevntConditionByPicture());
            Condition.eventRQ = GotRQ();

            if (cond1 != "unknown" && cond2 != "unknown" && Condition.eventRQ != 0)//Исключаю неизвестный
            {
                Condition.MakeCondition(cond1, cond2);
                if (Condition.minRQ != 0)
                {
                    NotePad.DoLog("Требуемое рк для события " + Condition.eventRQ);
                    if (Condition.minRQ > Condition.eventRQ)
                    {
                        NotePad.DoLog("Минимальное рк для события больше требуемого");
                        return false;
                    }
                    else Condition.setDefaultTracks();
                }
                else return false;
            }
            else return false;
            return true;
        }
        int DefineEventConditionByPicture(int conditionNumber)
        {
            //to delete
            /*
            if (!Directory.Exists(@"C:\Bot\Condition" + conditionNumber + @"\BW")) Directory.CreateDirectory(@"C:\Bot\Condition" + conditionNumber + @"\BW"); //temp
            for (int pictureNumber = 0; pictureNumber < 1000; pictureNumber++)
            {
                if (File.Exists(@"C:\Bot\Condition" + conditionNumber + @"\" + pictureNumber + ".jpg"))
                {
                    MasterOfPictures.TransformPictureIntoBW(@"C:\Bot\Condition" + conditionNumber + @"\" + pictureNumber + ".jpg", @"C:\Bot\Condition" + conditionNumber + @"\BW\" + pictureNumber + ".jpg"); //temp                    
                }
            }
           */
            
            for (int pictureNumber = 0; pictureNumber < 1000; pictureNumber++)
            {
                if (File.Exists(@"C:\Bot\Condition" + conditionNumber + @"\" + pictureNumber + ".jpg"))
                {
                    if (MasterOfPictures.VerifyBW("Condition" + conditionNumber + @"\test", "Condition" + conditionNumber + @"\" + pictureNumber, 12))
                    //if (MasterOfPictures.VerifyBW("Condition" + conditionNumber + @"\test", "Condition" + conditionNumber + @"\BW\" + pictureNumber, 12)) //to delete
                    {
                        NotePad.DoLog(conditionNumber + " условие: " + pictureNumber);
                        return pictureNumber;
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
                    break;                   
                }
            }
            return 1000;
        }
        int DefineFirstEvevntConditionByPicture()
        {
            return DefineEventConditionByPicture(1);
        }
        int DefineSecondEvevntConditionByPicture()
        {
            return DefineEventConditionByPicture(2);
        }
        int GotRQ()
        {
            for (int rq = 1; rq < 501; rq++)
            {
                if (File.Exists(@"C:\Bot\RQ\" + rq + ".jpg"))
                {
                    if (MasterOfPictures.VerifyBW(RQPath, @"RQ\" + rq, 5))
                    {
                        if (rq < 95) return 0;//temporary
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
                    if (MasterOfPictures.Verify(RQPath, @"RQ\UnknownRQ" + x)) break;
                }
                else
                {
                    File.Move(@"C:\Bot\" + RQPath + ".jpg", @"C:\Bot\RQ\UnknownRQ" + x + ".jpg");
                    break;
                }
            }

            return 0;
        }        
    }
}