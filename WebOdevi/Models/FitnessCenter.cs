using System.ComponentModel.DataAnnotations;

namespace WebOdevi.Models
{
    public class FitnessCenter
    {

        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public List<Service> services { get; set; }
        public List<Trainer> trainers { get; set; }
    }
}
