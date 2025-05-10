using EasyTravel.Data;
using EasyTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class HotelsController : Controller
{
    private readonly TravelContext _context;

    public HotelsController(TravelContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var hotels = await _context.Hotels.ToListAsync();
        return View(hotels);
    }
}
