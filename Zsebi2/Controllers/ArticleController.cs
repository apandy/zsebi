using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Zsebi2.Data;
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

        public ActionResult Details(int id)
        {
            var articles = ctx.Articles.OrderBy(p => p.PublishDate).ToList();

            var post = articles.SingleOrDefault(p => p.ID == id);

            return View(post ?? new Article());
        }
    }
}