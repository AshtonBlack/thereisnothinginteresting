using System.Drawing;

namespace Caitlyn_v1._0
{
    internal class SkipableMoment
    {
        Rectangle bounds;
        string name;
        Point clkToSkip;
        public SkipableMoment(Rectangle bounds, string name, Point clkToSkip)
        {
            this.bounds = bounds;
            this.name = name;
            this.clkToSkip = clkToSkip;
        }
        public void Skip()
        {
            if (Check(bounds, name))
            {
                Rat.Clk(clkToSkip);
            }
        }
        bool Check(Rectangle bounds, string name)
        {
            string testPicture = @"HeadPictures\Test" + name;
            string originalPicture = @"HeadPictures\Original" + name;
            MasterOfPictures.MakePicture(bounds, testPicture);
            if (MasterOfPictures.Verify(testPicture, originalPicture)) return true;
            return false;
        }
    }
}