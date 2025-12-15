namespace WebOdevi.Models
{
    public class TrainerAppointmentVM
    {
        public Trainer Trainer { get; set; }
        public Appointment Appointment { get; set; }

        public List<TrainerService> TrainerServices { get; set; }
    }
}
