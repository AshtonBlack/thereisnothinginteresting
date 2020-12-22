using System.Drawing;
using System.IO;
using System.Threading;

namespace WindowsFormsApp1 //universal
{
    class ChooseEvent
    {
        int accountLVL = Condition.accountLVL;
        FastCheck fc = new FastCheck();

        Rectangle Condition1Bounds = new Rectangle(990, 395, 205, 20);
        Rectangle Condition2Bounds = new Rectangle(990, 420, 205, 20);
        string Condition1 = "Condition1\\test";
        string Condition2 = "Condition2\\test";
        
        Rectangle RQBounds = new Rectangle(1135, 370, 85, 18);
        string RQPath = "RQ\\test";

        Point clktoClubs = new Point(240, 500);
        //events
        Point eventN1 = new Point(960, 570);
        Point eventN2 = new Point(960, 660);
        Point eventN3 = new Point(960, 750);
        Point eventN4 = new Point(960, 830);
        Point toeventlist = new Point(920, 270);
        

        public int Selection(int eventN)
        {
            SpecialEvents se = new SpecialEvents();            
            Point[] events = { eventN1, eventN2, eventN3, eventN4 };

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
                if (fc.EventPage())
                {
                    NotePad.DoLog("Вылетел из клубов");
                    Rat.Clk(clktoClubs);//Clubs
                    flag = false;
                    Thread.Sleep(15000);
                }
                se.UniversalErrorDefense();
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
                        if (Condition.minrq > Condition.eventrq || Condition.minrq > accountLVL)
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

        public void ChooseNormalEvent()
        {
            SpecialEvents se = new SpecialEvents();
            NotePad.DoLog("Проверяю условия");
            int x = 500;
            while (x == 500)
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
                    x = Selection(i);

                    if (x == 500)
                    {
                        Rat.Clk(toeventlist);//Back
                        Thread.Sleep(3000);
                    }
                    else break;
                }
            }
        }

        public bool GotRQ()
        {
            bool isRqKnown = false;
            Condition.eventrq = 0;
            MasterOfPictures.MakePicture(RQBounds, RQPath);
            for (int i = 1; i < 501; i++)
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
    }
}