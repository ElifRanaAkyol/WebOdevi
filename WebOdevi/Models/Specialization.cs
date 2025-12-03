using System.ComponentModel.DataAnnotations;

namespace WebOdevi.Models
{
    public class Specialization
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TrainerSpecialization> TrainerSpecializations { get; set; }
    }
}
