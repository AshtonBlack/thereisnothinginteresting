using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Caitlyn_v1._0
{
    public class GrandArrangement
    {
        /*
        //legacy
        public void Arrangement(int[] trackName, int[] coverage, int[] weather)
        //legacy
        */
        public void Arrangement()
        {
            Algorithms al = new Algorithms();
            /*
            TrackInfo ti = new TrackInfo();//legacy    
            */
            int[] carpictures = NotePad.ReadCars();
            List<Car> cars = new List<Car>();
            foreach (int carpicture in carpictures)
            {
                cars.Add(new Car(carpicture));
            }                        
            int[] rightarranfement = new int[5];
            double arrangementPoints = -1000000;
            /*
            //legacy
            string[,] d = ti.TrackPackage(trackName, coverage, weather);//race full info
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
                                                double point = al.CalculateCompatibility(d[0, 0], d[1, 0], d[2, 0], cars[i1]) +
                                                    al.CalculateCompatibility(d[0, 1], d[1, 1], d[2, 1], cars[i2]) +
                                                    al.CalculateCompatibility(d[0, 2], d[1, 2], d[2, 2], cars[i3]) +
                                                    al.CalculateCompatibility(d[0, 3], d[1, 3], d[2, 3], cars[i4]) +
                                                    al.CalculateCompatibility(d[0, 4], d[1, 4], d[2, 4], cars[i5]);
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
            //legacy
            */
            //new
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
                                                double point = al.CalculateCompatibility(Condition.previousTracks[0].track, Condition.previousTracks[0].ground, Condition.previousTracks[0].weather, cars[i1]) +
                                                    al.CalculateCompatibility(Condition.previousTracks[1].track, Condition.previousTracks[1].ground, Condition.previousTracks[1].weather, cars[i2]) +
                                                    al.CalculateCompatibility(Condition.previousTracks[2].track, Condition.previousTracks[2].ground, Condition.previousTracks[2].weather, cars[i3]) +
                                                    al.CalculateCompatibility(Condition.previousTracks[3].track, Condition.previousTracks[3].ground, Condition.previousTracks[3].weather, cars[i4]) +
                                                    al.CalculateCompatibility(Condition.previousTracks[4].track, Condition.previousTracks[4].ground, Condition.previousTracks[4].weather, cars[i5]);
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
            //new
            Point[] a = { PointsAndRectangles.Finger1, PointsAndRectangles.Finger2, PointsAndRectangles.Finger3, PointsAndRectangles.Finger4, PointsAndRectangles.Finger5 };
            Point[] b = { PointsAndRectangles.Track1position, PointsAndRectangles.Track2position, PointsAndRectangles.Track3position, PointsAndRectangles.Track4position, PointsAndRectangles.Track5position };
            for (int j = 0; j < 5; j++)//logic for dragndrop
            {
                Thread.Sleep(1000);
                Rat.DragnDropFast(a[rightarranfement[j]], b[j]);//set choosen car on track
            }
        }
    }
}
