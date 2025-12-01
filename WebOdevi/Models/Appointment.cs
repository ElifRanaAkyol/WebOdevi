using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebOdevi.Data.Enums;
namespace WebOdevi.Models
{
    public class Appointment
    {
        [Key]
        public int id { get; set; }
        public string userId { get; set; }
        [ForeignKey("userId")]

        public User user { get; set; }
        
        public int trainerId { get; set; }
        [ForeignKey("trainerId")]

        public Trainer trainer { get; set; }
        public int serviceId { get; set; }
        [ForeignKey("serviceId")]

        public Service service { get; set; }
        public string appointmentDate { get; set; }
        public int appointmentStartTime { get; set; }
        public int appointmentEndTime { get; set; }
        public int appointmentDuration { get; set; }

        public AppointmentStatus status { get; set; }



    }
}
