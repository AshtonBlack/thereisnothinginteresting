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
                if (VisualCheck.Check(handSlots[i], "CarSlot" + i))
                {
                    NotePad.DoLog("Тачка на " + (i + 1) + " позиции отсутствует");
                    emptySlots++;
                }
            }
            return emptySlots;
        }                
        public bool ReadyToRace()
        {
            return VisualCheck.Check(PointsAndRectangles.allrectangles["readyToRace"], "GarageRaceButton", 40, true);
        }                                            
        public bool TypeIsOpenned()
        {
            return VisualCheck.Check(PointsAndRectangles.allrectangles["typeIsOpenned"], "TypeIsOpenned", 5);
        }
        public bool FilterIsOpenned()
        {
            return VisualCheck.Check(PointsAndRectangles.allrectangles["filterIsOpenned"], "FilterIsOpenned", 5);
        }                                       
        public bool ActiveEvent()
        {
            return VisualCheck.Check(PointsAndRectangles.allrectangles["activeEvent"], "ButtonToEvent");
        }        
        public bool ClubMap()
        {
            if (VisualCheck.Check(PointsAndRectangles.allrectangles["clubMap"], "ClubMap", 400)) return true;
            if (ActiveEvent()) return true;
            return false;
        }
        public bool RaceOn()
        {
            if (VisualCheck.Check(PointsAndRectangles.allrectangles["raceOn"], "Race", 100))
                return true;
            return false;
        }        
        public bool ItsGarage()
        {
            return VisualCheck.Check(PointsAndRectangles.allrectangles["inGarage"], "InGarage", 20, true);
        }                          
        public bool ConditionActivated()
        {            
            return VisualCheck.Check(PointsAndRectangles.allrectangles["conditionActivated"], "ConditionActivated", 3, true);
        }        
        public bool ArrangementWindow()
        {
            return VisualCheck.Check(PointsAndRectangles.allrectangles["arrangementWindow"], "Arrangement");
        }
        public bool RedReadytoRace()
        {
            return VisualCheck.Check(PointsAndRectangles.allrectangles["readyToRace"], "RedRaceButton", 40);
        }                
    }
}