namespace WebOdevi.Models
{
    public class Trainer
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public int fitnessCenterId { get; set; }
        public FitnessCenter fitnessCenter { get; set; }
        public List<TrainerSpecialization> trainerSpecializations { get; set; }
        public List<Service> trainerServices { get; set; }
        public List<TrainerAvailability> TrainerAvailability { get; set; }
        public List<Appointment> appointments { get; set; }
    }
}
