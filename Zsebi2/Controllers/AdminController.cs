using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zsebi2.Models;
using Zsebi2.Services;

namespace Zsebi2.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IArticleService _articleService;

        public AdminController(IUserServices userServices, IArticleService articleService)
        {
            _userServices = userServices;
            _articleService = articleService;
        }

        // GET: Admin
        public async Task<IActionResult> Index(int page = 1, int size = 50)
        {
            //MigrateDb();
            var articles = await _articleService.GetArticlesByDateDescending(page, size);
            return View(articles);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var adminUser = await _userServices.GetAdminUser();
            if (adminUser != null)
            {
                if (model.Email != adminUser.Email ||
                    !adminUser.CheckPassword(model.Password))
                {
                    ModelState.AddModelError(nameof(LoginViewModel.Password), "Invalid username or password");
                    return View(model);
                }
            }

            var email = adminUser?.Email ?? "<Email hiányzik>";
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Email, email)
            };

            //init the identity instances 
            var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "SingeLogin"));
            await HttpContext.SignInAsync(userPrincipal, new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                AllowRefresh = true
            });
            return adminUser != null ? RedirectToAction("Index") : RedirectToAction("Profile");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var adminUser = await _userServices.GetAdminUser();
            return View(new ProfileViewModel
            {
                Email = adminUser?.Email
            });
        }
        [HttpPost]
        public async Task<IActionResult> Profile(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _userServices.SaveAdminUser(model.Email, model.Password);
            return RedirectToAction("Index");
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _articleService.GetArticleById(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            ViewBag.GenerateUrl = true;
            return View("Edit", new ArticleModel
            {
                PublishDate = DateTime.Today,
                GenerateUrl = true
            });
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticleModel article)
        {
            if (ModelState.IsValid)
            {
                await _articleService.SaveArticle(article);
                return RedirectToAction("Index");
            }
            return View("Edit", article);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _articleService.GetArticleById(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            ViewBag.GenerateUrl = false;
            return View(post);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArticleModel article)
        {
            if (id != article.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _articleService.SaveArticle(article);
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

            var post = await _articleService.GetArticleById(id.Value);
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
            await _articleService.DeleteArticleById(id);
            return RedirectToAction("Index");
        }


        private string LocalUpladedFolderPath => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "uploaded");


        private string webBasePath = "/images/uploaded/";


        // GET: Admin/CKEditorFileBrowse
        public IActionResult CKEditorFileBrowse(string type)
        {
            var images = Directory.EnumerateFiles(LocalUpladedFolderPath)
                .Where(i => i.EndsWith("png") || i.EndsWith("jpg"))
                .Select(Path.GetFileName);

            return View(images);
        }

        public IActionResult FileBrowse(string type)
        {
            var images = Directory.EnumerateFiles(LocalUpladedFolderPath)
                .Where(i => i.EndsWith("png") || i.EndsWith("jpg"))
                .Select(Path.GetFileName);

            return View(images);
        }


        public async Task<IActionResult> CKEditorFileUpload(int ckEditorFuncNum, IFormFile upload)
        {
            ViewBag.FuncNum = ckEditorFuncNum;

            var originalFileName = Path.GetFileName(upload.FileName);


            var localFilePath = Path.Combine(LocalUpladedFolderPath, originalFileName);
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
