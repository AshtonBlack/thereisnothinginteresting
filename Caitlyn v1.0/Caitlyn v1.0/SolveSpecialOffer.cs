namespace Caitlyn_v1._0
{
    internal class SolveSpecialOffer:Action
    {
        public override bool SolveTheIssue()
        {  
            string testPicture = @"HeadPictures\TestSpecialOffer";
            string originalPicture = @"HeadPictures\OriginalSpecialOffer";
            MasterOfPictures.BW2CaptureWithBlackText(PointsAndRectangles.allrectangles["SpecialOffer"], testPicture);
            if (MasterOfPictures.VerifyBW(testPicture, originalPicture, 20))
            {
                NotePad.DoLog("Visual matching with SpecialOffer");
                Rat.Clk(PointsAndRectangles.allpoints["CrossForSpecialOffer"]);
                return true;
            }
            return false;
        }
    }
}
