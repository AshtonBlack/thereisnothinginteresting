namespace botDBUpdater
{
    class Car
    {
        public string country { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public int amount = 0;
        public string pictureId { get; set; }
        public string fullname()
        {
            return manufacturer + " " + model + " " + year;
        }
    }
}
