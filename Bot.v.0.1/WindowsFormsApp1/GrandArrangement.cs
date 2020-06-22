using System;
using System.Drawing;
using System.Threading;

namespace WindowsFormsApp1
{
    public class GrandArrangement
    {
        public void Arrangement(int[] a1, int[] b1, int[] c1)//величины не менялись с версии 0.04
        {
            Algorithms al = new Algorithms();
            TrackInfo ti = new TrackInfo();
            IdentifyCar idcar = new IdentifyCar();
            Point Finger1 = new Point(350, 770);
            Point Finger2 = new Point(540, 770);
            Point Finger3 = new Point(730, 770);
            Point Finger4 = new Point(900, 770);
            Point Finger5 = new Point(1100, 770);
            Point Track1 = new Point(185, 610);
            Point Track2 = new Point(410, 610);
            Point Track3 = new Point(635, 610);
            Point Track4 = new Point(865, 610);
            Point Track5 = new Point(1090, 610);

            Point[] a = { Finger1, Finger2, Finger3, Finger4, Finger5 };
            Point[] b = { Track1, Track2, Track3, Track4, Track5 };

            int[] saves = NotePad.ReadSaves();
            int[] carsid = new int[5];
            Array.Copy(saves, 3, carsid, 0, 5);//лостаем машины из текстовика
            carsid[0] = idcar.Identify1Car(carsid[0]);//converting picture id to car id
            carsid[1] = idcar.Identify1Car(carsid[1]);
            carsid[2] = idcar.Identify1Car(carsid[2]);
            carsid[3] = idcar.Identify1Car(carsid[3]);
            carsid[4] = idcar.Identify1Car(carsid[4]);
            double[] emptycar = { 0, 0, 0, 0, 0, 0, 0 };

            double[][] carstats = new double[5][];
            for (int m = 0; m < 5; m++)
            {
                carstats[m] = idcar.CarStats(carsid[m]);
            }

            string[] a2 = ti.IdentifyTracks(a1);//Track name                        
            string[] b2 = ti.IdentifyGround(b1);//Coverage            
            string[] c2 = ti.IdentifyWeather(c1);//Weather
            string[,] d = ti.TrackPackage(a2, b2, c2);//race full info
            int[] a3 = ti.TrackRank(a2);//Track Rank

            for (int i = 0; i < 4; i++)//track priority
            {
                for (int i1 = (i + 1); i1 < 5; i1++)
                {
                    if (a3[i] > a3[i1])
                    {
                        int f1 = a3[i];
                        a3[i] = a3[i1];
                        a3[i1] = f1;
                        Point f2 = b[i];
                        b[i] = b[i1];
                        b[i1] = f2;
                        for (int j = 0; j < 3; j++)
                        {
                            string var = d[j, i];
                            d[j, i] = d[j, i1];
                            d[j, i1] = var;
                        }
                    }
                }
            }

            for (int j = 0; j < 5; j++)//logic for dragndrop
            {
                Thread.Sleep(1000);
                double empty = -20000;
                double x;
                int usingfinger = 0;
                for (int n = 0; n < 5; n++)
                {
                    if (carstats[n] == emptycar)
                    {
                        x = -10000;
                    }
                    else
                    {
                        x = al.CalculateCompatibility(d[0, j], d[1, j], d[2, j], carstats[n]);
                    }

                    if (x > empty)
                    {
                        usingfinger = n;//choose the best car for track
                        empty = x;
                    }
                }
                Rat.DragnDrop(a[usingfinger], b[j]);//set choosen car on track
                carstats[usingfinger] = emptycar;//set used finger as empty
            }
        }        
    }    
}