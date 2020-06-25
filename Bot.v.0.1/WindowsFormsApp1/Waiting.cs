using System.Drawing;
using System.Threading;

namespace WindowsFormsApp1
{
    class Waiting
    {
        FastCheck fc = new FastCheck();
        SpecialEvents se = new SpecialEvents();

        public void CarIsUpgraded()
        {
            do
            {
                Thread.Sleep(1000);
            } while (!fc.CarIsUpgraded());
            Thread.Sleep(3000);
        }
        
        public void ReadytoRace()
        {
            string GarageRaceButtonPath = "HeadPictures\\TestGarageRaceButton";
            string GarageRaceButtonOriginal = "HeadPictures\\OriginalGarageRaceButton";
            Rectangle GarageRaceButtonBounds = new Rectangle(1075, 795, 95, 20);
            do
            {
                se.UniversalErrorDefense();
                MasterOfPictures.MakePicture(GarageRaceButtonBounds, GarageRaceButtonPath);
                Thread.Sleep(500);
            } while (!MasterOfPictures.Verify(GarageRaceButtonPath, GarageRaceButtonOriginal));
        }

        public void ArrangementWindow()
        {
            string ArrangementPath = "HeadPictures\\TestArrangement";
            string ArrangementOriginal = "HeadPictures\\OriginalArrangement";
            Rectangle ArrangementBounds = new Rectangle(75, 515, 5, 5);
            do
            {
                se.UniversalErrorDefense();
                MasterOfPictures.MakePicture(ArrangementBounds, ArrangementPath);
                Thread.Sleep(1000);
            } while (!MasterOfPictures.Verify(ArrangementPath, ArrangementOriginal));
        }

        public void RaceOn()
        {
            SpecialEvents se = new SpecialEvents();
            string RacePath = "HeadPictures\\TestRace";
            string RaceOriginal = "HeadPictures\\OriginalRace";
            Rectangle RaceBounds = new Rectangle(60, 185, 40, 40);
            int waiter = 0;
            do
            {
                if (waiter == 180) se.RestartBot();
                se.UniversalErrorDefense();
                MasterOfPictures.MakePicture(RaceBounds, RacePath);
                Thread.Sleep(1000);
                waiter++;
            } while (!MasterOfPictures.Verify(RacePath, RaceOriginal));
        }

        public void PointsForRace()
        {
            string RacePointsPath = "HeadPictures\\TestRace";
            string RacePointsOriginal = "HeadPictures\\OriginalRace";
            Rectangle RaceBounds = new Rectangle(60, 185, 40, 40);
            do
            {
                MasterOfPictures.MakePicture(RaceBounds, RacePointsPath);
                Thread.Sleep(500);
            } while (!MasterOfPictures.Verify(RacePointsPath, RacePointsOriginal));
        }

        public void RaceOff()
        {
            string RacePath = "HeadPictures\\TestRace";
            string RaceOriginal = "HeadPictures\\OriginalRace";
            Rectangle RaceBounds = new Rectangle(60, 185, 40, 40);
            do
            {
                MasterOfPictures.MakePicture(RaceBounds, RacePath);
                Thread.Sleep(500);
            } while (MasterOfPictures.Verify(RacePath, RaceOriginal));
        }
        
        public bool ForEnemy()
        {
            bool x = false;
            string ChooseanEnemyPath = "HeadPictures\\TestChooseanEnemy";
            string ChooseanEnemyOriginal = "HeadPictures\\OriginalChooseanEnemy";
            Rectangle ChooseanEnemyBounds = new Rectangle(154, 605, 35, 35);

            bool flag = false;
            do
            {
                if (se.UnavailableEvent())
                {
                    se.UniversalErrorDefense();
                    MasterOfPictures.BW2Capture(ChooseanEnemyBounds, ChooseanEnemyPath);
                    if (MasterOfPictures.VerifyBW(ChooseanEnemyPath, ChooseanEnemyOriginal, 90))//для начала проверяем на 100 ошибок
                    {
                        flag = true;
                        x = true;
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

            return x;
        }
        
        public void Table()
        {
            FastCheck fc = new FastCheck();
            do
            {
                se.UniversalErrorDefense();
                Thread.Sleep(2000);
            } while (!fc.Ending());
        }
    }
}