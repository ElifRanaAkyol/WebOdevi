using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOdevi.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ServiceDuration { get; set; } = 0;
        
        public int FitnessCenterId { get; set; }
        [ForeignKey("FitnessCenterId")]

        public FitnessCenter FitnessCenter { get; set; }
        public List<TrainerService> TrainerServices { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}
