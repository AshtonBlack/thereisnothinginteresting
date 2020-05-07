using System.Drawing;
using System.IO;
using System.Threading;

namespace WindowsFormsApp1
{
    class ChooseEvent
    {
        FastCheck fc = new FastCheck();

        Rectangle Condition1Bounds = new Rectangle(990, 395, 205, 20);
        Rectangle Condition2Bounds = new Rectangle(990, 420, 205, 20);
        string Condition1 = "Condition1\\test";
        string Condition2 = "Condition2\\test";

        Rectangle EventNameBounds = new Rectangle(985, 286, 235, 22);
        string EventNamePath = "Events\\Test";

        Rectangle RQBounds = new Rectangle(1135, 370, 85, 18);
        string RQPath = "RQ\\test";

        public int Selection(int eventN)
        {
            Point n1 = new Point(960, 570);
            Point n2 = new Point(960, 660);
            Point n3 = new Point(960, 750);
            Point n4 = new Point(960, 830);
            Point[] events = { n1, n2, n3, n4 };

            int c = 0;//подсчет известных эвентов
            for (int i = 0; i < 100; i++)
            {
                if (File.Exists(@"C:\Bot\Condition1\C" + i + ".jpg")) c = i; 
                else break;
            }

            bool flag;
            do
            {
                flag = true;

                NotePad.DoLog("Кликаю условие " + eventN);
                Rat.Clk(events[eventN - 1]);
                Thread.Sleep(4000);
                if (fc.MissClick())
                {
                    Rat.Clk(1145, 240);
                    flag = false;
                    Thread.Sleep(1000);
                }
                if (fc.EventPage())
                {
                    Rat.Clk(240, 500);//Clubs
                    flag = false;
                    Thread.Sleep(15000);
                }
                Thread.Sleep(2000);
            } while (flag == false);//клик эвента и обработка ошибок
            
            int x = 500;//номер условия
            MasterOfPictures.MakePicture(Condition1Bounds, Condition1);
            MasterOfPictures.MakePicture(Condition2Bounds, Condition2);
            if (MasterOfPictures.Verify(Condition2, "Condition2\\CC0"))
            {
                for (x = 0; x < (c + 1); x++)
                {
                    if (MasterOfPictures.Verify(Condition1, ("Condition1\\C" + x)))
                    {
                        NotePad.DoLog("Условие номер " + x );
                        break;
                    }
                }
                if (x == (c + 1))
                {                    
                    NotePad.DoLog("Неизвестное условие");
                    for (x = 1; x < 100; x++)
                    {
                        if (File.Exists("C:\\Bot\\Condition1\\UnknownCondition" + x + ".jpg"))
                        {
                            if (MasterOfPictures.Verify(Condition1, ("Condition1\\UnknownCondition" + x))) break;
                        }
                        else
                        {
                            File.Move("C:\\Bot\\" + Condition1 + ".jpg", "C:\\Bot\\Condition1\\UnknownCondition" + x + ".jpg");
                            NotePad.DoLog("Сделал скрин");
                            break;
                        }
                    }
                    x = 500;
                }
                if (x != 500)//Исключаю неизвестный
                {
                    NotePad.DoLog("Создаю событие на основе шаблона " + x);
                    Condition.MakeCondition(x);
                    NotePad.DoLog("Вычисляю РК эвента");
                    if (GotRQ())
                    {
                        NotePad.DoLog("Минимальное рк для условия " + Condition.minrq);
                        NotePad.DoLog("Требуемое рк для условия " + Condition.eventrq);
                        if (Condition.minrq > Condition.eventrq)
                        {
                            NotePad.DoLog("Минимальное рк для условия больше требуемого");
                            x = 500;
                        }
                    }
                    else
                    {
                        x = 500;
                    }                                   
                }
            }
            return x;
        }

        public int ChooseNormalEvent()
        {
            NotePad.DoLog("Проверяю условия");
            int x = 500;
            while (x == 500)
            {
                for (int i = 1; i < 5; i++)
                {
                    do
                    {
                        fc.MissClick();
                        Thread.Sleep(100);
                        fc.Bounty();
                        if (fc.EventPage()) Rat.Clk(240, 500);
                    } while (!fc.ClubMap());

                    NotePad.DoLog("Проверяю условие " + i);
                    x = Selection(i);

                    if (x == 500)
                    {
                        Rat.Clk(920, 270);//Back
                        Thread.Sleep(3000);
                    }
                    else break;
                }
            }
            return x;
        }

        public bool GotRQ()
        {
            bool isRqKnown = false;
            Condition.eventrq = 0;
            MasterOfPictures.MakePicture(RQBounds, RQPath);
            for (int i = 1; i < 502; i++)
            {
                if(File.Exists("C:\\Bot\\RQ\\" + i.ToString() + ".jpg"))
                {
                    if (MasterOfPictures.Verify(RQPath, "RQ\\" + i.ToString()))
                    {
                        Condition.eventrq = i;
                        NotePad.DoLog("рк =  " + Condition.eventrq);
                        break;
                    }
                }                
            }

            if (Condition.eventrq == 0)
            {
                NotePad.DoLog("неизвестное рк");

                for (int x = 1; x < 500; x++)
                {
                    if (File.Exists("C:\\Bot\\RQ\\UnknownRQ" + x + ".jpg"))
                    {
                        if (MasterOfPictures.Verify(RQPath, ("RQ\\UnknownRQ" + x)))
                        {
                            break;
                        }
                    }
                    else
                    {
                        File.Move("C:\\Bot\\" + RQPath + ".jpg", "C:\\Bot\\RQ\\UnknownRQ" + x + ".jpg");
                        NotePad.DoLog("Сделал скрин");
                        break;
                    }
                }
            }
            else isRqKnown = true;

            return isRqKnown;
        }

        public int WhichEvent()
        {
            int eventName = 0;
            MasterOfPictures.BW2Capture(EventNameBounds, EventNamePath);
            for (int i = 1; i < 40; i++)
            {
                if (File.Exists("C:\\Bot\\Events\\" + i.ToString() + ".jpg"))
                {
                    if (MasterOfPictures.VerifyBW(EventNamePath, "Events\\" + i.ToString(), 50))
                    {
                        eventName = i;
                        NotePad.DoLog("Название эвента =  " + i);
                        break;
                    }
                }
                else
                {
                    NotePad.DoLog("Добавляю еизвестный эвент");
                    File.Move("C:\\Bot\\" + EventNamePath + ".jpg", "C:\\Bot\\Events\\" + i.ToString() + ".jpg");
                    break;
                }
            }

            return eventName;
        }
    }
}