using app_movies.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace app_movies.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Foto de perfil")]
        [Required(ErrorMessage = "La foto de perfil es requerido")]
        public string? ProfilePictureURL { get; set; }
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe contener entre 3 y 50 caracteres")]
        public string? FullName { get; set; }
        [Display(Name = "Biografía")]
        [Required(ErrorMessage = "La biografía es requerida")]
        public string? Bio { get; set; }
        public List<ActorMovie>? ActorsMovies { get; set; }
    }
}