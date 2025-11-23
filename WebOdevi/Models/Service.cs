namespace WebOdevi.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int serviceDuration { get; set; } = 0;
        public List<TrainerService> trainerServices { get; set; }
    }
}
