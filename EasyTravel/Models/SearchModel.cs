namespace EasyTravel.Models
{
    public class SearchModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }

}
