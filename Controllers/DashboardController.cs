using Microsoft.AspNetCore.Mvc;
using FindYourMain.Data;
using System.Linq;

namespace FindYourMain.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var stats = _context.Stats.ToList();

            return View(stats);
        }
    }
}