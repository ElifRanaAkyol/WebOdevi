namespace WebOdevi.Models
{
    public class Availability
    {
        public int id { get; set; }
        public int trainerId { get; set; }
        public Trainer trainer { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string dayOfWeek { get; set; }
    }
}
