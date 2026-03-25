using System.Collections.Generic;
using System.Drawing;

namespace Caitlyn_v1._0
{
    static class PointsAndRectangles
    {
        public static Dictionary<string, Point> allpoints { get; set; }
        public static Dictionary<string, Rectangle> allrectangles { get; set; }
        static PointsAndRectangles()
        {
            allpoints = new Dictionary<string, Point>();
            NotePad.ReadClkPoints();
            allrectangles = new Dictionary<string, Rectangle>();
            NotePad.ReadCaptureRectangles();
        }
    }
}
