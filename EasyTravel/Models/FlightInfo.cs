using System;
using System.ComponentModel.DataAnnotations;

namespace EasyTravel.Models
{
    public class FlightInfo
    {
        public int Id { get; set; }
        public string Airline { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
        public decimal Price { get; set; }
        public TimeSpan FlightDuration { get; set; }
        public string Gate { get; set; }
    }
}
