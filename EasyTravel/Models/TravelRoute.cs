using System.ComponentModel.DataAnnotations;

namespace EasyTravel.Models
{
    public class TravelRoute
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }  
        public decimal Price { get; set; }
        public int TravelId { get; set; }  
        public Travel Travel { get; set; }
    }
}

