using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zsebi2.Data;
using Zsebi2.Models;

namespace Zsebi2.Controllers
{
	public class NewsController : Controller
	{
		private readonly SiteContext ctx;

		public NewsController(SiteContext ctx)
		{
			this.ctx = ctx;
		}


		// GET: News
		public ActionResult Index(int? page)
		{
			var news = new NewsViewComponent(ctx);

			var posts = news.GetPosts(page);

			ViewData["hasNextPage"] = posts.HasNextPage;
			ViewData["hasPreviousPage"] = posts.HasPreviousPage;

			ViewData["nextPage"] = posts.PageIndex + 1;
			ViewData["previousPage"] = posts.PageIndex - 1;


			return PartialView("/Views/Shared/Components/News/Default.cshtml", posts);
		}

		//// GET: News/Details/5
		//public ActionResult Details(SiteContext ctx, int id)
		//{
		//	var posts = ctx.Posts.OrderBy(p => p.PublishDate).ToList();

		//	var post = posts.SingleOrDefault(p => p.ID == id);

		//	var prevIndex = posts.IndexOf(post) - 1;
		//	var hasPrevPost = prevIndex > -1;

		//	ViewData["hasPrevPost"] = hasPrevPost;
		//	ViewData["prevPostId"] = hasPrevPost ? posts[prevIndex].ID : -1;

		//	var nextIndex = posts.IndexOf(post) + 1;
		//	var hasBextPost = nextIndex < posts.Count;
		//	ViewData["hasNextPost"] = hasBextPost;
		//	ViewData["nextPostId"] = hasBextPost ? posts[nextIndex].ID : -1;

		//	ViewData["currentPostPosition"] = posts.IndexOf(post) + 1;
		//	ViewData["postsCount"] = posts.Count;


		//	return View(post ?? new Post());
		//}

		//// GET: News/Create
		//public ActionResult Create()
		//{
		//	return View();
		//}

		//// POST: News/Create
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Create(IFormCollection collection)
		//{
		//    try
		//    {
		//        // TODO: Add insert logic here

		//        return RedirectToAction("Index");
		//    }
		//    catch
		//    {
		//        return View();
		//    }
		//}

		//// GET: News/Edit/5
		//public ActionResult Edit(int id)
		//{
		//    return View();
		//}

		//// POST: News/Edit/5
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Edit(int id, IFormCollection collection)
		//{
		//    try
		//    {
		//        // TODO: Add update logic here

		//        return RedirectToAction("Index");
		//    }
		//    catch
		//    {
		//        return View();
		//    }
		//}

		//// GET: News/Delete/5
		//public ActionResult Delete(int id)
		//{
		//    return View();
		//}

		//// POST: News/Delete/5
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Delete(int id, IFormCollection collection)
		//{
		//    try
		//    {
		//        // TODO: Add delete logic here

		//        return RedirectToAction("Index");
		//    }
		//    catch
		//    {
		//        return View();
		//    }
		//}
	}
}