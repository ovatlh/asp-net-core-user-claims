using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspApp.Models;
using aspApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspApp.Controllers
{
    public class RolClaimsController : Controller
    {
        public IActionResult Index()
        {
            RolClaims_Repository rolClaims_Repository = new RolClaims_Repository();
            return View(rolClaims_Repository.GetRolclaims_With_Navigation().OrderBy(x => x.IdRolNavigation.Id));
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            RolClaims_Repository rolClaims_Repository = new RolClaims_Repository();
            return View(rolClaims_Repository.GetById(id));
        }

        public IActionResult Delete(int id)
        {
            RolClaims_Repository rolClaims_Repository = new RolClaims_Repository();
            return View(rolClaims_Repository.GetRolclaimBy_Id_With_Navigation(id));
        }

        [HttpPost]
        public IActionResult Add(Rolclaims rolclaims)
        {
            RolClaims_Repository rolClaims_Repository = new RolClaims_Repository();
            rolClaims_Repository.Insert(rolclaims);
            //return View();
            return RedirectToAction("Index", "RolClaims");
        }

        [HttpPost]
        public IActionResult Edit(Rolclaims rolclaims)
        {
            RolClaims_Repository rolClaims_Repository = new RolClaims_Repository();
            rolClaims_Repository.Update(rolclaims);
            //return View();
            return RedirectToAction("Index", "RolClaims");
        }

        [HttpPost]
        public IActionResult Delete(Rolclaims rolclaims)
        {
            RolClaims_Repository rolClaims_Repository = new RolClaims_Repository();
            rolClaims_Repository.Delete(rolclaims);
            //return View();
            return RedirectToAction("Index", "RolClaims");
        }
    }
}
