namespace WebOdevi.Models
{
    public class Appointment
    {
        public int id { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public int trainerId { get; set; }
        public Trainer trainer { get; set; }
        public int serviceId { get; set; }
        public Service service { get; set; }
        public string appointmentDate { get; set; }
        public int appointmentStartTime { get; set; }
        public int appointmentEndTime { get; set; }
        public int appointmentDuration { get; set; } 





    }
}
