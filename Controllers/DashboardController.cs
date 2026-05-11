using Microsoft.AspNetCore.Mvc;
using FindYourMain.Data;
using System.Linq;

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
            var stats = _context.Stats.ToList();

            var bestCharacter = stats
                .GroupBy(s => s.CharacterID)
                .Select(g => new
                {
                    CharacterID = g.Key,
                    TotalKills = g.Sum(x => x.Kills),
                    TotalDamage = g.Sum(x => x.Damage),
                    TotalAssists = g.Sum(x => x.Assists)
                })
                .OrderByDescending(x => x.TotalKills)
                .FirstOrDefault();

            ViewBag.BestCharacter = bestCharacter;

            return View(stats);
        }
    }
}