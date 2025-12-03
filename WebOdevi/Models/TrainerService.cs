using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOdevi.Models
{
    public class TrainerService
    {
        [Key]
        public int Id { get; set; }
        public int TrainerId { get; set; }
        [ForeignKey("TrainerId")]

        public Trainer Trainer { get; set; }
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]

        public Service Service { get; set; }
    }
}
