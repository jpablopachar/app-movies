using app_movies.Data;
using app_movies.Data.ViewModels;
using app_movies.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app_movies.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _appDbContext;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Users()
        {
            var Users = await _appDbContext.Users.ToListAsync();

            return View(Users);
        }

        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.Email);

            if (user != null)
            {
                var passwordCheck = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                if (passwordCheck != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                    if (result.Succeeded) return RedirectToAction("Index", "Movies");
                }

                TempData["Error"] = "Usuario o contraseña incorrectos";

                return View(loginVM);
            }

            TempData["Error"] = "Usuario o contraseña incorrectos";

            return View(loginVM);
        }

        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.Email);

            if (user != null)
            {
                TempData["Error"] = "El correo electrónico ya está registrado";

                return View(registerVM);
            }

            var newUser = new AppUser
            {
                FullName = registerVM.FullName,
                Email = registerVM.Email,
                UserName = registerVM.Email
            };

            var result = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (result.Succeeded) await _userManager.CreateAsync(newUser, registerVM.Password);

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Movies");
        }

        public IActionResult AccessDenied(string returnUrl) => View();
    }
}