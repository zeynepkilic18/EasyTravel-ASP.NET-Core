using EasyTravel.Data;
using Microsoft.AspNetCore.Mvc;

namespace EasyTravel.Controllers
{
    public class DestinationController : Controller
    {
        private readonly TravelContext _context;

        public DestinationController(TravelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var destinations = _context.Destinations.ToList(); 
            return View(destinations); 
        }
    }

}
