using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace Caitlyn_v1._0
{
    internal class ReasonForRestart
    {
        Rectangle bounds;
        string name;
        public ReasonForRestart(Rectangle bounds, string name)
        {
            this.bounds = bounds;
            this.name = name;
        }        
        public void Check()
        {
            string testPicture = @"HeadPictures\Test" + name;
            string originalPicture = @"HeadPictures\Original" + name;
            MasterOfPictures.MakePicture(bounds, testPicture);
            if (MasterOfPictures.Verify(testPicture, originalPicture))
            {
                RestartBot();
            }
        }
        void RestartBot()
        {
            Rat.Clk(PointsAndRectangles.noxClosing);//close Nox
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.noxClosingAcceptance);//accept Nox close
            Thread.Sleep(1000);
            Process.Start(@"C:\Bot\BotRestarter\BotRestarter\bin\Debug\BotRestarter.exe");
            Process.GetCurrentProcess().Kill();
        }
    }
}
