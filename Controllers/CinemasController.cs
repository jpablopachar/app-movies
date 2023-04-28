using app_movies.Data.Services;
using app_movies.Data.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace app_movies.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CinemasController : Controller
    {
        private readonly ICinemasService _cinemasService;

        public CinemasController(ICinemasService cinemasService)
        {
            _cinemasService = cinemasService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var cinemas = await _cinemasService.GetAllAsync();

            return View(cinemas);
        }
    }
}