﻿using System;

namespace Caitlyn_v1._0
{
    public class CarForExcel : IComparable<CarForExcel>, IEquatable<CarForExcel>
    {
        public string pictureId { get; set; }
        public string country { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public int amount = 0;
        public string rq { get; set; }
        public string rarity { get; set; }
        public string tires { get; set; }
        public string drive { get; set; }
        public string fuel { get; set; }
        public string body { get; set; }
        public string seats { get; set; }
        public string tags { get; set; }
        public string clearance { get; set; }
        public string acceleration { get; set; }
        public string speed { get; set; }
        public string grip { get; set; }
        public string weight { get; set; }
        public string abs { get; set; }
        public string tcs { get; set; }
        public int inUse { get; set; }
        public CarForExcel()
        {

        }
        public CarForExcel(int id)
        {
            foreach (CarForExcel car in CarsDB.fulltablearray)
            {
                if (car.pictureId == id.ToString())
                {
                    pictureId = car.pictureId;
                    country= car.country;
                    manufacturer=car.manufacturer;
                    model= car.model;
                    year= car.year;
                    amount= car.amount;
                    rq= car.rq;
                    rarity= car.rarity;
                    tires= car.tires;
                    drive= car.drive;
                    fuel= car.fuel;
                    body= car.body;
                    seats= car.seats;
                    tags= car.tags;
                    clearance= car.clearance;
                    acceleration= car.acceleration;
                    speed= car.speed;
                    grip= car.grip;
                    weight= car.weight;
                    inUse = 0;
                }
            }
        }
        public string fullname()
        {
            return manufacturer + " " + model + " " + year;
        }
        public int CompareTo(CarForExcel another)
        {
            int ownRQ = Convert.ToInt32(this.rq);
            int anotherRQ = Convert.ToInt32(another.rq);
            return ownRQ.CompareTo(anotherRQ);
        }
        public bool Equals(CarForExcel other)
        {
            return fullname().Equals(other.fullname());
        }
    }
}