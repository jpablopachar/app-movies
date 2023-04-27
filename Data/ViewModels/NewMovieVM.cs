using System.ComponentModel.DataAnnotations;
using app_movies.Data.Enums;

namespace app_movies.Data.ViewModels
{
    public class NewMovieVM
    {
        public int Id { get; set; }
        [Display(Name = "Nombre de la película")]
        [Required(ErrorMessage = "El nombre de la película es requerido")]
        public string? Name { get; set; }
        [Display(Name = "Descripción de la película")]
        [Required(ErrorMessage = "La descripción de la película es requerido")]
        public string? Description { get; set; }
        [Display(Name = "Precio en $")]
        [Required(ErrorMessage = "El precio de la película es requerido")]
        public double Price { get; set; }
        [Display(Name = "URL del poster")]
        [Required(ErrorMessage = "La URL del poster es requerido")]
        public string? ImageURL { get; set; }
        [Display(Name = "Fecha de inicio de la película")]
        [Required(ErrorMessage = "La fecha de inicio de la película es requerido")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Fecha de finalización de la película")]
        [Required(ErrorMessage = "La fecha de finalización de la película es requerido")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Seleccione una categoría")]
        [Required(ErrorMessage = "La categoría de la película es requerido")]
        public MovieCategory MovieCategory { get; set; }
        [Display(Name = "Seleccione los actores")]
        [Required(ErrorMessage = "Los actores de la película son requeridos")]
        public List<int>? ActorIds { get; set; }
        [Display(Name = "Seleccione un cine")]
        [Required(ErrorMessage = "El cine es requerido")]
        public int CinemaId { get; set; }
        [Display(Name = "Seleccione el productor")]
        [Required(ErrorMessage = "El productor de la película es requerido")]
        public int ProducerId { get; set; }
    }
}