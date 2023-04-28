using System.ComponentModel.DataAnnotations;
using app_movies.Data.Base;

namespace app_movies.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Logo")]
        [Required(ErrorMessage = "El logo es requerido")]
        public string? Logo { get; set; }
        [Display(Name = "Nombre Cinema")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string? Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "La descripción es requerida")]
        public string? Description { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}