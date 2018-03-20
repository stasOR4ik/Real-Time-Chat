using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chat.Models;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace Chat.Controllers
{
    public class HomeController : Controller
    {
        UserContext db;
        public HomeController(UserContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(string login, string password, string repeatPassword)
        {
            if (login == null || (login).Length > 20 )
            {
                ViewData["ErrorMessage"] = "Login must contain 1-20 character(s)";
                return View("Registration");
            }
            User user = new User
            {
                Name = login,
                Password = password
            };
            User findUser = db.Users.FirstOrDefault(p => p.Name == login);
            ViewData["Message"] = login;
            if (findUser != null)
            {
                ViewData["ErrorMessage"] = "User with such login already exists";
                return View("Registration");
            }
            else
            {
                if (password == repeatPassword && password != null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    ViewData["SuccessfulRegistration"] = "Регистрация успешно пройдена";
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewData["ErrorMessage"] = "The password must contain at least 1 simbol and coincide with its repetition";
                    return View("Registration");
                }
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            User findUser = db.Users.FirstOrDefault(p => p.Name == login);
            ViewData["Message"] = login;
            if (findUser != null)
            {
                if (findUser.Password == password)
                {
                    return View("Index");
                }
                else
                {
                    ViewData["ErrorMessage"] = "Incorrect password";
                    return View("Login");
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "Non-existent login";
                return View("Login");
            }
        }
    }
}
