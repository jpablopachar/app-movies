using System.ComponentModel.DataAnnotations;

namespace app_movies.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El Nombre es requerido")]
        public string? FullName { get; set; }
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "El Correo electrónico es requerido")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Confirmar contraseña")]
        [Required(ErrorMessage = "La contraseña de confirmación es requerido")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden")]
        public string? ConfirmPassword { get; set; }
    }
}