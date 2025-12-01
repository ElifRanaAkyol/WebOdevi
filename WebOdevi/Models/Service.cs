using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOdevi.Models
{
    public class Service
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public int serviceDuration { get; set; } = 0;
        
        public int fitnessCenterId { get; set; }
        [ForeignKey("fitnessCenterId")]

        public FitnessCenter fitnessCenter { get; set; }
        public List<TrainerService> trainerServices { get; set; }
        public List<Appointment> appointments { get; set; }

    }
}
