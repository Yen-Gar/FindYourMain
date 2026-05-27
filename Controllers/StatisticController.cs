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
    public async Task<IActionResult> Create(Stats stats, string characterNameInvoer)
    {
        // 1. Haal de huidige ingelogde gebruiker op
        var user = await _userManager.GetUserAsync(User);

        // 2. Controleer of er wel iemand is ingelogd
        if (user == null)
        {
            return Challenge();
        }

        // 3. Koppel de statistiek aan de ECHTE gebruiker
        stats.UserID = user.Id;
        stats.Date = DateTime.Now;

        
        if (!string.IsNullOrEmpty(characterNameInvoer))
        {
            // Zoek of het karakter al bestaat (bijv. "Jinx")
            var bestaandCharacter = _context.Characters
                .FirstOrDefault(c => c.Name.ToLower() == characterNameInvoer.ToLower());

            if (bestaandCharacter != null)
            {
                stats.CharacterID = bestaandCharacter.CharacterID; 
            }
            else
            {
                // Bestaat nog niet? Maak hem live aan!
                var nieuwCharacter = new Character { Name = characterNameInvoer };
                _context.Characters.Add(nieuwCharacter);
                await _context.SaveChangesAsync();

                stats.CharacterID = nieuwCharacter.CharacterID;
            }
        }
        // =============================================

        // 4. Opslaan in de database
        _context.Stats.Add(stats);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Dashboard");
    }
}