using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebOdevi.Data.Enums;
using WebOdevi.Models;

namespace WebOdevi.Models { 
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public int TrainerId { get; set; }
        [ForeignKey("TrainerId")]
        public Trainer? Trainer { get; set; } 

        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service? Service { get; set; } 

        public string Hour { get; set; }
        public DaysOfWeek DayOfWeek { get; set; }

        public AppointmentStatus Status { get; set; }

    }
}