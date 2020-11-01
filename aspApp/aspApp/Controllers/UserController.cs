using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspApp.Models;
using aspApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspApp.Controllers
{
    public class UserController : Controller
    {
        [Authorize(Policy = "UserListPolicy")]
        public IActionResult Index()
        {
            User_Repository user_Repository = new User_Repository();
            return View(user_Repository.GetUsers_With_Navigation());
        }

        [Authorize(Policy = "UserAddPolicy")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Policy = "UserEditPolicy")]
        public IActionResult Edit(int id)
        {
            User_Repository user_Repository = new User_Repository();
            return View(user_Repository.GetById(id));
        }

        [Authorize(Policy = "UserDeletePolicy")]
        public IActionResult Delete(int id)
        {
            User_Repository user_Repository = new User_Repository();
            return View(user_Repository.GetUserBy_Id_With_Navigation(id));
        }


        [Authorize(Policy = "UserAddPolicy")]
        [HttpPost]
        public IActionResult Add(User user)
        {
            User_Repository user_Repository = new User_Repository();
            user_Repository.Insert(user);
            //return View();
            return RedirectToAction("Index", "User");
        }

        [Authorize(Policy = "UserEditPolicy")]
        [HttpPost]
        public IActionResult Edit(User user)
        {
            User_Repository user_Repository = new User_Repository();
            user_Repository.Update(user);
            //return View();
            return RedirectToAction("Index", "User");
        }

        [Authorize(Policy = "UserDeletePolicy")]
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