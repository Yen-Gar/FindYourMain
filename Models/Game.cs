using System.ComponentModel.DataAnnotations;

namespace FindYourMain.Models
{
    public class Game
    {
        [Key]
        public int GameID { get; set; }

        public string Name { get; set; }
    }
}