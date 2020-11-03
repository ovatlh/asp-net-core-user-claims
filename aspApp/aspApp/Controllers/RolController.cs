using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspApp.Models;
using aspApp.Repositories;
using aspApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspApp.Controllers
{
    public class RolController : Controller
    {
        [Authorize(Policy = "RolListPolicy")]
        public IActionResult Index()
        {
            Rol_Repository rol_Repository = new Rol_Repository();
            //return View(rol_Repository.GetAll());
            return View(rol_Repository.GetRolsWith_Navigation());
        }

        [Authorize(Policy = "RolAddPolicy")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Policy = "RolEditPolicy")]
        public IActionResult Edit(int id)
        {
            Rol_Repository rol_Repository = new Rol_Repository();
            return View(rol_Repository.GetById(id));
            //return View(rol_Repository.GetRolBy_Id_With_Navigation(id));
        }

        [Authorize(Policy = "RolDeletePolicy")]
        public IActionResult Delete(int id)
        {
            Rol_Repository rol_Repository = new Rol_Repository();
            //return View(rol_Repository.GetById(id));
            return View(rol_Repository.GetRolBy_Id_With_Navigation(id));
        }

        [Authorize(Policy = "RolManageRolClaimsPolicy")]
        public IActionResult ManageRolClaims(int id)
        {
            Rol_RolClaims_Repository rol_RolClaims_Repository = new Rol_RolClaims_Repository();
            ViewBag.IdRol = id;
            return View(rol_RolClaims_Repository.GetRolClaims_VM(id));
        }

        [Authorize(Policy = "RolAddPolicy")]
        [HttpPost]
        public IActionResult Add(Rol rol)
        {
            Rol_Repository rol_Repository = new Rol_Repository();
            rol_Repository.Insert(rol);
            //return View();
            return RedirectToAction("Index", "Rol");
        }

        [Authorize(Policy = "RolEditPolicy")]
        [HttpPost]
        public IActionResult Edit(Rol rol)
        {
            Rol_Repository rol_Repository = new Rol_Repository();
            rol_Repository.Update(rol);
            //return View();
            return RedirectToAction("Index", "Rol");
        }

        [Authorize(Policy = "RolDeletePolicy")]
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

        [Authorize(Policy = "RolAddRolClaimsPolicy")]
        [HttpPost]
        public IActionResult AddRolClaims(int idrol_value, int idclaims_value)
        {
            //Rol_RolClaims_Repository rol_RolClaims_Repository = new Rol_RolClaims_Repository();
            //return View(rol_RolClaims_Repository.GetRolClaims_VM(id));
            Rol_RolClaims_Repository rol_RolClaims_Repository = new Rol_RolClaims_Repository();
            rol_RolClaims_Repository.AddRolClaims(idrol_value, idclaims_value);

            Rol_RolClaims_VM result_rol_RolClaims_VM = rol_RolClaims_Repository.GetRolClaims_VM(idrol_value);
            ViewBag.IdRol = idrol_value;
            return View("ManageRolClaims", result_rol_RolClaims_VM);
        }

        [Authorize(Policy = "RolDeleteRolClaimsPolicy")]
        [HttpPost]
        public IActionResult DeleteRolClaims(int idrolclaims_value)
        {
            RolClaims_Repository rolClaims_Repository = new RolClaims_Repository();
            Rolclaims result_rolclaims = rolClaims_Repository.GetById(idrolclaims_value);

            Rol_RolClaims_Repository rol_RolClaims_Repository = new Rol_RolClaims_Repository();
            rol_RolClaims_Repository.DeleteRolClaims(idrolclaims_value);

            Rol_RolClaims_VM result_rol_RolClaims_VM = rol_RolClaims_Repository.GetRolClaims_VM(result_rolclaims.IdRol);
            ViewBag.IdRol = result_rolclaims.IdRol;
            return View("ManageRolClaims", result_rol_RolClaims_VM);

        }
    }
}
