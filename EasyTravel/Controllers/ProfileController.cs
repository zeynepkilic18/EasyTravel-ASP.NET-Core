using EasyTravel.Services; 
using Microsoft.AspNetCore.Mvc;
using EasyTravel.Data;
using EasyTravel.Models;
using System.Threading.Tasks;

[Route("Users")]
public class ProfileController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProfileController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("Edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user); // Views/Users/Edit.cshtml 
    }

    [HttpPost("Edit/{id}")]
    public async Task<IActionResult> Edit(User user) 
    {
        if (!ModelState.IsValid)
            return View(user);

        _context.Update(user);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Dashboard");
    }
}
