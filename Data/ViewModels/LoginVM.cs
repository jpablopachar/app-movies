using System.ComponentModel.DataAnnotations;

namespace app_movies.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Correo electrónico es requerido")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}