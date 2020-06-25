using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace WindowsFormsApp1
{
    public class SpecialEvents
    {
        public void EndRace()
        {
            FastCheck fc = new FastCheck();
            SpecialEvents se = new SpecialEvents();
            int flag1 = 0;
            int flag2 = 0;
            int flag3 = 0;
            bool nextstep = false;

            do
            {
                if(flag1 > 3 || flag2 > 3 || flag3 > 3)
                {
                    NotePad.DoErrorLog("образовалась петля");
                    se.RestartBot();
                }
                if (fc.RaceEnd())
                {
                    Rat.Clk(640, 215); //кнопка "пропустить"
                    flag1++;
                }
                if (fc.AcceptThrow())
                {
                    Rat.Clk(890, 625);//подтвержение "пропуска"
                    flag2++;
                }
                if (fc.WonSet() )
                {
                    Rat.Clk(635, 570);//звезды 
                    flag3++;
                }
                if (fc.LostSet())
                {
                    Rat.Clk(635, 570);//звезды 
                    flag3++;
                }
                if (fc.DrawSet())
                {
                    Rat.Clk(635, 570);//звезды 
                    flag3++;
                }
                Thread.Sleep(1500);
                if (fc.Ending()) nextstep = true;
                if (fc.Upgrade()) nextstep = true;
            } while (!nextstep);            
        }

        public void UpgradeAdsKiller()
        {
            FastCheck fc = new FastCheck();
            Waiting wait = new Waiting();

            NotePad.DoLog("Смотрю рекламу на прокачку");
            Rat.Clk(965, 745); //начать просмотр
            Thread.Sleep(60000);
            if (fc.NoxPosition())
            {
                if (fc.WrongADS())
                {
                    Rat.Clk(75, 205);
                    Thread.Sleep(2000);
                }
                else
                {
                    Rat.Clk(1205, 200);
                    Thread.Sleep(2000);
                }
            }
            else
            {
                Rat.Clk(805, 55);
                Thread.Sleep(2000);
                RepairNoxPosition();
                NotePad.DoErrorLog("ебучая реклама");
            }
            if (fc.ClickedWrongADS())
            {
                Rat.Clk(75, 205);
                Thread.Sleep(2000);
                Rat.Clk(75, 205);
                Thread.Sleep(2000);
            }
            if (fc.Upgrade())
            {
                RestartBot();
            } //против глюка рекламы
            wait.CarIsUpgraded();
            Rat.Clk(635, 720); //подтвердить проркачку
            Thread.Sleep(3000);
        }

        public void RepairNoxPosition()
        {
            Rat.Clk(1102, 142);
            Thread.Sleep(500);
            Rat.Clk(335, 325);
            Thread.Sleep(500);
            Rat.Clk(790, 600);
            Thread.Sleep(500);
            Rat.Clk(740, 740);
            Thread.Sleep(500);
        }

        public void ActivateClubBooster()//выключен
        {
            /*
            Rat.Clk(1025, 665);
            Thread.Sleep(2000);
            Rat.Clk(905, 610);
            */
            NotePad.DoLog("Booster отключен");
            Thread.Sleep(3000);
        }

        public void DragMap()
        {
            FastCheck fc = new FastCheck();
            fc.Bounty();
            Rat.MoveMouse(750, 500);
            Thread.Sleep(100);
            Rat.LMBdown(750, 500);
            Thread.Sleep(2000);
            for (int drag = 750; drag > 300; drag -= 8)
            {
                Rat.MoveMouse(drag, 500);
                Thread.Sleep(60);
            }
            Thread.Sleep(1000);
            Rat.MoveMouse(240, 500);
            Thread.Sleep(2000);
            Rat.LMBup(240, 500);
            Thread.Sleep(1000);
        }

        public void RestartBot()
        {
            Rat.Clk(1230, 150);//close Nox
            Thread.Sleep(1000);
            Rat.Clk(670, 560);//accept Nox close
            Thread.Sleep(1000);
            Process.Start(@"C:\Bot\BotRestarter\BotRestarter\bin\Debug\BotRestarter.exe");
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        public void UniversalErrorDefense()
        {
            FastCheck fc = new FastCheck();
            if (fc.ServerError())
            {
                Thread.Sleep(5000);
                if (fc.ServerError())
                {
                    RestartBot();
                }
            }
        }

        public void ClearHand()
        {
            Point HandSlot1 = new Point(160, 775);
            Point HandSlot2 = new Point(355, 775);
            Point HandSlot3 = new Point(545, 775);
            Point HandSlot4 = new Point(740, 775);
            Point HandSlot5 = new Point(930, 775);

            Point[] a = new Point[] { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };
            for (int i = 0; i < 5; i++)
            {
                Rat.MoveMouse(a[i].X, a[i].Y);
                Thread.Sleep(100);
                Rat.LMBdown(a[i].X, a[i].Y);
                Thread.Sleep(1500);
                for (int l = a[i].Y; l > 500; l -= 10)
                {
                    Rat.MoveMouse(a[i].X, l);
                    Thread.Sleep(80);
                }
                Thread.Sleep(1000);
                Rat.MoveMouse(a[i].X, 500);
                Thread.Sleep(2000);
                Rat.LMBup(a[i].X, 500);
                Thread.Sleep(1000);
            }
        }

        public bool UnavailableEvent()
        {
            FastCheck fc = new FastCheck();
            bool x = true;

            if (fc.EventEnds())
            {
                NotePad.DoLog("эвент окончен");
                Rat.Clk(640, 590);//Accept Message
                Thread.Sleep(3000);
                x = false;
            }

            if (fc.EventisFull())
            {
                NotePad.DoLog("эвент заполнен");
                Rat.Clk(645, 575);//Accept Message

                if (fc.ItsGarage())
                {
                    Rat.Clk(85, 215);//back
                    Thread.Sleep(2000);
                    Rat.Clk(85, 215);//back to club map
                }
                Thread.Sleep(3000);
                x = false;
            }
            return x;
        }

        public void MissClick()
        {
            FastCheck fc = new FastCheck();

            if (fc.MissClick())
            {
                NotePad.DoLog("Промах");
                Rat.Clk(1145, 240);
                NotePad.DoLog("Исправился");
                Thread.Sleep(1000);
            }
        }

        public void AcceptDailyBounty()
        {
            FastCheck fc = new FastCheck();

            NotePad.DoLog("принимаю ежедневку");
            do
            {
                Rat.Clk(640, 770);
                Thread.Sleep(10000);
            } while (fc.HeadPage());
            NotePad.DoLog("принял ежедневку");
        }

        public void ToClubs()
        {
            bool needToDragMap = false;
            SpecialEvents se = new SpecialEvents();
            FastCheck fc = new FastCheck();

            do
            {
                if (fc.StartIcon()) Rat.Clk(830, 375);//Icon                
                if (fc.StartButton()) Rat.Clk(340, 600);//Start game
                if (fc.HeadPage()) Rat.Clk(630, 390);//Events
                if (fc.DailyBounty()) AcceptDailyBounty();
                fc.Bounty();
                se.UniversalErrorDefense();
                if (fc.EventPage())
                {
                    Rat.Clk(240, 500);//Clubs
                    needToDragMap = true;
                }                    
                Thread.Sleep(1000);
            } while (!fc.ClubMap());

            if (needToDragMap) DragMap();
        }
    }
}