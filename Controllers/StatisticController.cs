using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FindYourMain.Data;
using FindYourMain.Models;

[Authorize]
public class StatisticsController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public StatisticsController(AppDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Stats stats)
    {
        // 1. Haal de huidige ingelogde gebruiker op
        var user = await _userManager.GetUserAsync(User);

        // 2. Controleer of er wel iemand is ingelogd
        if (user == null)
        {
            return Challenge(); // Stuurt je naar de login als je sessie is verlopen
        }

        // 3. Koppel de statistiek aan de ECHTE gebruiker (Foreign Key fix)
        stats.UserID = user.Id;
        stats.Date = DateTime.Now;

        // 4. FIX: Controleer of het formulier correct is ingevuld (voorkomt lege invoer crash)
        if (!ModelState.IsValid)
        {
            return View(stats); // Stuurt de gebruiker terug naar het formulier met foutmeldingen
        }

        // 5. Opslaan in de database
        _context.Stats.Add(stats);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Dashboard");
    }
}