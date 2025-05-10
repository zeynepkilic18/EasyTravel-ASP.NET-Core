namespace EasyTravel.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }  // örnek: 3 günlük tur
    }
}
