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

        public IActionResult Delete(int id)
        {
            Rol_Repository rol_Repository = new Rol_Repository();
            return View(rol_Repository.GetById(id));
        }

        public IActionResult ManageRolClaims(int id)
        {
            Rol_RolClaims_Repository rol_RolClaims_Repository = new Rol_RolClaims_Repository();
            return View(rol_RolClaims_Repository.GetRolClaims_VM(id));
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

        [HttpPost]
        public IActionResult Delete(Rol rol)
        {
            Rol_Repository rol_Repository = new Rol_Repository();
            rol_Repository.DeleteAllRolClaimsBy_IdRol(rol.Id);
            //rol_Repository.Context.SaveChanges();
            rol_Repository.Delete(rol);
            //rol_Repository.Context.Remove(rol);
            //return View();
            return RedirectToAction("Index", "Rol");
        }

        [HttpPost]
        public IActionResult AddRolClaims(int idrol_value, int idclaims_value)
        {
            //Rol_RolClaims_Repository rol_RolClaims_Repository = new Rol_RolClaims_Repository();
            //return View(rol_RolClaims_Repository.GetRolClaims_VM(id));
            Rol_RolClaims_Repository rol_RolClaims_Repository = new Rol_RolClaims_Repository();
            rol_RolClaims_Repository.AddRolClaims(idrol_value, idclaims_value);

            Rol_RolClaims_VM result_rol_RolClaims_VM = rol_RolClaims_Repository.GetRolClaims_VM(idrol_value);
            return View("ManageRolClaims", result_rol_RolClaims_VM);
        }

        [HttpPost]
        public IActionResult DeleteRolClaims(int idrolclaims_value)
        {
            RolClaims_Repository rolClaims_Repository = new RolClaims_Repository();
            Rolclaims result_rolclaims = rolClaims_Repository.GetById(idrolclaims_value);

            Rol_RolClaims_Repository rol_RolClaims_Repository = new Rol_RolClaims_Repository();
            rol_RolClaims_Repository.DeleteRolClaims(idrolclaims_value);

            Rol_RolClaims_VM result_rol_RolClaims_VM = rol_RolClaims_Repository.GetRolClaims_VM(result_rolclaims.IdRol);
            return View("ManageRolClaims", result_rol_RolClaims_VM);

        }
    }
}
