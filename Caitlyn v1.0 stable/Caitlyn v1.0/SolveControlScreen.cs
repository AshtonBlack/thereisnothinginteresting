namespace Caitlyn_v1._0
{
    internal class SolveControlScreen:Action
    {
        public override bool SolveTheIssue()
        {
            MasterOfPictures.BW2CaptureWithBlackText(PointsAndRectangles.allrectangles["controlScreen"], @"HeadPictures\TestControlScreen");
            if (MasterOfPictures.VerifyBW(@"HeadPictures\TestControlScreen", @"HeadPictures\OriginalControlScreen", 20))
            {
                NotePad.DoLog("Visual matching with controlScreen");
                Rat.Clk(PointsAndRectangles.allpoints["controlScreenToGarage"]);
                return true;
            }
            if (MasterOfPictures.VerifyBW(@"HeadPictures\TestControlScreen", @"HeadPictures\OriginalBugControlScreen", 20))
            {
                NotePad.DoLog("Visual matching with BugControlScreen");
                Rat.Clk(PointsAndRectangles.allpoints["buttonBack"]);
                return true;
            }
            return false;
        }
    }
}
