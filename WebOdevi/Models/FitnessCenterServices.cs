using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOdevi.Models
{
    public class FitnessCenterServices
    {
        [Key]
        public int Id { get; set; }
        public int fitnessCenterId { get; set; }
        [ForeignKey("fitnessCenterId")]
        public FitnessCenter fitnessCenter { get; set; }
        public int serviceId { get; set; }
        [ForeignKey("serviceId")]
        public Service Service { get; set; }
    }
}
