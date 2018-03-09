using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Zsebi2.Controllers
{
    public class SatelliteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SatelliteEngineering()
        {
            return PartialView("_SatelliteEngineering");
        }

        public IActionResult SatelliteEPS1()
        {
            return PartialView("_SatelliteEPS1");
        }

        public IActionResult SatelliteEPS2()
        {
            return PartialView("_SatelliteEPS2");
        }

        public IActionResult SatelliteOBC()
        {
            return PartialView("_SatelliteOBC");
        }

        public IActionResult SatelliteTID()
        {
            return PartialView("_SatelliteTID");
        }

        public IActionResult SatelliteCOM()
        {
            return PartialView("_SatelliteCOM");
        }

    }
}