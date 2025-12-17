using System.ComponentModel.DataAnnotations;

namespace WebOdevi.Models.ViewModels
{
    public class DietInputViewModel
    {
        [Required]
        [Range(140, 220)]
        public int Height { get; set; }

        [Required]
        [Range(40, 200)]
        public int Weight { get; set; }

        [Required]
        public string BodyType { get; set; }

        [Required]
        public string Goal { get; set; }
    }
}
