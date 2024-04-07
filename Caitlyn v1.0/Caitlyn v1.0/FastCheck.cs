using System.Drawing;

namespace Caitlyn_v1._0
{
    class FastCheck
    {
        public bool AnyHandSlotIsEmpty()
        {
            if (CheckHandSlot(1, 5) > 0) return true;
            return false;
        }
        public bool MainFrame(Rectangle bounds, string name)
        {
            string testPicture = "HeadPictures\\Test" + name;
            string originalPicture = "HeadPictures\\Original" + name;
            MasterOfPictures.MakePicture(bounds, testPicture);
            if (MasterOfPictures.Verify(testPicture, originalPicture)) return true;
            return false;
        }
        public bool MainFrameBW(Rectangle bounds, string name, int errors)
        {
            bool x = false;
            string testPicture = "HeadPictures\\Test" + name;
            string originalPicture = "HeadPictures\\Original" + name;
            MasterOfPictures.BW2Capture(bounds, testPicture);
            if (MasterOfPictures.VerifyBW(testPicture, originalPicture, errors)) x = true;
            return x;
        }                
        public int CheckHandSlot(int startslot, int endslot)
        {
            int emptySlots = 0;
            Rectangle[] handSlots = { PointsAndRectangles.allrectangles["HandSlot1"],
                PointsAndRectangles.allrectangles["HandSlot2"],
                PointsAndRectangles.allrectangles["HandSlot3"],
                PointsAndRectangles.allrectangles["HandSlot4"],
                PointsAndRectangles.allrectangles["HandSlot5"] };

            for (int i = startslot - 1; i < endslot; i++)
            {
                if (MainFrame(handSlots[i], "CarSlot" + i))
                {
                    NotePad.DoLog("Тачка на " + (i + 1) + " позиции отсутствует");
                    emptySlots++;
                }
            }
            return emptySlots;
        }                
        public bool ReadyToRace()
        {
            return MainFrame(PointsAndRectangles.allrectangles["readyToRace"], "GarageRaceButton");
        }                                            
        public bool TypeIsOpenned()
        {
            return MainFrame(PointsAndRectangles.allrectangles["typeIsOpenned"], "TypeIsOpenned");
        }
        public bool FilterIsOpenned()
        {
            return MainFrame(PointsAndRectangles.allrectangles["filterIsOpenned"], "FilterIsOpenned");
        }                                       
        public bool ActiveEvent()
        {
            return MainFrame(PointsAndRectangles.allrectangles["activeEvent"], "ButtonToEvent");
        }        
        public bool ClubMap()
        {
            if (MainFrameBW(PointsAndRectangles.allrectangles["clubMap"], "ClubMap", 400)) return true;
            if (ActiveEvent()) return true;
            return false;
        }
        public bool RaceOn()
        {
            if (MainFrame(PointsAndRectangles.allrectangles["raceOn"], "Race")
                || MainFrame(PointsAndRectangles.allrectangles["raceOn"], "Race1")
                || MainFrame(PointsAndRectangles.allrectangles["raceOn"], "Race2"))
                return true;
            return false;
        }        
        public bool ItsGarage()
        {
            return MainFrame(PointsAndRectangles.allrectangles["inGarage"], "InGarage");
        }                          
        public bool ConditionActivated()
        {            
            return MainFrame(PointsAndRectangles.allrectangles["conditionActivated"], "ConditionActivated");
        }        
        public bool ArrangementWindow()
        {
            return MainFrame(PointsAndRectangles.allrectangles["arrangementWindow"], "Arrangement");
        }
        public bool RedReadytoRace()
        {
            return MainFrame(PointsAndRectangles.allrectangles["readyToRace"], "RedRaceButton");
        }                
    }
}