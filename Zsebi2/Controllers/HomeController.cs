using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zsebi2.Models;
using Zsebi2.Data;

namespace Zsebi2.Controllers
{
    public class HomeController : Controller
    {
		private SiteContext ctx;

		public HomeController(SiteContext ctx)
		{
			this.ctx = ctx;
		}

		public IActionResult Index()
		{
			var subSystems =
				ctx.TeamMembers				
				.GroupBy(m => m.SubSystem).
				Select(s=> new SubSystem {
					Name = s.Key,
					SystemName = s.First().System,
					Members = s.ToList()
				} ).ToList();

			var model = new MainViewModel
			{
				Team = new TeamViewModel
				{
					SubSystems = subSystems
				}
			};

			return View(model);
		}

		public IActionResult RadioDetails()
		{
			return PartialView("_RadioDetails");
		}
		public IActionResult ContactTeam()
		{		
			return PartialView("_ContactTeam");
		}
		public IActionResult SatelliteEngineering()
		{
			return PartialView("_SatelliteEngineering");
		}

		public IActionResult TechnicalInfo()
		{
			return View();
		}


		public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
