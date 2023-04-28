using app_movies.Data.Services;
using app_movies.Data.Static;
using app_movies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace app_movies.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorsService _actorsService;

        public ActorsController(IActorsService actorsService)
        {
            _actorsService = actorsService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var actors = await _actorsService.GetAllAsync();

            return View(actors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")] Actor actor)
        {
            if (!ModelState.IsValid) return View(actor);

            await _actorsService.AddAsync(actor);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var actor = await _actorsService.GetByIdAsync(id);

            if (actor == null) return View("NotFound");

            return View(actor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _actorsService.GetByIdAsync(id);

            if (actor == null) return View("NotFound");

            return View(actor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureURL, Bio")] Actor actor)
        {
            if (!ModelState.IsValid) return View(actor);

            await _actorsService.UpdateAsync(id, actor);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _actorsService.GetByIdAsync(id);

            if (actor == null) return View("NotFound");

            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await _actorsService.GetByIdAsync(id);

            if (actor == null) return View("NotFound");

            await _actorsService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}