using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOdevi.Models
{
    public class TrainerService
    {
        [Key]
        public int id { get; set; }
        public int trainerId { get; set; }
        [ForeignKey("trainerId")]

        public Trainer trainer { get; set; }
        public int serviceId { get; set; }
        [ForeignKey("serviceId")]

        public Service service { get; set; }
    }
}
