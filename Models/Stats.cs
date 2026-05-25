using System;
using System.ComponentModel.DataAnnotations;

namespace FindYourMain.Models
{
    public class Stats
    {
        [Key]
        public int StatID { get; set; }

        [Required(ErrorMessage = "Aantal kills is verplicht.")]
        public int? Kills { get; set; }

        [Required(ErrorMessage = "Aantal assists is verplicht.")]
        public int? Assists { get; set; }

        [Required(ErrorMessage = "Damage is verplicht.")]
        public int? Damage { get; set; }

        public DateTime Date { get; set; }

        public string UserID { get; set; }

        [Required(ErrorMessage = "Kies een Character ID.")]
        public int? CharacterID { get; set; }

        public Character Character { get; set; }
    }
}