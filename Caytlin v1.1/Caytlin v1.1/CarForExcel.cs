using System;

namespace Caytlin_v1._1
{
    internal class CarForExcel : IComparable<CarForExcel>, IEquatable<CarForExcel>
    {
        public string country { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public int amount = 0;
        public string rq { get; set; }
        public int pictureNumber { get; set; }
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
        public int inUse { get; set; }
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
            return this.fullname().Equals(other.fullname());
        }
    }
}
