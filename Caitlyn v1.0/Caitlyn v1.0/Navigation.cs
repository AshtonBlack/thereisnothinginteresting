using System.Diagnostics;
using System.Threading;

namespace Caitlyn_v1._0
{
    class Navigation
    {
        ChooseEvent ce = new ChooseEvent();
        SpecialEvents se = new SpecialEvents();
        public void ToClubMap()
        {
            NotePad.ClearLog();
            Process.Start(@"C:\Program Files (x86)\Nox\bin\Nox.exe"); //, "-clone:Nox_1"
            CarPictureDataBase carPictureDataBase = new CarPictureDataBase();
            carPictureDataBase.MakeDB();
            se.ToClubs();
        }
        public void InClubs()
        {
            while (true)
            {
                se.ToClubs();
                TimingUnit tu = new TimingUnit();
                tu.CheckTime();
                Thread.Sleep(2000);
                int i = 0;
                NotePad.DoLog("Подбираю эвент с одним условием");
                ce.ChooseNormalEvent();
                NotePad.DoLog("Вхожу в эвент " + Condition.eventRQ + " рк");
                Rat.Clk(PointsAndRectangles.clubEventEnter);//ClubEventEnter   
                while (i < 100)
                {
                    i++;
                    if (!PlayClubs(i)) break;
                }
            }
        }
        private bool PlayClubs(int i)
        {
            SpecialEvents se = new SpecialEvents();
            FastCheck fc = new FastCheck();
            PlayClubsPositions pcp = new PlayClubsPositions();

            bool eventisactive = pcp.PathToGarage();
            if (eventisactive)
            {
                if (!pcp.PrepareToRace(i))//набор/проверка руки
                {
                    eventisactive = false;
                }
            }
            if (eventisactive)
            {
                bool foundplace = false;
                int waiter = 0;
                do
                {
                    if (waiter == 120) se.RestartBot();
                    se.CarRepair();
                    se.UniversalErrorDefense();
                    se.UnavailableEvent();
                    //se.CardBug();
                    if (fc.EventEnds())
                    {
                        NotePad.DoLog("Событие закончилось");
                        Rat.Clk(PointsAndRectangles.eventEndsAcceptance);//событие закончилось
                    }
                    if (fc.ReadyToRace())
                    {
                        Rat.Clk(PointsAndRectangles.startTheRace);
                        NotePad.DoLog("Перехожу к гонке");
                        Thread.Sleep(2000);
                    }
                    if (fc.EnemyIsReady())
                    {
                        NotePad.DoLog("Выбор противника");
                        foundplace = true;
                        Thread.Sleep(1000);
                    }
                    if (fc.Bounty())
                    {
                        NotePad.DoLog("Получил награду за эвент");
                        Thread.Sleep(1000);
                    }
                    if (fc.ClubMap())
                    {
                        NotePad.DoLog("Нахожусь на карте");
                        eventisactive = false;
                        foundplace = true;
                        Thread.Sleep(1000);
                    }
                    Thread.Sleep(1000);
                    waiter++;
                } while (!foundplace);//ожидание противника
            }
            if (eventisactive)
            {
                pcp.TimeToRace();//расстановка
                se.EndRace();//завершение заезда

                bool foundplace = false;
                int waiter = 0;
                do
                {
                    if (waiter == 180) se.RestartBot();
                    se.UniversalErrorDefense();

                    if (fc.Upgrade())
                    {
                        NotePad.DoLog("реклама на апгрейд");
                        se.UpgradeAdsKiller();
                        Thread.Sleep(1000);
                    }

                    if (fc.Ending())
                    {
                        NotePad.DoLog("Таблица результатов");
                        Rat.Clk(PointsAndRectangles.passTheTableAfterRace);//Table
                        Thread.Sleep(1000);
                    }

                    if (fc.Bounty())
                    {
                        NotePad.DoLog("Получил награду за эвент");
                        Thread.Sleep(1000);
                    }

                    if (fc.EventEnds())
                    {
                        NotePad.DoLog("Событие закончилось");
                        Rat.Clk(PointsAndRectangles.eventEndsAcceptance);//событие закончилось
                    }

                    if (fc.ControlScreen())
                    {
                        NotePad.DoLog("Нахожусь на экране контроля");
                        foundplace = true;
                        Thread.Sleep(1000);
                    }

                    if (fc.BugControlScreen())
                    {
                        Thread.Sleep(500);
                        NotePad.DoLog("Bug with Control Screen");
                        Rat.Clk(PointsAndRectangles.backToClubMap);//Back
                        Thread.Sleep(1000);
                    }

                    if (fc.ClubMap())
                    {
                        NotePad.DoLog("Нахожусь на карте");
                        eventisactive = false;
                        foundplace = true;
                        Thread.Sleep(1000);
                    }
                    Thread.Sleep(1000);
                    waiter++;
                } while (!foundplace);//переход на экран контроля
            }

            return eventisactive;
        }
    }
}
