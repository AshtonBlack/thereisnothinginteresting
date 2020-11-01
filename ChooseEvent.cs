using System.Drawing;
using System.Threading;
using File = System.IO.File;

namespace WindowsFormsApp1
{
    class ChooseEvent
    {
        int accountLVL = Condition.accountLVL;
        FastCheck fc = new FastCheck();

        Rectangle Condition1Bounds = new Rectangle(990, 395, 205, 20);
        Rectangle Condition2Bounds = new Rectangle(990, 420, 205, 20);
        string Condition1 = "Condition\\test1";
        string Condition2 = "Condition\\test2";
        string path = "C:\\Bot\\";

        Rectangle RQBounds = new Rectangle(1135, 370, 85, 18);
        string RQPath = "RQ\\test";

        public int Selection(int eventN)
        {
            SpecialEvents se = new SpecialEvents();
            Point n1 = new Point(960, 570);
            Point n2 = new Point(960, 660);
            Point n3 = new Point(960, 750);
            Point n4 = new Point(960, 830);
            Point[] events = { n1, n2, n3, n4 };
                        
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
                    Rat.Clk(240, 500);//Clubs
                    flag = false;
                    Thread.Sleep(15000);
                }
                se.UniversalErrorDefense();
                Thread.Sleep(2000);
            } while (flag == false);//клик эвента и обработка ошибок

            int x = 500;//номер верхнего условия
            int y = 500;//номер нижнего условия
            MasterOfPictures.MakePicture(Condition1Bounds, Condition1);
            MasterOfPictures.MakePicture(Condition2Bounds, Condition2);

            for (int k = 0; k < 200; k++)
            {
                if (File.Exists(path + "Condition\\CC" + k))
                {
                    if (MasterOfPictures.Verify(Condition2, "Condition\\CC" + k))
                    {
                        NotePad.DoLog("Условие нижнее: " + k);
                        y = k;
                        break;
                    }
                }
                else
                {
                    NotePad.DoLog("Неизвестное условие номер 1");
                    for (int m = 1; m < 100; m++)
                    {
                        if (File.Exists(path + "Condition\\UnknownConditionCC" + m + ".jpg"))
                        {
                            if (MasterOfPictures.Verify(Condition1, "Condition\\UnknownConditionCC" + m)) break;
                        }
                        else
                        {
                            File.Move(path + Condition1 + ".jpg", path + "Condition\\UnknownConditionCC" + m + ".jpg");
                            NotePad.DoLog("Сделал скрин");
                            break;
                        }
                    }
                    break;
                }
            }

            for (int l = 0; l < 200; l++)
            {
                if (File.Exists(path + "Condition\\C" + l))
                {
                    if (MasterOfPictures.Verify(Condition1, "Condition\\C" + l))
                    {
                        NotePad.DoLog("Условие верхнее:" + l);
                        x = l;
                        break;
                    }
                }
                else
                {
                    NotePad.DoLog("Неизвестное условие номер 2");
                    for (int m = 1; m < 100; m++)
                    {
                        if (File.Exists(path + "Condition\\UnknownConditionC" + m + ".jpg"))
                        {
                            if (MasterOfPictures.Verify(Condition1, "Condition\\UnknownConditionC" + m)) break;
                        }
                        else
                        {
                            File.Move(path + Condition1 + ".jpg", path + "Condition\\UnknownConditionC" + m + ".jpg");
                            NotePad.DoLog("Сделал скрин");
                            break;
                        }
                    }
                    break;
                }
            }

            if (x != 500 && y != 500)//Исключаю неизвестные
            {
                NotePad.DoLog("Создаю событие на основе шаблонов " + x + " и " + y);
                Condition.MakeCondition(x, y);
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
            else
            {
                x = 500;
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
                        Rat.Clk(920, 270);//Back
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