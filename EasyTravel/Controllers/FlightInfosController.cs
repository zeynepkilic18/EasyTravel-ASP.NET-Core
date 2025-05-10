using EasyTravel.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyTravel.Controllers
{
    public class FlightInfosController : Controller
    {
        private readonly TravelContext _context;

        public FlightInfosController(TravelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var flights = await _context.FlightInfos.ToListAsync();
            return View(flights);
        }
    }
}
