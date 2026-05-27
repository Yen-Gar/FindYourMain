using Microsoft.AspNetCore.Mvc;
using FindYourMain.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore; // 1. Dit is nodig voor de .Include()!

namespace FindYourMain.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // 2. Haal de statistieken op én neem de gekoppelde Characters mee
            var stats = _context.Stats.Include(s => s.Character).ToList();

            var bestCharacter = stats
                .GroupBy(s => s.CharacterID)
                .Select(g => new
                {
                    CharacterID = g.Key,
                    // 3. Pak de naam van het character uit de groep, of geef "Onbekend" als fallback
                    CharacterName = g.First().Character?.Name ?? "Onbekend",
                    TotalKills = g.Sum(x => x.Kills),
                    TotalDamage = g.Sum(x => x.Damage),
                    TotalAssists = g.Sum(x => x.Assists) // (Gecorrigeerd van Assests naar Assists)
                })
                .OrderByDescending(x => x.TotalKills)
                .FirstOrDefault();

            ViewBag.BestCharacter = bestCharacter;

            return View(stats);
        }
    }
}