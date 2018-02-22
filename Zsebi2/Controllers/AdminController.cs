using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zsebi2.Data;
using Zsebi2.Models;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Zsebi2.Controllers
{
	public class AdminController : Controller
	{
		private readonly SiteContext _context;

		public AdminController(SiteContext context)
		{
			_context = context;


		}

		// GET: Admin
		public async Task<IActionResult> Index()
		{
			//MigrateDb();
			return View(await _context.Articles.OrderByDescending(a=>a.PublishDate).ToListAsync());
		}

		//private void MigrateDb()
		//{
		//	foreach(var news in _context.NewsList.ToList())
		//	{
		//		try
		//		{

		//			var pos1 = news.newstext.IndexOf("<p class=\"newstext\">") + "<p class=\"newstext\">".Length;
		//			var text = news.newstext.Substring(pos1, news.newstext.IndexOf("</p>", pos1) - pos1);

		//			pos1 = news.newstext.IndexOf("<h2 class=\"newstitle\">") + "<h2 class=\"newstitle\">".Length;
		//			var pos2 = news.newstext.IndexOf("return false\">", pos1) + "return false\">".Length;
		//			var title = (pos2 > "<h2 class=\"newstitle\">".Length) 
		//				? news.newstext.Substring(pos2, news.newstext.IndexOf("</a>", pos2) - pos2)
		//				: news.newstext.Substring(pos1, news.newstext.IndexOf("</h2>", pos1) - pos1);

		//			pos1 = news.newstext.IndexOf("<img class=\"newspic\" src=\"") + "<img class=\"newspic\" src=\"".Length;
		//			var imgSrc = news.newstext.Substring(pos1, news.newstext.IndexOf("\"", pos1) - pos1);
		//			imgSrc = imgSrc.Substring(imgSrc.LastIndexOf("/") + 1);

		//			pos1 = news.newstext.IndexOf("<p class=\"date\">") + "<p class=\"date\">".Length;
		//			var date = DateTime.Parse(news.newstext.Substring(pos1, news.newstext.IndexOf("</p>", pos1) - pos1));

		//			pos1 = news.newstext.IndexOf("<a class=\"more\" href=\"") + "<a class=\"more\" href=\"".Length;
		//			var moreLink = (pos1 > "<a class=\"more\" href=\"".Length)
		//				? news.newstext.Substring(pos1, news.newstext.IndexOf("\"", pos1) - pos1).Replace("smog1/articles/", "articles/")
		//				: default(string);

		//			_context.Posts.Add(new Post
		//			{
		//				Title = title,
		//				ThumbnailFileName = imgSrc,
		//				PublishDate = date,
		//				HtmlBody = text,
		//				Excerpt = text.Substring(0, Math.Min(200, text.Length)),
		//				MoreInfoUrl = moreLink
		//			});
		//		}
		//		catch (Exception ex)
		//		{


		//		}
		//	}

		//	_context.SaveChanges();
		//}

		// GET: Admin/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var post = await _context.Articles
				.SingleOrDefaultAsync(m => m.ID == id);
			if (post == null)
			{
				return NotFound();
			}

			return View(post);
		}

		// GET: Admin/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Admin/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ID,Title,HtmlBody,PublishDate,ThumbnailFileName,Excerpt")] Article article)
		{
			if (ModelState.IsValid)
			{
				_context.Add(article);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(article);
		}

		// GET: Admin/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var post = await _context.Articles.SingleOrDefaultAsync(m => m.ID == id);
			if (post == null)
			{
				return NotFound();
			}
			return View(post);
		}

		// POST: Admin/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ID,Title,HtmlBody,PublishDate,ThumbnailFileName,Excerpt")] Article article)
		{
			if (id != article.ID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(article);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ArticleExists(article.ID))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction("Index");
			}
			return View(article);
		}

		// GET: Admin/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var post = await _context.Articles
				.SingleOrDefaultAsync(m => m.ID == id);
			if (post == null)
			{
				return NotFound();
			}

			return View(post);
		}

		// POST: Admin/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var post = await _context.Articles.SingleOrDefaultAsync(m => m.ID == id);
			_context.Articles.Remove(post);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}




		private bool ArticleExists(int id)
		{
			return _context.Articles.Any(e => e.ID == id);
		}


		private string LocalUpladedFolderPath
		{
			get
			{
				return Path.Combine(Directory.GetCurrentDirectory(),
				   "wwwroot\\images\\uploaded\\");
			}
		}


		private string webBasePath = "/images/uploaded/";


		// GET: Admin/CKEditorFileBrowse
		public IActionResult CKEditorFileBrowse(string type)
		{
			var images = Directory.EnumerateFiles(LocalUpladedFolderPath).Where(i=>i.EndsWith("png") || i.EndsWith("jpg")).Select(i=>Path.GetFileName(i));

			return View(images);
		}

		public IActionResult FileBrowse(string type)
		{
			var images = Directory.EnumerateFiles(LocalUpladedFolderPath).Where(i => i.EndsWith("png") || i.EndsWith("jpg")).Select(i => Path.GetFileName(i));

			return View(images);
		}
						
		
		public async Task<IActionResult> CKEditorFileUpload(int ckEditorFuncNum , IFormFile upload)
		{
			ViewBag.FuncNum = ckEditorFuncNum;

			var originalFileName = Path.GetFileName(upload.FileName);

	
			var localFilePath = Path.Combine(LocalUpladedFolderPath,originalFileName);
			var webFilePath = Path.Combine(webBasePath, originalFileName);

			if (System.IO.File.Exists(localFilePath))
			{
				return Content("File " + webFilePath + " already exists on server.");
			}

			if (upload.Length > 0)
			{
				using (var stream = new FileStream(localFilePath, FileMode.Create))
				{
					await upload.CopyToAsync(stream);
				}
			}

			
			ViewBag.Url = webFilePath;
			ViewBag.Message = "";

			return View();			
		}
		public IActionResult FileUploadSelector()
		{
			return View();
		}

		public async Task<IActionResult> FileUpload(IFormFile upload)
		{
			var originalFileName = Path.GetFileName(upload.FileName);


			var localFilePath = Path.Combine(LocalUpladedFolderPath, originalFileName);
			var webFilePath = Path.Combine(webBasePath, originalFileName);

			if (System.IO.File.Exists(localFilePath))
			{
				ViewBag.Message = "File " + webFilePath + " already exists on server.";
				return View();
			}

			if (upload.Length > 0)
			{
				using (var stream = new FileStream(localFilePath, FileMode.Create))
				{
					await upload.CopyToAsync(stream);
				}
			}


			ViewBag.Url = webFilePath;
			ViewBag.Message = "";

			return View();
		}
	}
}
