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
        public string CharacterID { get; set; }

        public Character? Character { get; set; }
    }
}