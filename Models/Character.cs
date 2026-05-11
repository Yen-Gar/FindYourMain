using System.ComponentModel.DataAnnotations;

namespace FindYourMain.Models
{
    public class Character
    {
        [Key]
        public int CharacterID { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string Playstyle { get; set; }

        public int GameID { get; set; }
    }
}