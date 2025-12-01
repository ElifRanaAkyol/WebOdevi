using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOdevi.Models
{
    public class Availability
    {
        [Key]
        public int id { get; set; }
        
        public int trainerId { get; set; }
        [ForeignKey("trainerId")]

        public Trainer trainer { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string dayOfWeek { get; set; }
    }
}
