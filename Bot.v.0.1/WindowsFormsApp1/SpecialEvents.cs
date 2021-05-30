using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace WindowsFormsApp1 //not Universal hardwork
{
    public class SpecialEvents
    {
        Point handSlot1s = new Point(160, 775);
        Point handSlot2s = new Point(355, 775);
        Point handSlot3s = new Point(545, 775);
        Point handSlot4s = new Point(740, 775);
        Point handSlot5s = new Point(930, 775);
        Point handSlot1e = new Point(160, 500);
        Point handSlot2e = new Point(355, 500);
        Point handSlot3e = new Point(545, 500);
        Point handSlot4e = new Point(740, 500);
        Point handSlot5e = new Point(930, 500);

        Point dragMapS = new Point(750, 500);
        Point dragMapE = new Point(240, 500);

        Point clkGalaxy = new Point(1160, 230);
        Point endOfRaceSet = new Point(635, 570);
        Point endOfTheFirstEace = new Point(640, 215);
        Point acceptanceToThrowRaces = new Point(890, 625);
        Point startToWatchADS = new Point(965, 745);
        Point itsWrongADS = new Point(75, 205);
        Point itsRightADS = new Point(1205, 200);
        Point itsWrongNoxPosition2 = new Point(880, 65);
        Point itsWrongNoxPosition = new Point(805, 55);
        Point itsClickedWrongADS = new Point(75, 205);
        Point upgradeAcceptance = new Point(635, 720);
        Point upgradeCancelation = new Point(570, 745);
        Point clubBoosterActivation = new Point(1025, 665);
        Point clubBoosterAcceptance = new Point(905, 610);
        Point noxClosing = new Point(1230, 150);
        Point noxClosingAcceptance = new Point(675, 540);//new
        Point cardBugClosing = new Point(1120, 800);
        Point missClickCancelation = new Point(1145, 240);
        Point eventEndsAcceptance = new Point(640, 590);
        Point eventIsFullAcceptance = new Point(645, 575);
        Point buttonBack = new Point(85, 215);
        Point dailyBountyStart = new Point(640, 770);
        Point dailyBountyEnd = new Point(630, 770);
        Point dailyBountyThrow = new Point(640, 510);
        Point toClubs = new Point(240, 500);
        Point toEvents = new Point(630, 390);
        Point seasonEndAcceptance = new Point(635, 660);
        Point buttonStart = new Point(340, 600);
        Point noxRestartMessageAcceptance = new Point(820, 560);
        Point edgeOfTheScreen = new Point(1200, 0);
        Point clkTheIcon = new Point(830, 375);
        Point fbFucksBrain = new Point(640, 625);
        Point reconnectionAfterLostConnection = new Point(785, 615);
        Point brokenInterfaceAcceptance = new Point(380, 555);
        Point googleNotificationAcceptance = new Point(890, 565);        

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
                    Rat.Clk(endOfTheFirstEace); //кнопка "пропустить"
                    flag1++;
                }
                if (fc.AcceptThrow())
                {
                    Rat.Clk(acceptanceToThrowRaces);//подтвержение "пропуска"
                    flag2++;
                }
                if (fc.WonSet())
                {
                    Rat.Clk(endOfRaceSet);//звезды 
                    flag3++;
                }
                if (fc.LostSet())
                {
                    Rat.Clk(endOfRaceSet);//звезды 
                    flag3++;
                }
                if (fc.DrawSet())
                {
                    Rat.Clk(endOfRaceSet);//звезды 
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
            Rat.Clk(startToWatchADS); //начать просмотр
            Thread.Sleep(70000);//

            if (!fc.NoxPosition())
            {
                if (fc.IsGalaxy())
                {
                    Rat.Clk(clkGalaxy);
                    Thread.Sleep(2000);
                }
                else
                {
                    if (fc.WrongADS())
                    {
                        Rat.Clk(itsWrongADS);
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Rat.Clk(itsRightADS);
                        Thread.Sleep(2000);
                    }
                }                
            }
            else
            {
                if (fc.WrongNoxPosition())
                {
                    Rat.Clk(itsWrongNoxPosition2);
                    Thread.Sleep(2000);
                    RepairNoxPosition();
                    NotePad.DoErrorLog("ебучая реклама N2");
                }
                else
                {
                    Rat.Clk(itsWrongNoxPosition);
                    Thread.Sleep(2000);
                    RepairNoxPosition();
                    NotePad.DoErrorLog("ебучая реклама");
                }
            }
            
            if (fc.ClickedWrongADS())
            {
                Rat.Clk(itsClickedWrongADS);
                Thread.Sleep(2000);
                Rat.Clk(itsClickedWrongADS);
                Thread.Sleep(2000);
            }
            if (fc.Upgrade())
            {
                bool notok;
                int badtry = 0;
                do
                {
                    if(badtry > 5) RestartBot();
                    Rat.Clk(startToWatchADS);
                    Thread.Sleep(4000);
                    notok = fc.Upgrade();
                    badtry++;
                } while (notok);                
            } //против глюка рекламы
            wait.CarIsUpgraded();
            Rat.Clk(upgradeAcceptance); //подтвердить проркачку
            Thread.Sleep(3000);
            UniversalErrorDefense();
        }

        public void UpgradeAdsKiller1()//switch off ads watching
        {
            NotePad.DoLog("Пропускаю рекламу на прокачку");
            Rat.Clk(upgradeCancelation); //отменить просмотр
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
            Rat.Clk(clubBoosterActivation);
            Thread.Sleep(2000);
            Rat.Clk(clubBoosterAcceptance);
            Thread.Sleep(3000);
        }

        public void DragMap()
        {
            FastCheck fc = new FastCheck();
            fc.Bounty();
            Rat.DragnDropSlow(dragMapS, dragMapE, 8);
        }

        public void RestartBot()
        {
            Mail.MailMessage("Forced to reboot...");
            Rat.Clk(noxClosing);//close Nox
            Thread.Sleep(1000);
            Rat.Clk(noxClosingAcceptance);//accept Nox close
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

        /*
        public void CardBug()
        {
            FastCheck fc = new FastCheck();
            if (fc.CardBug())
            {
                Rat.Clk(cardBugClosing);
                Thread.Sleep(500);
            }           
        }
        */
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
            Point[] a = new Point[] { handSlot1s, handSlot2s, handSlot3s, handSlot4s, handSlot5s };
            Point[] b = new Point[] { handSlot1e, handSlot2e, handSlot3e, handSlot4e, handSlot5e };
            for (int i = 0; i < 5; i++)
            {
                Rat.DragnDropSlow(a[i], b[i], 10);
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
                Rat.Clk(eventEndsAcceptance);//Accept Message
                Thread.Sleep(3000);
                x = false;
            }

            if (fc.EventisFull())
            {
                NotePad.DoLog("эвент заполнен");
                Rat.Clk(eventIsFullAcceptance);//Accept Message

                if (fc.ItsGarage())
                {
                    Rat.Clk(buttonBack);//back
                    Thread.Sleep(2000);
                    Rat.Clk(buttonBack);//back to club map
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
                Rat.Clk(missClickCancelation);
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
                    Rat.Clk(dailyBountyStart);
                    bountyisavailable = true;
                    Thread.Sleep(15000);
                }
                else 
                if (fc.DailyBountyEnd())
                {
                    Rat.Clk(dailyBountyEnd);
                    bountyisavailable = false;
                    Thread.Sleep(15000);
                }
                else if (bountyisavailable)
                {
                    Rat.Clk(dailyBountyThrow);
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
                    Rat.Clk(noxRestartMessageAcceptance);
                    Thread.Sleep(1000);
                    Rat.Clk(edgeOfTheScreen);
                    Thread.Sleep(120000);
                    Process.Start(@"C:\Program Files (x86)\Nox\bin\Nox.exe", "-clone:Nox_1");                    
                }//nox restart message
                if (fc.StartIcon())//Icon
                {
                    Rat.Clk(clkTheIcon);
                }                
                if (fc.BrokenInterface()) Rat.Clk(brokenInterfaceAcceptance);//close notify
                if (fc.LostConnection()) Rat.Clk(reconnectionAfterLostConnection);//reconnect
                if (fc.Google()) Rat.Clk(googleNotificationAcceptance);//google notify
                if (fc.FBcontinue()) Rat.Clk(fbFucksBrain);//fb fucks brain
                if (fc.StartButton())
                {
                    Rat.Clk(buttonStart);//Start game
                    Thread.Sleep(5000);
                }                    
                if (fc.HeadPage())
                {
                    Rat.Clk(toEvents);//Events
                    Thread.Sleep(2000);
                }                    
                if (fc.DailyBounty()) AcceptDailyBounty();
                fc.Bounty();
                if (fc.SeasonEndsBounty())
                {
                    Thread.Sleep(500);
                    Rat.Clk(seasonEndAcceptance);
                    NotePad.DoLog("получил награду за сезон");
                }
                CheckConnection();
                UniversalErrorDefense();
                if (fc.EventPage())
                {
                    if (fc.InCommonEvent())
                    {
                        Thread.Sleep(500);
                        Rat.Clk(buttonBack);//back
                    }
                    else
                    {
                        Thread.Sleep(500);
                        Rat.Clk(toClubs);//Clubs
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