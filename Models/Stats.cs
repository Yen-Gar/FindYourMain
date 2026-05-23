using System.ComponentModel.DataAnnotations;

namespace FindYourMain.Models
{
    public class Stats
    {
        [Key]
        public int StatID { get; set; }

        public int Kills { get; set; }
        public int Assists { get; set; }
        public int Damage { get; set; }
        public DateTime Date { get; set; }

        public string UserID { get; set; }
        public int CharacterID { get; set; }

        public Character Character { get; set; }
    }
}