using System.Drawing;

namespace Caitlyn_v1._0
{
    public static class VisualCheck
    {
        public static bool Check(Rectangle bounds, string name)
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
        public static bool Check(Rectangle bounds, string name, int errors)
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
    }
}