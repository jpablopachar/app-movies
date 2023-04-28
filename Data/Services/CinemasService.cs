using app_movies.Data.Base;
using app_movies.Models;

namespace app_movies.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext appDbContext) : base(appDbContext) { }
    }
}