﻿using System;
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
            int[] carpicture = new int[5];
            string[] carsname = new string[5];
            Array.Copy(saves, 2, carpicture, 0, 5);//читаем машины из текстовика
            carsname[0] = idcar.Identify1Car(carpicture[0]);//converting picture id to car id
            carsname[1] = idcar.Identify1Car(carpicture[1]);
            carsname[2] = idcar.Identify1Car(carpicture[2]);
            carsname[3] = idcar.Identify1Car(carpicture[3]);
            carsname[4] = idcar.Identify1Car(carpicture[4]);
            //double[] emptycar = { 0, 0, 0, 0, 0, 0, 0 };

            double[][] carstats = new double[5][];
            for (int m = 0; m < 5; m++)
            {
                carstats[m] = idcar.CarStats(carsname[m]);
            }

            string[] a2 = ti.IdentifyTracks(a1);//Track name                        
            string[] b2 = ti.IdentifyGround(b1);//Coverage            
            string[] c2 = ti.IdentifyWeather(c1);//Weather
            string[,] d = ti.TrackPackage(a2, b2, c2);//race full info

            /*old
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
            */
            //==================================================
            //New Logic

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
                Rat.DragnDrop(a[rightarranfement[j]], b[j]);//set choosen car on track
            }
        }        
    }    
}