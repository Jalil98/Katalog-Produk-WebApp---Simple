using KatalogProduk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using KatalogProduk.Extensions;
using System;

namespace KatalogProduk.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            var user = HttpContext.Session.GetObject<User>("User");
            if (user == null) return RedirectToAction("Login", "Account");
            return View(user);
        }

        [HttpPost]
        public IActionResult AddTodo(string task)
        {
            var user = HttpContext.Session.GetObject<User>("User");
            if (user != null)
            {
                user.Todos.Add(new TodoItem { Task = task, IsCompleted = false });
                HttpContext.Session.SetObject("User", user);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddNote(string content)
        {
            var user = HttpContext.Session.GetObject<User>("User");
            if (user != null)
            {
                user.Notes.Add(new Note { Content = content, CreatedAt = DateTime.Now });
                HttpContext.Session.SetObject("User", user);
            }
            return RedirectToAction("Index");
        }
    }
}
