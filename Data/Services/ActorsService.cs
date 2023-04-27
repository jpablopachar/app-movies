using app_movies.Data.Base;
using app_movies.Models;

namespace app_movies.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext appDbContext) : base(appDbContext) { }
    }
}