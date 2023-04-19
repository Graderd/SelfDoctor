using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Selfdoctor.Application.Dtos.User;
using Selfdoctor.Application.Interfaces.Services;
using SelfDoctor.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace SelfDoctor.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            
           _authService = authService;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            var user = HttpContext.Request.Cookies.Where(c => c.Key.Equals("AuthCookie")).FirstOrDefault();
            if(user.Value == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserInsertDto user)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterUserAsync(user);
                if (result) return RedirectToAction("Index");
            }
            ViewBag.RegisterActive = "right-panel-active";
            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var result = await _authService.LoginAsync(userName, password);
            if (result != null)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, result.UserName!));

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.LoginActive = "right-panel-active";
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            foreach (var cookie in Request.Cookies.Keys) Response.Cookies.Delete(cookie);


            return RedirectToAction("Register", "Auth");

        }
    }
}