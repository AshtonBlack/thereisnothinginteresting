using Rectangle = System.Drawing.Rectangle;

namespace Caitlyn_v1._0
{
    internal class SolveSpecialOffer:Action
    {
        public override bool SolveTheIssue()
        {
            Rectangle bounds = PointsAndRectangles.allrectangles["SpecialOffer"];   
            string testPicture = @"HeadPictures\TestSpecialOffer";
            string originalPicture = @"HeadPictures\OriginalSpecialOffer";
            MasterOfPictures.BW2CaptureWithBlackText(bounds, testPicture);
            for (int i = 1; i < 6; i++)
            {                
                if (MasterOfPictures.VerifyBW(testPicture, originalPicture + i.ToString(), 20))
                {
                    NotePad.DoLog("Visual matching with SpecialOffer");
                    Rat.Clk(PointsAndRectangles.allpoints["CrossForSpecialOffer"]);
                    return true;
                }
            }
            return false;
        }
    }
}
