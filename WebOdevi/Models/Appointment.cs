using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebOdevi.Data.Enums;
namespace WebOdevi.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]

        public User User { get; set; }
        
        public int TrainerId { get; set; }
        [ForeignKey("TrainerId")]

        public Trainer Trainer { get; set; }
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]

        public Service Service { get; set; }
        public string AppointmentDate { get; set; }
        public int AppointmentStartTime { get; set; }
        public int AppointmentEndTime { get; set; }
        public int AppointmentDuration { get; set; }

        public AppointmentStatus Status { get; set; }



    }
}
