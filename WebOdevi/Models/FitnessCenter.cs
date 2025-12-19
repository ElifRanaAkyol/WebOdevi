using System.ComponentModel.DataAnnotations;

namespace WebOdevi.Models
{
    public class FitnessCenter
    {

        [Key]
        public int Id { get; set; }
        [Display(Name = "Spor Salonu İsmi")]
        public List<Service>? Services { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public List<FitnessCenterServices>? FitnessCenterServices { get; set; }
        public List<Trainer>? Trainers { get; set; }
    }
}
