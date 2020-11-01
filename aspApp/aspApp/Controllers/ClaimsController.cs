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
    public class ClaimsController : Controller
    {
        [Authorize(Policy = "ClaimsListPolicy")]
        public IActionResult Index()
        {
            Claims_Repository claims_Repository = new Claims_Repository();
            return View(claims_Repository.GetAll());
        }

        [Authorize(Policy = "ClaimsAddPolicy")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Policy = "ClaimsEditPolicy")]
        public IActionResult Edit(int id)
        {
            Claims_Repository claims_Repository = new Claims_Repository();
            return View(claims_Repository.GetById(id));
        }

        [Authorize(Policy = "ClaimsDeletePolicy")]
        public IActionResult Delete(int id)
        {
            Claims_Repository claims_Repository = new Claims_Repository();
            return View(claims_Repository.GetById(id));
        }

        [Authorize(Policy = "ClaimsAddPolicy")]
        [HttpPost]
        public IActionResult Add(Claims claims)
        {
            Claims_Repository claims_Repository = new Claims_Repository();
            claims_Repository.Insert(claims);
            //return View();
            return RedirectToAction("Index", "Claims");
        }

        [Authorize(Policy = "ClaimsEditPolicy")]
        [HttpPost]
        public IActionResult Edit(Claims claims)
        {
            Claims_Repository claims_Repository = new Claims_Repository();
            claims_Repository.Update(claims);
            //return View();
            return RedirectToAction("Index", "Claims");
        }

        [Authorize(Policy = "ClaimsDeletePolicy")]
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
