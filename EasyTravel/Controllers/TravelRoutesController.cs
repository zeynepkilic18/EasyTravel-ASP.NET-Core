using EasyTravel.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyTravel.Controllers
{
    public class TravelRoutesController : Controller
    {
        private readonly TravelContext _context;

        public TravelRoutesController(TravelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var routes = await _context.TravelRoutes.ToListAsync();
            return View(routes);
        }
    }
}
