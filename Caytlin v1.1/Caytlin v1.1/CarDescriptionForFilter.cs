namespace Caytlin_v1._1
{
    internal class CarDescriptionForFilter
    {
        public string rarity;
        public string tires;
        public string drive;
        public string clearance;
        public string country;
        public CarDescriptionForFilter(CarForExcel car)
        {
            rarity = car.rarity;
            tires = car.tires;
            drive = car.drive;
            clearance = car.clearance;
            country = car.country;
        }
    }
}
