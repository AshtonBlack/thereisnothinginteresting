using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Caitlyn_v1._0
{
    public class GrandArrangement
    {
        public void Arrangement()
        {
            Algorithms al = new Algorithms();
            int[] carpictures = NotePad.ReadCars();
            List<CarForExcel> cars = new List<CarForExcel>();
            foreach (int carpicture in carpictures)
            {
                cars.Add(new CarForExcel(carpicture));
            }
            NotePad.DoLogWithoutTime("Cars in the hand:");
            foreach(CarForExcel car in cars)
            {
                NotePad.DoLogWithoutTime(car.fullname());
            }
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
                                                double point = al.CalculateCompatibility(cars[i1], Condition.tracks[0]) +
                                                    al.CalculateCompatibility(cars[i2], Condition.tracks[1]) +
                                                    al.CalculateCompatibility(cars[i3], Condition.tracks[2]) +
                                                    al.CalculateCompatibility(cars[i4], Condition.tracks[3]) +
                                                    al.CalculateCompatibility(cars[i5], Condition.tracks[4]);
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
