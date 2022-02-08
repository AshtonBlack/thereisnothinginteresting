using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace WindowsFormsApp1 //universal
{
    public class GrandArrangement
    {
        public void Arrangement(int[] trackName, int[] coverage, int[] weather)
        {
            Algorithms al = new Algorithms();
            TrackInfo ti = new TrackInfo();
            Car car = new Car();            

            Point[] a = { PointsAndRectangles.Finger1, PointsAndRectangles.Finger2, PointsAndRectangles.Finger3, PointsAndRectangles.Finger4, PointsAndRectangles.Finger5 };
            Point[] b = { PointsAndRectangles.Track1position, PointsAndRectangles.Track2position, PointsAndRectangles.Track3position, PointsAndRectangles.Track4position, PointsAndRectangles.Track5position };

            int[] carpictures = NotePad.ReadCars();
            List<string> carnames = new List<string>();
            foreach(int carpicture in carpictures)
            {
                carnames.Add(car.IdentifyCar(carpicture)); //converting picture id to car id
            }

            double[][] carstats = new double[5][];
            for (int m = 0; m < 5; m++)
            {
                carstats[m] = car.CarStats(carnames[m]);
            }

            string[,] d = ti.TrackPackage(trackName, coverage, weather);//race full info
            
            int[] rightarranfement = new int[5];
            double arrangementPoints = -1000000;

            for (int i1 = 0; i1 < 5; i1++)
            {
                for (int i2 = 0; i2 < 5; i2++)
                {
                    if (i2 != i1)
                    {
                        for (int i3 = 0; i3 < 5; i3++)
                        {
                            if (i3 != i1 && i3 != i2)
                            {
                                for (int i4 = 0; i4 < 5; i4++)
                                {
                                    if (i4 != i1 && i4 != i2 && i4 != i3)
                                    {
                                        for (int i5 = 0; i5 < 5; i5++)
                                        {
                                            if (i5 != i1 && i5 != i2 && i5 != i3 && i5 != i4)
                                            {
                                                double point = al.CalculateCompatibility(d[0, 0], d[1, 0], d[2, 0], carstats[i1]) +
                                                    al.CalculateCompatibility(d[0, 1], d[1, 1], d[2, 1], carstats[i2]) +
                                                    al.CalculateCompatibility(d[0, 2], d[1, 2], d[2, 2], carstats[i3]) +
                                                    al.CalculateCompatibility(d[0, 3], d[1, 3], d[2, 3], carstats[i4]) +
                                                    al.CalculateCompatibility(d[0, 4], d[1, 4], d[2, 4], carstats[i5]);
                                                if (point > arrangementPoints)
                                                {
                                                    rightarranfement = new int[] { i1, i2, i3, i4, i5 };
                                                    arrangementPoints = point;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            for (int j = 0; j < 5; j++)//logic for dragndrop
            {
                Thread.Sleep(1000);
                Rat.DragnDropFast(a[rightarranfement[j]], b[j]);//set choosen car on track
            }
        }        
    }    
}