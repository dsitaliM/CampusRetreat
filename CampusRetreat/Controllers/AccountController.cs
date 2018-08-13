using System.Threading.Tasks;
using CampusRetreat.Models;
using CampusRetreat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace CampusRetreat.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<Administrator> _userManager;
        private readonly SignInManager<Administrator> _signInManager;

        public AccountController(UserManager<Administrator> userManager, SignInManager<Administrator> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            IdentitySeedData.Seed(userManager).Wait();
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                Administrator admin = await _userManager.FindByEmailAsync(model.LoginToken);

                if (admin != null)
                {
                    await _signInManager.SignOutAsync();
                    SignInResult result = await _signInManager.PasswordSignInAsync(admin, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(GuestController.Index), "Guest");
                    }
                }

                ModelState.AddModelError(nameof(LoginViewModel.LoginToken), "Invalid Username or Password");
            }

            return View(model);
        }

    }
}
