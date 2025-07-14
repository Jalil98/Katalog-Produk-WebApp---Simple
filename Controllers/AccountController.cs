using Microsoft.AspNetCore.Mvc;
using KatalogProduk.Models;
using KatalogProduk.Extensions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace KatalogProduk.Controllers
{
    public class AccountController : Controller
    {
        public static List<User> Users = new List<User>();

        public IActionResult Login() => View();
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = Users.Find(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetObject("User", user);
                return RedirectToAction("Index", "Profile");
            }
            ViewBag.Message = "Login gagal";
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            var newUser = new User { Id = Users.Count + 1, Username = username, Password = password };
            Users.Add(newUser);
            return RedirectToAction("Login");
        }
    }
}
