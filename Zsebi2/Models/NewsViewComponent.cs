using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zsebi2.Data;

namespace Zsebi2.Models
{
    public class NewsViewComponent : ViewComponent
	{
		private readonly SiteContext db;
		private int pageSize = 3;

		public NewsViewComponent(SiteContext context)
		{
			db = context;
		}
		
		public async Task<IViewComponentResult> InvokeAsync(int? page)
		{

			var articles = await GetArticlesAsync(page);

			ViewData["hasNextPage"] = articles.HasNextPage;
			ViewData["hasPreviousPage"] = articles.HasPreviousPage;

			ViewData["nextPage"] = articles.PageIndex + 1;
			ViewData["previousPage"] = articles.PageIndex - 1;

			return View(articles);
		}
		public Task<PaginatedList<Article>> GetArticlesAsync(int? page)
		{
			
			var articles = db.Articles.OrderByDescending(i=>i.PublishDate);
			
			return PaginatedList<Article>.CreateAsync(articles.AsNoTracking(), page ?? 1, pageSize);
			
		}


		public PaginatedList<Article> GetPosts(int? page)
		{

			var posts = db.Articles.OrderByDescending(i => i.PublishDate);

			return PaginatedList<Article>.Create(posts.AsNoTracking(), page ?? 1, pageSize);

		}

	}
}
