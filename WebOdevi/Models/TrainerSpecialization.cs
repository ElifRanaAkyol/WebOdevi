using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOdevi.Models
{
    public class TrainerSpecialization
    {
        [Key]
        public int id { get; set; }
        public int trainerId { get; set; }
        [ForeignKey("trainerId")]

        public Trainer trainer { get; set; }

        public int specializationId { get; set; }
        [ForeignKey("specializationId")]

        public Specialization specialization { get; set; }
    }
}
