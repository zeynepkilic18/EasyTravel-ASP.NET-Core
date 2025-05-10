namespace EasyTravel.Models
{
    public class DashboardPageViewModel
    {
        public List<Destination> Destinations { get; set; }
        public User User { get; set; }
        public List<Travel> Travels { get; set; }
        public SearchModel Search { get; set; }
        
    }

}
