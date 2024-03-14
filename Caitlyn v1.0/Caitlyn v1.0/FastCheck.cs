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
            return MainFrame(PointsAndRectangles.readyToRace, "GarageRaceButton");
        }                                            
        public bool TypeIsOpenned()
        {
            return MainFrame(PointsAndRectangles.typeIsOpenned, "TypeIsOpenned");
        }
        public bool FilterIsOpenned()
        {
            return MainFrame(PointsAndRectangles.filterIsOpenned, "FilterIsOpenned");
        }                                       
        public bool ActiveEvent()
        {
            return MainFrame(PointsAndRectangles.activeEvent, "ButtonToEvent");
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
            return MainFrame(PointsAndRectangles.inGarage, "InGarage");
        }                          
        public bool ConditionActivated()
        {
            string active = "Color [A=255, R=4, G=5, B=5]";
            string active1 = "Color [A=255, R=4, G=4, B=5]";
            Point p = new Point(415, 260);
            if (MasterOfPictures.PixelIndicator(p) == active || MasterOfPictures.PixelIndicator(p) == active1) return true;
            return false;
        }        
        public bool ArrangementWindow()
        {
            return MainFrame(PointsAndRectangles.arrangementWindow, "Arrangement");
        }
        public bool RedReadytoRace()
        {
            return MainFrame(PointsAndRectangles.readyToRace, "RedRaceButton");
        }                
    }
}