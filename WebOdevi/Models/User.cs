using Microsoft.AspNetCore.Identity;

namespace WebOdevi.Models
{
    public class User :IdentityUser
    {

        //Domain modellerinde (trainer, service, appointment cd ) int ile tanımlıyorum daha iyi performans için
        public string fullName { get; set; }
        public List<Appointment> appointments { get; set; }
        
    }
}
