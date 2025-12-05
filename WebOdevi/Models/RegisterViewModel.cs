using System.ComponentModel.DataAnnotations;

namespace WebOdevi.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Bu alan boş bırakılamaz!")]
        [EmailAddress(ErrorMessage = "Geçerli mail adresi giriniz!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [MaxLength(50,ErrorMessage ="En fazla 50 karakter girilebilir!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [MaxLength(15, ErrorMessage = "En fazla 15 karakter girilebilir!")]

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Compare("Password", ErrorMessage ="Şifreler eşleşmiyor!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
