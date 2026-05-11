using Microsoft.EntityFrameworkCore;
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
            var conn = _context.Database.GetDbConnection().ConnectionString;
            Console.WriteLine("DB: " + conn);

            var stats = _context.Stats.ToList();

            return View(stats);
        }
    }
}