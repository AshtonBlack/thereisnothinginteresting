using System.Diagnostics;
using System.Threading;

namespace Caitlyn_v1._0
{
    class Navigation
    {        
        public void InitialStart()
        {
            NotePad.ClearLog();
            Process.Start(@"C:\Program Files (x86)\Nox\bin\Nox.exe"); //, "-clone:Nox_1"
            CarPictureDataBase carPictureDataBase = new CarPictureDataBase();
            carPictureDataBase.MakeDB();
        }
        public void InClubs()
        {
            ChooseEvent ce = new ChooseEvent();
            while (true)
            {
                SpecialEvents.ToClubs();
                TimingUnit tu = new TimingUnit();
                tu.CheckTime();             
                ce.ChooseNormalEvent();
                NotePad.DoLog("Вхожу в эвент " + Condition.eventRQ + " рк");
                Rat.Clk(PointsAndRectangles.allpoints["clubEventEnter"]);
                int i = 0;
                while (true)
                {
                    i++;
                    if (!PlayClubs(i)) break;
                }
            }
        }
        private bool PlayClubs(int i)
        {
            FastCheck fc = new FastCheck();
            PlayClubsPositions pcp = new PlayClubsPositions();

            if (!pcp.PathToGarage()) return false;
            if (!pcp.PrepareToRace(i)) return false;//набор/проверка руки
            GameState.antiLoopCounter = 0;
            do
            {
                if (GameState.antiLoopCounter == 60) SpecialEvents.RestartBot();
                CommonLists.SkipAllSkipables();
                if (fc.ReadyToRace())
                {
                    Rat.Clk(PointsAndRectangles.allpoints["startTheRace"]);
                    NotePad.DoLog("Перехожу к гонке");
                }
                if (fc.ArrangementWindow()) break;
                if (fc.ClubMap()) return false;
                Thread.Sleep(1000);
                GameState.antiLoopCounter++;
            } while (true);//переход к расстановке
            if(!pcp.TimeToRace()) return false;//расстановка

            return true;
        }
    }
}
