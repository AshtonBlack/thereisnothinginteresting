namespace Caitlyn_v1._0
{
    internal class SolveSpecialOffer:Action
    {
        public override bool SolveTheIssue()
        {  
            string testPicture = @"HeadPictures\TestSpecialOffer";
            string originalPicture = @"HeadPictures\OriginalSpecialOffer";
            MasterOfPictures.BW2Capture(PointsAndRectangles.allrectangles["SpecialOffer"], testPicture);
            if (MasterOfPictures.VerifyBW(testPicture, originalPicture, 20))
            {
                NotePad.DoLog("Visual matching with SpecialOffer");
                System.Windows.Forms.SendKeys.SendWait("{ESC}");
                return true;
            }
            return false;
        }
    }
}
