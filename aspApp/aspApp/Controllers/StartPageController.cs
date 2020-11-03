using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspApp.Models;
using aspApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspApp.Controllers
{
    public class StartPageController : Controller
    {
        public IActionResult Index()
        {
            StartPage_Repository startPage_Repository = new StartPage_Repository();
            return View(startPage_Repository.GetAll());
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            StartPage_Repository startPage_Repository = new StartPage_Repository();
            return View(startPage_Repository.GetById(id));
        }

        public IActionResult Delete(int id)
        {
            StartPage_Repository startPage_Repository = new StartPage_Repository();
            return View(startPage_Repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(Startpage startpage)
        {
            StartPage_Repository startPage_Repository = new StartPage_Repository();
            startPage_Repository.Insert(startpage);
            //return View();
            return RedirectToAction("Index", "StartPage");
        }

        [HttpPost]
        public IActionResult Edit(Startpage startpage)
        {
            StartPage_Repository startPage_Repository = new StartPage_Repository();
            startPage_Repository.Update(startpage);
            //return View();
            return RedirectToAction("Index", "StartPage");
        }

        [HttpPost]
        public IActionResult Delete(Startpage startpage)
        {
            StartPage_Repository startPage_Repository = new StartPage_Repository();
            startPage_Repository.Delete(startpage);
            //return View();
            return RedirectToAction("Index", "StartPage");
        }
    }
}