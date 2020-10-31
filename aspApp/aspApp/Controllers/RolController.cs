using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspApp.Models;
using aspApp.Repositories;
using aspApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspApp.Controllers
{
    public class RolController : Controller
    {
        public IActionResult Index()
        {
            Rol_Repository rol_Repository = new Rol_Repository();
            return View(rol_Repository.GetAll());
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Rol_Repository rol_Repository = new Rol_Repository();
            return View(rol_Repository.GetById(id));
        }

        //public IActionResult EditRolClaims(int id)
        //{
        //    Rol_RolClaims_Repository rol_RolClaims_Repository = new Rol_RolClaims_Repository();
        //    return View(rol_RolClaims_Repository.GetRolClaims_VM(id));
        //}

        public IActionResult Delete(int id)
        {
            Rol_Repository rol_Repository = new Rol_Repository();
            return View(rol_Repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(Rol rol)
        {
            Rol_Repository rol_Repository = new Rol_Repository();
            rol_Repository.Insert(rol);
            //return View();
            return RedirectToAction("Index", "Rol");
        }

        [HttpPost]
        public IActionResult Edit(Rol rol)
        {
            Rol_Repository rol_Repository = new Rol_Repository();
            rol_Repository.Update(rol);
            //return View();
            return RedirectToAction("Index", "Rol");
        }

        //[HttpPost]
        //public IActionResult EditRolClaims(Rol_RolClaims_VM rol_RolClaims_VM)
        //{
        //    Rol_RolClaims_Repository rol_RolClaims_Repository = new Rol_RolClaims_Repository();
        //    return View(rol_RolClaims_Repository.GetRolClaims_VM(id));
        //}

        [HttpPost]
        public IActionResult Delete(Rol rol)
        {
            Rol_Repository rol_Repository = new Rol_Repository();
            rol_Repository.Delete(rol);
            //return View();
            return RedirectToAction("Index", "Rol");
        }
    }
}
