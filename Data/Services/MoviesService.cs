using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app_movies.Data.Base;
using app_movies.Data.ViewModels;
using app_movies.Models;
using Microsoft.EntityFrameworkCore;

namespace app_movies.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _appDbContext;

        public MoviesService(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddNewMovieAsync(NewMovieVM newMovieVM)
        {
            var newMovie = new Movie()
            {
                Name = newMovieVM.Name,
                Description = newMovieVM.Description,
                Price = newMovieVM.Price,
                ImageURL = newMovieVM.ImageURL,
                CinemaId = newMovieVM.CinemaId,
                StartDate = newMovieVM.StartDate,
                EndDate = newMovieVM.EndDate,
                MovieCategory = newMovieVM.MovieCategory,
                ProducerId = newMovieVM.ProducerId
            };

            await _appDbContext.Movies.AddAsync(newMovie);
            await _appDbContext.SaveChangesAsync();

            foreach (var actorId in newMovieVM.ActorIds)
            {
                var movieActor = new ActorMovie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };

                await _appDbContext.ActorsMovies.AddAsync(movieActor);
            }

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _appDbContext.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.ActorsMovies)
                .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var res = new NewMovieDropdownsVM()
            {
                Actors = await _appDbContext.Actors.OrderBy(actor => actor.FullName).ToListAsync(),
                Cinemas = await _appDbContext.Cinemas.OrderBy(cinema => cinema.Name).ToListAsync(),
                Producers = await _appDbContext.Producers.OrderBy(producer => producer.FullName).ToListAsync()
            };

            return res;
        }

        public async Task UpdateMovieAsync(NewMovieVM newMovieVM)
        {
            var dbMovie = await _appDbContext.Movies.FirstOrDefaultAsync(movie => movie.Id == newMovieVM.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = newMovieVM.Name;
                dbMovie.Description = newMovieVM.Description;
                dbMovie.Price = newMovieVM.Price;
                dbMovie.ImageURL = newMovieVM.ImageURL;
                dbMovie.CinemaId = newMovieVM.CinemaId;
                dbMovie.StartDate = newMovieVM.StartDate;
                dbMovie.EndDate = newMovieVM.EndDate;
                dbMovie.MovieCategory = newMovieVM.MovieCategory;
                dbMovie.ProducerId = newMovieVM.ProducerId;

                await _appDbContext.SaveChangesAsync();
            }

            var existingActorDb = _appDbContext.ActorsMovies.Where(am => am.MovieId == newMovieVM.Id).ToList();

            _appDbContext.ActorsMovies.RemoveRange(existingActorDb);

            await _appDbContext.SaveChangesAsync();

            foreach (var actorId in newMovieVM.ActorIds)
            {
                var newMovieActor = new ActorMovie()
                {
                    MovieId = newMovieVM.Id,
                    ActorId = actorId
                };

                await _appDbContext.ActorsMovies.AddAsync(newMovieActor);
            }

            await _appDbContext.SaveChangesAsync();
        }
    }
}