using app_movies.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace app_movies.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>().HasKey(actorMovie => new { actorMovie.ActorId, actorMovie.MovieId });
            modelBuilder.Entity<ActorMovie>().HasOne(movie => movie.Movie).WithMany(actorMovie => actorMovie.ActorsMovies).HasForeignKey(movie => movie.MovieId);
            modelBuilder.Entity<ActorMovie>().HasOne(movie => movie.Actor).WithMany(actorMovie => actorMovie.ActorsMovies).HasForeignKey(movie => movie.ActorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorMovie> ActorsMovies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}