using System.ComponentModel.DataAnnotations;

namespace WebOdevi.Models
{
    public class FitnessCenter
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Service> Services { get; set; }
        public List<Trainer> Trainers { get; set; }
    }
}
