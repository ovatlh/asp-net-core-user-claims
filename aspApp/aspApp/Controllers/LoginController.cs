using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using aspApp.Models;
using aspApp.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace aspApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username_value, string password_value)
        {
            if (string.IsNullOrWhiteSpace(username_value) || string.IsNullOrWhiteSpace(password_value))
            {
                if (string.IsNullOrWhiteSpace(username_value))
                {
                    ModelState.AddModelError("Error", "You must enter your username.");
                }

                if (string.IsNullOrWhiteSpace(password_value))
                {
                    ModelState.AddModelError("Error", "You must enter your password.");
                }

                ViewBag.Username = username_value;
                ViewBag.Password = password_value;
                ViewBag.Errores = true;
                //return RedirectToAction("Index", "Login");
                return View("Index");
            }

            User_Repository user_Repository = new User_Repository();
            User result_user = user_Repository.GetUserBy_Username(username_value);

            if (result_user == null)
            {
                ViewBag.Username = username_value;
                ViewBag.Password = password_value;
                ViewBag.Errores = true;
                ModelState.AddModelError("Error", "User not found.");
                //return RedirectToAction("Index", "Login");
                return View("Index");
            }

            if (result_user.Password != password_value)
            {
                ViewBag.Username = username_value;
                ViewBag.Password = password_value;
                ViewBag.Errores = true;
                ModelState.AddModelError("Error", "Incorrect password.");
                //return RedirectToAction("Index", "Login");
                return View("Index");
            }

            if (result_user != null && result_user.Username == username_value && result_user.Password == password_value)
            {
                RolClaims_Repository rolClaims_Repository = new RolClaims_Repository();
                Rol_Repository rol_Repository = new Rol_Repository();

                IEnumerable<Rolclaims> result_rolclaimsList = rolClaims_Repository.GetRolclaimsBy_IdRol_With_Navigation(result_user.IdRol);
                Rol result_rol = rol_Repository.GetRolBy_Id_With_Navigation(result_user.IdRol);

                List<Claim> list_claims = new List<Claim>();
                foreach (var item in result_rolclaimsList)
                {
                    Claim new_claim = new Claim(item.IdClaimsNavigation.DisplayName, item.IdClaimsNavigation.DisplayName);
                    list_claims.Add(new_claim);
                }

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(list_claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                //return RedirectToAction("Index", "Home");
                return Redirect(result_rol.IdStartPageNavigation.Url);
            }

            ViewBag.Username = username_value;
            ViewBag.Password = password_value;
            ViewBag.Errores = true;
            ModelState.AddModelError("Error", "Incorrect data.");
            //return RedirectToAction("Index", "Login");
            return View("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}