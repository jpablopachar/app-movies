using app_movies.Data.Base;
using app_movies.Data.ViewModels;
using app_movies.Models;

namespace app_movies.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM newMovieVM);
        Task UpdateMovieAsync(NewMovieVM newMovieVM);
    }
}