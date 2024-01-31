using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nguyen_Duong_The_Vi.Data;
using Nguyen_Duong_The_Vi.Models;

namespace Nguyen_Duong_The_Vi.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult QuanLyBaiDang()
        {
            return View();
        }

        public IActionResult TaoBaiDang()
        {
            ViewBag.Categories = _db.categories.ToList();
            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TaoBaiDang(Post obj, IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                _db.posts.Add(obj);
                _db.SaveChanges();

                int[] selectedCategories = form["PostCategories"].Select(int.Parse).ToArray();

                if (selectedCategories != null)
                {
                    foreach (int categoryID in selectedCategories)
                    {
                        PostCategory postCategory = new PostCategory();
                        postCategory.IDPOST = obj.ID;
                        postCategory.IDCATEGORY = categoryID;
                        _db.postCategories.Add(postCategory);
                    }
                    _db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
