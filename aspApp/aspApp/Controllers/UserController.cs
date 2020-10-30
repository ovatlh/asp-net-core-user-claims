using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(User user)
        {
            return View();
        }
    }
}
