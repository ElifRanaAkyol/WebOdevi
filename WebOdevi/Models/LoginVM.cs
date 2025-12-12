using System.ComponentModel.DataAnnotations;

namespace WebOdevi.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [EmailAddress(ErrorMessage = "Geçerli mail adresi giriniz!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
