namespace Caitlyn_v1._0
{
    internal class CarForExcel
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
        public string fullname()
        {
            return manufacturer + " " + model + " " + year;
        }
    }
}
