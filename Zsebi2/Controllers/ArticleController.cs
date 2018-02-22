using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zsebi2.Models;
using Zsebi2.Data;

namespace Zsebi2.Controllers
{
	public class ArticleController : Controller
	{
		private readonly SiteContext ctx;

		public ArticleController(SiteContext ctx)
		{
			this.ctx = ctx;
		}

		public IActionResult Index()
		{
			return View();
		}

		public ActionResult Details(int id)
		{
			var articles = ctx.Articles.OrderBy(p => p.PublishDate).ToList();

			var post = articles.SingleOrDefault(p => p.ID == id);

			return View(post ?? new Article());
		}
	}
}