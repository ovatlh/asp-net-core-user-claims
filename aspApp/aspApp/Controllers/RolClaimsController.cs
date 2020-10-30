using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspApp.Controllers
{
    public class RolClaimsController : Controller
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
        public IActionResult Add(Rolclaims rolclaims)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Rolclaims rolclaims)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Rolclaims rolclaims)
        {
            return View();
        }
    }
}
