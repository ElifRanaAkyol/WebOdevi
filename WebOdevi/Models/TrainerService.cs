namespace WebOdevi.Models
{
    public class TrainerService
    {
        public int id { get; set; }
        public int trainerId { get; set; }
        public Trainer trainer { get; set; }
        public int serviceId { get; set; }
        public Service service { get; set; }
    }
}
