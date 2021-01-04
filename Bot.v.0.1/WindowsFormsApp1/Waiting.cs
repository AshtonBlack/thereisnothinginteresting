using System.Threading;

namespace WindowsFormsApp1 //universal
{
    class Waiting
    {
        FastCheck fc = new FastCheck();
        SpecialEvents se = new SpecialEvents();

        public void CarIsUpgraded()
        {
            int i = 0;
            bool x;
            fc.NoxPositionWithRepair();
            do
            {
                if(i == 10)
                {
                    NotePad.DoErrorLog("не дождался улучшения за рекламу");
                    se.RestartBot();
                } //долго ждал
                Thread.Sleep(2000);
                i++;
                se.UniversalErrorDefense();
                x = fc.CarIsUpgraded();
            } while (!x);
            Thread.Sleep(2000);
        }
        
        public void ReadytoRace()
        {
            bool x;            
            do
            {
                se.UniversalErrorDefense();
                x = fc.ReadyToRace();
                Thread.Sleep(500);
            } while (!x);
        }

        public void ArrangementWindow()
        {
            bool x;
            do
            {
                se.UniversalErrorDefense();
                x = fc.ArrangementWindow();
                Thread.Sleep(1000);
            } while (!x);
        }

        public void RaceOn()
        {            
            int waiter = 0;
            bool x;
            do
            {
                if (waiter == 180) se.RestartBot();
                se.UniversalErrorDefense();
                Thread.Sleep(1000);
                waiter++;
                x = fc.RaceOn();
            } while (!x);
        }

        public void RaceOff()
        {            
            bool x;
            do
            {
                Thread.Sleep(500);
                x = fc.RaceOn();
            } while (x);
        }
        
        public bool ForEnemy()
        {
            bool enemyIsReady = false;
            bool flag = false;
            do
            {
                if (se.UnavailableEvent())
                {
                    se.UniversalErrorDefense();
                    enemyIsReady = fc.EnemyIsReady();
                    if (enemyIsReady)
                    {
                        flag = true;
                    }
                    if (fc.ClubMap() || fc.Bounty())
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = true;
                }
                Thread.Sleep(1000);
            } while (!flag);

            return enemyIsReady;
        }
        
        public void Table()
        {
            bool x;
            do
            {
                se.UniversalErrorDefense();
                x = fc.Ending();
                Thread.Sleep(2000);
            } while (!x);
        }
    }
}