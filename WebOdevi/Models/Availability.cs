using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOdevi.Models
{
    public class Availability
    {
        [Key]
        public int Id { get; set; }
        
        public int TrainerId { get; set; }
        [ForeignKey("TrainerId")]

        public Trainer Trainer { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string DayOfWeek { get; set; }
    }
}
