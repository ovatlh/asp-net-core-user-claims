using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspApp.Models;
using aspApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspApp.Controllers
{
    public class ClaimsController : Controller
    {
        public IActionResult Index()
        {
            Claims_Repository claims_Repository = new Claims_Repository();
            return View(claims_Repository.GetAll());
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Claims_Repository claims_Repository = new Claims_Repository();
            return View(claims_Repository.GetById(id));
        }

        public IActionResult Delete(int id)
        {
            Claims_Repository claims_Repository = new Claims_Repository();
            return View(claims_Repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(Claims claims)
        {
            Claims_Repository claims_Repository = new Claims_Repository();
            claims_Repository.Insert(claims);
            //return View();
            return RedirectToAction("Index", "Claims");
        }

        [HttpPost]
        public IActionResult Edit(Claims claims)
        {
            Claims_Repository claims_Repository = new Claims_Repository();
            claims_Repository.Update(claims);
            //return View();
            return RedirectToAction("Index", "Claims");
        }

        [HttpPost]
        public IActionResult Delete(Claims claims)
        {
            Claims_Repository claims_Repository = new Claims_Repository();
            claims_Repository.Delete(claims);
            //return View();
            return RedirectToAction("Index", "Claims");
        }
    }
}
