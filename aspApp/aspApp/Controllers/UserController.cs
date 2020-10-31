using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspApp.Models;
using aspApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            User_Repository user_Repository = new User_Repository();
            return View(user_Repository.GetUsers_With_Navigation());
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            User_Repository user_Repository = new User_Repository();
            return View(user_Repository.GetById(id));
        }

        public IActionResult Delete(int id)
        {
            User_Repository user_Repository = new User_Repository();
            return View(user_Repository.GetUserBy_Id_With_Navigation(id));
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            User_Repository user_Repository = new User_Repository();
            user_Repository.Insert(user);
            //return View();
            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            User_Repository user_Repository = new User_Repository();
            user_Repository.Update(user);
            //return View();
            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public IActionResult Delete(User user)
        {
            User_Repository user_Repository = new User_Repository();
            user_Repository.Delete(user);
            //return View();
            return RedirectToAction("Index", "User");
        }
    }
}