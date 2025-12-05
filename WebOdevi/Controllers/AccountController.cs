using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using WebOdevi.Models;
using WebOdevi.Models.ViewModels;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            ModelState.AddModelError("", "Kullanıcı bulunamadı.");
            return View(model);
        }

        // SignIn
        var result = await _signInManager.PasswordSignInAsync(
            user,
            model.Password,
            model.RememberMe,
            false);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Email veya şifre hatalı.");
            return View(model);
        }

        if (await _userManager.IsInRoleAsync(user, "Admin"))
            return RedirectToAction("Index", "Trainer");

        return RedirectToAction("Index", "Home");
    }


    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = new User
        {
            FullName = model.FullName,
            Email = model.Email,
            UserName = model.Email
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        await _userManager.AddToRoleAsync(user, "AppUser");

        await _signInManager.SignInAsync(user, false);

        return RedirectToAction("Index", "Home");
    }

}
