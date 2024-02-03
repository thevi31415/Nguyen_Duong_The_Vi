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
            List<Post> listpost = _db.posts.ToList();
            return View(listpost);
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
                obj.LIKE = 0;
                obj.VIEW = 0;
                obj.PUBLISHED = DateTime.Now;
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



        public IActionResult ChinhSuaBaiDang(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = _db.posts.FirstOrDefault(c => c.ID == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChinhSuaBaiDang(Post obj)
        {
            
            if (ModelState.IsValid)
            {
                obj.PUBLISHED = DateTime.Now;
                _db.posts.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["success"] = "Update thành công !";
            return View(obj);

        }
        public IActionResult XoaBaiDang(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = _db.posts.FirstOrDefault(c => c.ID == id);
            if (post == null)
            {
                return NotFound();
            }
            _db.posts.Remove(post);
            _db.SaveChanges();
            return RedirectToAction("QuanLyBaiDang");
        }
    }
}
