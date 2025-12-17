using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebOdevi.Data.Enums;

namespace WebOdevi.Models
{
    public class Availability
    {
        [Key]
        public int Id { get; set; }
        
        public int TrainerId { get; set; }
        [ForeignKey("TrainerId")]

        public Trainer Trainer { get; set; }
        public string? Hour { get; set; }
        public DaysOfWeek? DayOfWeek { get; set; }
    }
}
