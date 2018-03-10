using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Zsebi2.DataLayer;
using Zsebi2.Models;

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

        public ActionResult Details(string id)
        {
            var articles = ctx.Articles.OrderBy(p => p.PublishDate).ToList();

            Article post;
            if (Int32.TryParse(id, out var numericId))
            {
                post = articles.FirstOrDefault(p => p.ID == numericId);
            }
            else
            {
                post = articles.FirstOrDefault(p => p.Url == id);
            }
            
            return View(post ?? new Article());
        }
    }
}