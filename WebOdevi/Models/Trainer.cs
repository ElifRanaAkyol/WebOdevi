using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOdevi.Models
{
    public class Trainer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Eğitmen İsmi")]

        public string FullName { get; set; }
        [Display(Name = "Profil Fotoğrafı")]

        public string? ProfileImageUrl { get; set; }

        public int FitnessCenterId { get; set; }
        [ForeignKey("FitnessCenterId")]

        public FitnessCenter? FitnessCenter { get; set; }
        public List<TrainerSpecialization>? TrainerSpecializations { get; set; }
        public List<TrainerService>? TrainerServices { get; set; }
        public List<Availability>? TrainerAvailability { get; set; }
        public List<Appointment>? Appointments { get; set; }
    }
}
