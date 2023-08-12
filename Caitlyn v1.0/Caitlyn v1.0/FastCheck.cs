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
            Rectangle[] handSlots = { PointsAndRectangles.HandSlot1,
                PointsAndRectangles.HandSlot2,
                PointsAndRectangles.HandSlot3,
                PointsAndRectangles.HandSlot4,
                PointsAndRectangles.HandSlot5 };

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
            bool x = MainFrame(PointsAndRectangles.readyToRace, "GarageRaceButton");
            return x;
        }                                            
        public bool TypeIsOpenned()
        {
            bool x = MainFrame(PointsAndRectangles.typeIsOpenned, "TypeIsOpenned");
            return x;
        }
        public bool FilterIsOpenned()
        {
            bool x = MainFrame(PointsAndRectangles.filterIsOpenned, "FilterIsOpenned");
            return x;
        }                                       
        public bool ActiveEvent()
        {
            bool x = MainFrame(PointsAndRectangles.activeEvent, "ButtonToEvent");
            return x;
        }        
        public bool ClubMap()
        {
            if (MainFrameBW(PointsAndRectangles.clubMap, "ClubMap", 400)) return true;
            if (ActiveEvent()) return true;
            return false;
        }
        public bool RaceOn()
        {
            if (MainFrame(PointsAndRectangles.raceOn, "Race")
                || MainFrame(PointsAndRectangles.raceOn, "Race1")
                || MainFrame(PointsAndRectangles.raceOn, "Race2"))
                return true;
            return false;
        }        
        public bool ItsGarage()
        {
            bool x = MainFrame(PointsAndRectangles.inGarage, "InGarage");
            return x;
        }                          
        public bool ConditionActivated()
        {
            bool x = false;
            string active = "Color [A=255, R=4, G=5, B=5]";
            Point p = new Point(415, 260);
            if (MasterOfPictures.PixelIndicator(p) == active) x = true;
            return x;
        }        
        public bool ArrangementWindow()
        {
            bool x = MainFrame(PointsAndRectangles.arrangementWindow, "Arrangement");
            return x;
        }
        public bool RedReadytoRace()
        {
            bool x = MainFrame(PointsAndRectangles.readyToRace, "RedRaceButton");
            return x;
        }                
    }
}