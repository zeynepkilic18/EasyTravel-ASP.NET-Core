using System.ComponentModel.DataAnnotations;

namespace EasyTravel.Models
{
    public class Destination
    {
        public int Id { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
