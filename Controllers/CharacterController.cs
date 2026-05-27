using FindYourMain.Data;
using FindYourMain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FindYourMain.Controllers
{
    public class CharacterController : Controller
    {
        private readonly AppDbContext _context;

        // De constructor
        public CharacterController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Hiermee opent de 'Generate' pagina in de browser
        [HttpGet]
        public IActionResult Generate()
        {
            return View();
        }

        // POST: Jouw logica om het karakter te berekenen en op te slaan
        [HttpPost]
        public IActionResult Generate(string game, string role, string playstyle)
        {
            Character character;

            // ===== OVERWATCH =====
            if (game == "Overwatch")
            {
                if (role == "Tank")
                {
                    if (playstyle == "Aggressive")
                    {
                        character = new Character { Name = "Reinhardt", Role = role, Game = game, Playstyle = playstyle };
                    }
                    else if (playstyle == "Fast Movement")
                    {
                        character = new Character { Name = "Wrecking Ball", Role = role, Game = game, Playstyle = playstyle };
                    }
                    else
                    {
                        character = new Character { Name = "Winston", Role = role, Game = game, Playstyle = playstyle };
                    }
                }
                else if (role == "Support")
                {
                    if (playstyle == "Healer")
                    {
                        character = new Character { Name = "Mercy", Role = role, Game = game, Playstyle = playstyle };
                    }
                    else
                    {
                        character = new Character { Name = "Lucio", Role = role, Game = game, Playstyle = playstyle };
                    }
                }
                else
                {
                    if (playstyle == "Fast Movement")
                    {
                        character = new Character { Name = "Tracer", Role = role, Game = game, Playstyle = playstyle };
                    }
                    else
                    {
                        character = new Character { Name = "Soldier 76", Role = role, Game = game, Playstyle = playstyle };
                    }
                }
            }
            // ===== VALORANT =====
            else if (game == "Valorant")
            {
                if (role == "Duelist")
                {
                    if (playstyle == "Fast Movement")
                    {
                        character = new Character { Name = "Neon", Role = role, Game = game, Playstyle = playstyle };
                    }
                    else if (playstyle == "Healer")
                    {
                        character = new Character { Name = "Phoenix", Role = role, Game = game, Playstyle = playstyle };
                    }
                    else
                    {
                        character = new Character { Name = "Jett", Role = role, Game = game, Playstyle = playstyle };
                    }
                }
                else if (role == "Initiator")
                {
                    if (playstyle == "Tactical")
                    {
                        character = new Character { Name = "Sova", Role = role, Game = game, Playstyle = playstyle };
                    }
                    else
                    {
                        character = new Character { Name = "Fade", Role = role, Game = game, Playstyle = playstyle };
                    }
                }
                else if (role == "Sentinel")
                {
                    if (playstyle == "Tactical")
                    {
                        character = new Character { Name = "Cypher", Role = role, Game = game, Playstyle = playstyle };
                    }
                    else
                    {
                        character = new Character { Name = "Sage", Role = role, Game = game, Playstyle = playstyle };
                    }
                }
                else if (role == "Controller")
                {
                    if (playstyle == "Aggressive")
                    {
                        character = new Character { Name = "Clove", Role = role, Game = game, Playstyle = playstyle };
                    }
                    else
                    {
                        character = new Character { Name = "Omen", Role = role, Game = game, Playstyle = playstyle };
                    }
                }
                else
                {
                    character = new Character { Name = "Jett", Role = role, Game = game, Playstyle = playstyle };
                }
            }
            // ===== LEAGUE OF LEGENDS =====
            else
            {
                if (playstyle == "Aggressive")
                {
                    character = new Character { Name = "Yasuo", Role = role, Game = game, Playstyle = playstyle };
                }
                else if (playstyle == "Fast Movement")
                {
                    character = new Character { Name = "Ahri", Role = role, Game = game, Playstyle = playstyle };
                }
                else if (playstyle == "Healer")
                {
                    character = new Character { Name = "Soraka", Role = role, Game = game, Playstyle = playstyle };
                }
                else
                {
                    character = new Character { Name = "Lux", Role = role, Game = game, Playstyle = playstyle };
                }
            }

            // ===== DATABASE CONTROLE & SAVE =====
            // ===== DATABASE CONTROLE & SAVE =====
            var bestaandCharacter = _context.Characters
                .FirstOrDefault(c => c.Name.ToLower() == character.Name.ToLower());

            if (bestaandCharacter != null)
            {
                character = bestaandCharacter;
            }
            else
            {
                character.CharacterID = Guid.NewGuid().ToString();

                _context.Characters.Add(character);
                _context.SaveChanges();
            }

            return View("Result", character);
        } 
    } 
} 
