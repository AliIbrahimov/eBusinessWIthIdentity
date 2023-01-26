using eBusiness.Models;
using eBusiness.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eBusiness.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = new AppUser()
            {
                Fullname = registerVM.Fullname,
                UserName = registerVM.Username,
                Email = registerVM.Email
            };
            var result = await _userManager.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerVM);
            }
            var role = await _roleManager.CreateAsync(new IdentityRole { Name = "admin" });
            await _userManager.AddToRoleAsync(user, "admin");
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);
            AppUser user = await _userManager.FindByNameAsync(loginVM.Username);
            if (user is null)
            {
                ModelState.AddModelError("", "Account is not find");
                return View(loginVM);
            }
            if (!(await _userManager.CheckPasswordAsync(user, loginVM.Password)))
            {
                ModelState.AddModelError("", "Password or username is not correct");
                return View(loginVM);
            }
            await _signInManager.PasswordSignInAsync(user, loginVM.Password, true, false);
            return RedirectToAction("index", "home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

    }

}
