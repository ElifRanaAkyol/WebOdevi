using System.ComponentModel.DataAnnotations;

namespace WebOdevi.Models
{
    public class Specialization
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public List<TrainerSpecialization> trainerSpecializations { get; set; }
    }
}
