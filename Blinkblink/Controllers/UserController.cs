using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blinkblink.Models;
using Blinkblink.Services;
using Blinkblink.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;


namespace Blinkblink.Controllers
{
    public class UserController : Controller
    {
        private readonly UserHepler _userHelper;
        private  DBBlinkContext _dBBlinkContext;
        public UserController(DBBlinkContext dBBlinkContext)
        {
            _dBBlinkContext = dBBlinkContext;
            _userHelper = new UserHepler(_dBBlinkContext);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Blog()
        {
            ClaimsPrincipal principal = HttpContext.User;
            string idUser = principal.Claims.ElementAt(1).Value;           
            return View(_dBBlinkContext.Images.Where(e => e.UserId.Equals(idUser)).OrderByDescending(o => o.DateTime));
          
        }
        [HttpPost]
        public async Task<IActionResult> LoginProcess(UserLoginViewModel model)
        {
            if (!_userHelper.IsAuthenticated(model.Username, model.Password))
                return RedirectToAction("Login");

            // create claims
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Cookie Login Blinks"),
                new Claim(ClaimTypes.Email, model.Username)
            };

            // create identity
            ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");

            // create principal
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            // sign-in
            await HttpContext.SignInAsync(
                    scheme: CookieAuthenticationDefaults.AuthenticationScheme,
                    principal: principal,
                    properties: new AuthenticationProperties
                    {
                        //IsPersistent = true, // for 'remember me' feature
                        //ExpiresUtc = DateTime.UtcNow.AddMinutes(1)
                    });

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout(string requestPath)
        {
            await HttpContext.SignOutAsync(
                    scheme: CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}