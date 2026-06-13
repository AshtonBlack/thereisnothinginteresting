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
            if (MasterOfPictures.Verify(testPicture, originalPicture))
            {
                NotePad.DoLog("Visual matching with " + name);
                return true;
            }
               
            return false;
        }
        public bool MainFrameBW(Rectangle bounds, string name, int errors)
        {
            string testPicture = "HeadPictures\\Test" + name;
            string originalPicture = "HeadPictures\\Original" + name;
            MasterOfPictures.BW2Capture(bounds, testPicture);
            if (MasterOfPictures.VerifyBW(testPicture, originalPicture, errors))
            {
                NotePad.DoLog("Visual matching with " + name);
                return true;
            }
            return false;
        }
        public bool MainFrameBWWithBlackText(Rectangle bounds, string name, int errors)
        {
            string testPicture = "HeadPictures\\Test" + name;
            string originalPicture = "HeadPictures\\Original" + name;
            MasterOfPictures.BW2CaptureWithBlackText(bounds, testPicture);
            if (MasterOfPictures.VerifyBW(testPicture, originalPicture, errors))
            {
                NotePad.DoLog("Visual matching with " + name);
                return true;
            }
            return false;
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
            return MainFrameBWWithBlackText(PointsAndRectangles.allrectangles["readyToRace"], "GarageRaceButton", 40);
        }                                            
        public bool TypeIsOpenned()
        {
            return MainFrameBW(PointsAndRectangles.allrectangles["typeIsOpenned"], "TypeIsOpenned", 5);
        }
        public bool FilterIsOpenned()
        {
            return MainFrameBW(PointsAndRectangles.allrectangles["filterIsOpenned"], "FilterIsOpenned", 5);
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
            if (MainFrame(PointsAndRectangles.allrectangles["raceOn"], "Race"))
                return true;
            return false;
        }        
        public bool ItsGarage()
        {
            return MainFrameBWWithBlackText(PointsAndRectangles.allrectangles["inGarage"], "InGarage", 20);
        }                          
        public bool ConditionActivated()
        {            
            return MainFrameBWWithBlackText(PointsAndRectangles.allrectangles["conditionActivated"], "ConditionActivated", 3);
        }        
        public bool ArrangementWindow()
        {
            return MainFrame(PointsAndRectangles.allrectangles["arrangementWindow"], "Arrangement");
        }
        public bool RedReadytoRace()
        {
            return MainFrameBW(PointsAndRectangles.allrectangles["readyToRace"], "RedRaceButton", 40);
        }                
    }
}