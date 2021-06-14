using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace WindowsFormsApp1 //universal
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
                    Rat.Clk(PointsAndRectangles.endOfTheFirstRace); //кнопка "пропустить"
                    flag1++;
                }
                if (fc.AcceptThrow())
                {
                    Rat.Clk(PointsAndRectangles.acceptanceToThrowRaces);//подтвержение "пропуска"
                    flag2++;
                }
                if (fc.WonSet())
                {
                    Rat.Clk(PointsAndRectangles.endOfRaceSet);//звезды 
                    flag3++;
                }
                if (fc.LostSet())
                {
                    Rat.Clk(PointsAndRectangles.endOfRaceSet);//звезды 
                    flag3++;
                }
                if (fc.DrawSet())
                {
                    Rat.Clk(PointsAndRectangles.endOfRaceSet);//звезды 
                    flag3++;
                }
                Thread.Sleep(1500);
                if (fc.Bounty()) nextstep = true;
                if (fc.ClubMap()) nextstep = true;
                if (fc.Ending()) nextstep = true;
                if (fc.Upgrade()) nextstep = true;
            } while (!nextstep);            
        }

        public void UpgradeAdsKiller1()
        {
            FastCheck fc = new FastCheck();
            Waiting wait = new Waiting();

            NotePad.DoLog("Смотрю рекламу на прокачку");
            Rat.Clk(PointsAndRectangles.startToWatchADS); //начать просмотр
            Thread.Sleep(70000);
            if (fc.WrongADS())
            {
                Rat.Clk(PointsAndRectangles.itsWrongADS);
                Thread.Sleep(2000);
            }
            else
            {
                Rat.Clk(PointsAndRectangles.itsRightADS);
                Thread.Sleep(2000);
            }
            if (fc.ClickedWrongADS())
            {
                Rat.Clk(PointsAndRectangles.itsClickedWrongADS);
                Thread.Sleep(2000);
                Rat.Clk(PointsAndRectangles.itsClickedWrongADS);
                Thread.Sleep(2000);
            }
            if (fc.Upgrade())
            {
                bool notok;
                int badtry = 0;
                do
                {
                    if(badtry > 5) RestartBot();
                    Rat.Clk(PointsAndRectangles.startToWatchADS);
                    Thread.Sleep(4000);
                    notok = fc.Upgrade();
                    badtry++;
                } while (notok);                
            } //против глюка рекламы
            wait.CarIsUpgraded();
            Rat.Clk(PointsAndRectangles.upgradeAcceptance); //подтвердить проркачку
            Thread.Sleep(3000);
            UniversalErrorDefense();
        }

        public void UpgradeAdsKiller()//switch off ads watching
        {
            NotePad.DoLog("Пропускаю рекламу на прокачку");
            Rat.Clk(PointsAndRectangles.upgradeCancelation); //отменить просмотр
            Thread.Sleep(3000);
            UniversalErrorDefense();
        }

        public void RepairNoxPosition()//not universal
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

        public void ActivateClubBooster()
        {            
            Rat.Clk(PointsAndRectangles.clubBoosterActivation);
            Thread.Sleep(2000);
            Rat.Clk(PointsAndRectangles.clubBoosterAcceptance);
            Thread.Sleep(3000);
        }

        public void DragMap()
        {
            FastCheck fc = new FastCheck();
            fc.Bounty();
            Rat.DragnDropSlow(PointsAndRectangles.dragMapS, PointsAndRectangles.dragMapE, 8);
        }

        public void RestartBot()
        {
            Mail.MailMessage("Forced to reboot...");
            Rat.Clk(PointsAndRectangles.noxClosing);//close Nox
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.noxClosingAcceptance);//accept Nox close
            Thread.Sleep(1000);
            Process.Start(@"C:\Bot\BotRestarter\BotRestarter\bin\Debug\BotRestarter.exe");
            Process.GetCurrentProcess().Kill();
        }

        public void CarRepair()
        {
            FastCheck fc = new FastCheck();

            if (fc.CarRepair())
            {
                RestartBot();
            }
        }

        public void UniversalErrorDefense()
        {
            FastCheck fc = new FastCheck();
            if (fc.FaultNox())
            {
                RestartBot();
            }
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
            Point[] a = new Point[] { PointsAndRectangles.pHandSlot1, 
                PointsAndRectangles.pHandSlot2, 
                PointsAndRectangles.pHandSlot3, 
                PointsAndRectangles.pHandSlot4, 
                PointsAndRectangles.pHandSlot5 };
            for (int i = 0; i < 5; i++)
            {
                Point endPoint = new Point(a[i].X, a[i].Y-270);
                Rat.DragnDropSlow(a[i], endPoint, 10);
            }
        }

        public bool UnavailableEvent()
        {
            FastCheck fc = new FastCheck();
            bool x = true;

            if (fc.WrongParty())
            {
                NotePad.DoLog("Косячная рука");
                RestartBot();
            }

            if (fc.EventEnds())
            {
                NotePad.DoLog("эвент окончен");
                Rat.Clk(PointsAndRectangles.eventEndsAcceptance);//Accept Message
                Thread.Sleep(3000);
                x = false;
            }

            if (fc.EventIsNotAvailable())
            {
                NotePad.DoLog("эвент не доступен");
                Rat.Clk(PointsAndRectangles.eventIsNotAvailableAcceptance);//Accept Message                    
                Thread.Sleep(3000);
                x = false;
            }

            if (fc.EventisFull())
            {
                NotePad.DoLog("эвент заполнен");
                Rat.Clk(PointsAndRectangles.eventIsFullAcceptance);//Accept Message

                if (fc.ItsGarage())
                {
                    Rat.Clk(PointsAndRectangles.buttonBack);//back
                    Thread.Sleep(2000);
                    Rat.Clk(PointsAndRectangles.buttonBack);//back to club map
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
                Rat.Clk(PointsAndRectangles.missClickCancelation);
                NotePad.DoLog("Исправился");
                Thread.Sleep(1000);
            }
        }

        public void AcceptDailyBounty()
        {
            FastCheck fc = new FastCheck();
            bool bountyisavailable = false;

            int clkcounter = 0;

            NotePad.DoLog("принимаю ежедневку");
            do
            {
                if (clkcounter > 25) RestartBot();
                if (fc.DailyBounty())
                {
                    Rat.Clk(PointsAndRectangles.dailyBountyStart);
                    bountyisavailable = true;
                    Thread.Sleep(15000);
                }
                else 
                if (fc.DailyBountyEnd())
                {
                    Rat.Clk(PointsAndRectangles.confirmdailyBountyEnd);
                    bountyisavailable = false;
                    Thread.Sleep(15000);
                }
                else if (bountyisavailable)
                {
                    Rat.Clk(PointsAndRectangles.dailyBountyThrow);
                    clkcounter++;
                }                   
                Thread.Sleep(15000);
            } while (bountyisavailable);
            NotePad.DoLog("принял ежедневку");
            RestartBot();
        }

        public void CheckConnection()
        {
            FastCheck fc = new FastCheck();

            if (fc.TimeIsOut())
            {
                RestartBot();
            }
        }

        public void ToClubs()
        {
            bool needToDragMap = false;
            FastCheck fc = new FastCheck();
            bool flag = false;

            do
            {
                if (fc.NoxRestartMessage())
                {
                    Rat.Clk(PointsAndRectangles.noxRestartMessageAcceptance);
                    Thread.Sleep(1000);
                    Rat.Clk(PointsAndRectangles.edgeOfTheScreen);
                    Thread.Sleep(120000);
                    Process.Start(@"C:\Program Files (x86)\Nox\bin\Nox.exe", "-clone:Nox_1");                    
                }//nox restart message
                if (fc.StartIcon())//Icon
                {
                    Rat.Clk(PointsAndRectangles.clkTheIcon);
                }                
                if (fc.BrokenInterface()) Rat.Clk(PointsAndRectangles.brokenInterfaceAcceptance);//close notify
                if (fc.LostConnection()) Rat.Clk(PointsAndRectangles.reconnectionAfterLostConnection);//reconnect
                if (fc.Google()) Rat.Clk(PointsAndRectangles.googleNotificationAcceptance);//google notify
                if (fc.FBcontinue()) Rat.Clk(PointsAndRectangles.fbFucksBrain);//fb fucks brain
                if (fc.StartButton())
                {
                    Rat.Clk(PointsAndRectangles.buttonStart);//Start game
                    Thread.Sleep(5000);
                }                    
                if (fc.HeadPage())
                {
                    Rat.Clk(PointsAndRectangles.toEvents);//Events
                    Thread.Sleep(2000);
                }                    
                if (fc.DailyBounty()) AcceptDailyBounty();
                fc.Bounty();
                if (fc.SeasonEndsBounty())
                {
                    Thread.Sleep(500);
                    Rat.Clk(PointsAndRectangles.seasonEndAcceptance);
                    NotePad.DoLog("получил награду за сезон");
                }
                CheckConnection();
                UniversalErrorDefense();
                if (fc.EventPage())
                {
                    if (fc.InCommonEvent())
                    {
                        Thread.Sleep(500);
                        Rat.Clk(PointsAndRectangles.buttonBack);//back
                    }
                    else
                    {
                        Thread.Sleep(500);
                        Rat.Clk(PointsAndRectangles.toClubs);//Clubs
                        needToDragMap = true;
                    }                    
                }                
                if (fc.ClubMap()) flag = true;
                Thread.Sleep(1500);
            } while (!flag);

            if (needToDragMap) DragMap();
        }
    }
}