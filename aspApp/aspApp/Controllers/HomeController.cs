 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspApp.Controllers
{
    [Authorize(Policy = "HomePolicy")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "View1Policy")]
        public IActionResult Test1()
        {
            return View();
        }

        [Authorize(Policy = "View2Policy")]
        public IActionResult Test2()
        {
            return View();
        }

        [Authorize(Policy = "View3Policy")]
        public IActionResult Test3()
        {
            return View();
        }

        [Authorize(Policy = "View4Policy")]
        public IActionResult Test4()
        {
            return View();
        }

        [Authorize(Policy = "View5Policy")]
        public IActionResult Test5()
        {
            return View();
        }

        [Authorize(Policy = "View6Policy")]
        public IActionResult Test6()
        {
            return View();
        }
    }
}
