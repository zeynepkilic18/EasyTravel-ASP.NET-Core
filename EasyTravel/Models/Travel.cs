using System.ComponentModel.DataAnnotations;

namespace EasyTravel.Models
{
    public class Travel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } // Seyahatin adı

        [Required]
        public string Description { get; set; } // Seyahatin açıklaması

        [Required]
        public decimal Price { get; set; } // Seyahatin fiyatı

        // Foreign key for Destination
        public int DestinationId { get; set; } // Seyahatin gidileceği destinasyonun ID'si

        // Navigation property to related Destination
        public Destination Destination { get; set; } // Seyahatin gittiği destinasyon
    }
}
