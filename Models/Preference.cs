using System.ComponentModel.DataAnnotations;

namespace FindYourMain.Models
{
    public class Preference
    {
        [Key]
        public int PreferenceID { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public int UserID { get; set; }
    }
}