using Microsoft.AspNetCore.Mvc;
using FindYourMain.Models;
using FindYourMain.Data;

namespace FindYourMain.Controllers
{
	public class StatisticsController : Controller
	{
		private readonly AppDbContext _context;

		public StatisticsController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Stats stats)
		{
			stats.Date = DateTime.Now;

			_context.Stats.Add(stats);

			_context.SaveChanges();

			return RedirectToAction("Index", "Home");
		}
	}
}