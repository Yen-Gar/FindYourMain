using Microsoft.AspNetCore.Mvc;
using FindYourMain.Models;

namespace FindYourMain.Controllers
{
    public class CharacterController : Controller
    {
        public IActionResult Generate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Generate(string game, string role)
        {
            Character generatedCharacter = new Character();

            if (game == "Overwatch")
            {
                if (role == "Tank")
                {
                    generatedCharacter.Name = "Reinhardt";
                    generatedCharacter.Role = "Tank";
                }
                else if (role == "Support")
                {
                    generatedCharacter.Name = "Mercy";
                    generatedCharacter.Role = "Support";
                }
                else
                {
                    generatedCharacter.Name = "Tracer";
                    generatedCharacter.Role = "DPS";
                }
            }

            return View("Result", generatedCharacter);
        }
    }
}