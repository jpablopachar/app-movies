using app_movies.Data.Enums;
using app_movies.Data.Static;
using app_movies.Models;
using Microsoft.AspNetCore.Identity;

namespace app_movies.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context?.Database.EnsureCreated();

                if (context != null)
                {
                    if (!context.Cinemas.Any())
                    {
                        context.Cinemas.AddRange(new List<Cinema> {
                            new Cinema() {
                                Name = "Cinema 1",
                                Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                                Description = "Esta es la descripción del primer cinema",
                            },
                            new Cinema() {
                                Name = "Cinema 2",
                                Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                                Description = "Esta es la descripción del segundo cinema",
                            },
                            new Cinema() {
                                Name = "Cinema 3",
                                Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                                Description = "Esta es la descripción del tercer cinema",
                            },
                            new Cinema() {
                                Name = "Cinema 4",
                                Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                                Description = "Esta es la descripción del cuarto cinema",
                            },
                            new Cinema() {
                                Name = "Cinema 5",
                                Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                                Description = "Esta es la descripción del quinto cinema",
                            }
                        });

                        context.SaveChanges();
                    }

                    if (!context.Actors.Any())
                    {
                        context.Actors.AddRange(new List<Actor>() {
                            new Actor()
                            {
                                FullName = "Actor 1",
                                Bio = "esta es biografía del primer actor",
                                ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                            },
                            new Actor()
                            {
                                FullName = "Actor 2",
                                Bio = "esta es biografía del segundo actor",
                                ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"

                            },
                            new Actor()
                            {
                                FullName = "Actor 3",
                                Bio = "esta es biografía del tercer actor",
                                ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"

                            },
                            new Actor()
                            {
                                FullName = "Actor 4",
                                Bio = "esta es biografía del cuarto actor",
                                ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"

                            },
                            new Actor()
                            {
                                FullName = "Actor 5",
                                Bio = "esta es biografía del quinto actor",
                                ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"

                            }
                        });

                        context.SaveChanges();
                    }

                    if (!context.Producers.Any())
                    {
                        context.Producers.AddRange(new List<Producer>() {
                            new Producer()
                            {
                                FullName = "Productor 1",
                                Bio = "Esta es biografía del primer productor",
                                ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                            },
                            new Producer()
                            {
                                FullName = "Productor 2",
                                Bio = "Esta es biografía del segundo productor",
                                ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"

                            },
                            new Producer()
                            {
                                FullName = "Productor 3",
                                Bio = "Esta es biografía del tercer producer",
                                ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"

                            },
                            new Producer()
                            {
                                FullName = "Productor 4",
                                Bio = "Esta es biografía del cuarto producer",
                                ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"

                            },
                            new Producer()
                            {
                                FullName = "Productor 5",
                                Bio = "Esta es biografía del quinto producer",
                                ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"

                            }
                        });

                        context.SaveChanges();
                    }

                    if (!context.Movies.Any())
                    {
                        context.Movies.AddRange(new List<Movie>() {
                            new Movie()
                            {
                                Name = "Life",
                                Description = "This is the Life movie description",
                                Price = 39.50,
                                ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                                StartDate = DateTime.Now.AddDays(-10),
                                EndDate = DateTime.Now.AddDays(10),
                                CinemaId = 3,
                                ProducerId = 3,
                                MovieCategory = MovieCategory.Documentary
                            },
                            new Movie()
                            {
                                Name = "The Shawshank Redemption",
                                Description = "This is the Shawshank Redemption description",
                                Price = 29.50,
                                ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                                StartDate = DateTime.Now,
                                EndDate = DateTime.Now.AddDays(3),
                                CinemaId = 1,
                                ProducerId = 1,
                                MovieCategory = MovieCategory.Action
                            },
                            new Movie()
                            {
                                Name = "Ghost",
                                Description = "This is the Ghost movie description",
                                Price = 39.50,
                                ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                                StartDate = DateTime.Now,
                                EndDate = DateTime.Now.AddDays(7),
                                CinemaId = 4,
                                ProducerId = 4,
                                MovieCategory = MovieCategory.Horror
                            },
                            new Movie()
                            {
                                Name = "Race",
                                Description = "This is the Race movie description",
                                Price = 39.50,
                                ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                                StartDate = DateTime.Now.AddDays(-10),
                                EndDate = DateTime.Now.AddDays(-5),
                                CinemaId = 1,
                                ProducerId = 2,
                                MovieCategory = MovieCategory.Documentary
                            },
                            new Movie()
                            {
                                Name = "Scoob",
                                Description = "This is the Scoob movie description",
                                Price = 39.50,
                                ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                                StartDate = DateTime.Now.AddDays(-10),
                                EndDate = DateTime.Now.AddDays(-2),
                                CinemaId = 1,
                                ProducerId = 3,
                                MovieCategory = MovieCategory.Cartoon
                            },
                            new Movie()
                            {
                                Name = "Cold Soles",
                                Description = "This is the Cold Soles movie description",
                                Price = 39.50,
                                ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                                StartDate = DateTime.Now.AddDays(3),
                                EndDate = DateTime.Now.AddDays(20),
                                CinemaId = 1,
                                ProducerId = 5,
                                MovieCategory = MovieCategory.Drama
                            }
                        });

                        context.SaveChanges();
                    }

                    if (!context.ActorsMovies.Any())
                    {
                        context.ActorsMovies.AddRange(new List<ActorMovie>()
                        {
                            new ActorMovie()
                            {
                                ActorId = 1,
                                MovieId = 1
                            },
                            new ActorMovie()
                            {
                                ActorId = 3,
                                MovieId = 1
                            },
                            new ActorMovie()
                            {
                                ActorId = 1,
                                MovieId = 2
                            },
                            new ActorMovie()
                            {
                                ActorId = 4,
                                MovieId = 2
                            },
                            new ActorMovie()
                            {
                                ActorId = 1,
                                MovieId = 3
                            },
                            new ActorMovie()
                            {
                                ActorId = 2,
                                MovieId = 3
                            },
                            new ActorMovie()
                            {
                                ActorId = 5,
                                MovieId = 3
                            },
                            new ActorMovie()
                            {
                                ActorId = 2,
                                MovieId = 4
                            },
                            new ActorMovie()
                            {
                                ActorId = 3,
                                MovieId = 4
                            },
                            new ActorMovie()
                            {
                                ActorId = 4,
                                MovieId = 4
                            },
                            new ActorMovie()
                            {
                                ActorId = 2,
                                MovieId = 5
                            },
                            new ActorMovie()
                            {
                                ActorId = 3,
                                MovieId = 5
                            },
                            new ActorMovie()
                            {
                                ActorId = 4,
                                MovieId = 5
                            },
                            new ActorMovie()
                            {
                                ActorId = 5,
                                MovieId = 5
                            },
                            new ActorMovie()
                            {
                                ActorId = 3,
                                MovieId = 6
                            },
                            new ActorMovie()
                            {
                                ActorId = 4,
                                MovieId = 6
                            },
                            new ActorMovie()
                            {
                                ActorId = 5,
                                MovieId = 6
                            }
                        });

                        context.SaveChanges();
                    }
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);

                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        UserName = "admin-user",
                        FullName = "Admin User"
                    };

                    await userManager.CreateAsync(newAdminUser, "Pass4Admin");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@email.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);

                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        UserName = "app-user",
                        FullName = "App User"
                    };

                    await userManager.CreateAsync(newAppUser, "Pass4Admin");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}