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
        public IActionResult QuanLyTaiKhoan()
        {
            ThongTin firstThongTin = _db.thongTins.FirstOrDefault();
            if (firstThongTin == null)
            {
                return NotFound();
            }        
            else
            {
                ViewBag.ThongTin = firstThongTin;

            }
           List<User> listuser = _db.users.ToList();
            return View(listuser);
        }
        public IActionResult TaoTaiKhoan()
        {
            ThongTin firstThongTin = _db.thongTins.FirstOrDefault();
            if (firstThongTin == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.ThongTin = firstThongTin;

            }
            
            return View();
        }
        [HttpPost]
        public IActionResult TaoTaiKhoan(User user)
        {
            ThongTin firstThongTin = _db.thongTins.FirstOrDefault();
            if (firstThongTin == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.ThongTin = firstThongTin;

            }
            if (ModelState.IsValid)
            {
                _db.users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authentication]
        public IActionResult Index()
        {
            return View();
        }
        [Authentication]
        public IActionResult QuanLyTag()
        {
            List<Category> listcategory = _db.categories.ToList();
            return View(listcategory);
        }
        [Authentication]
        public IActionResult TaoTag()
        {
          
            return View();
        }
        [Authentication]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TaoTag(Category obj)
        {
            if (ModelState.IsValid)
            {
                
                _db.categories.Add(obj);
                _db.SaveChanges();

               

                return RedirectToAction("Index");
            }

            return View(obj);
         }
        [Authentication]
        public IActionResult XoaTag(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.categories.FirstOrDefault(c => c.IDCATEGORY== id);
            if (category == null)
            {
                return NotFound();
            }
            _db.categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("QuanLyTag");
        }
        [Authentication]
        public IActionResult QuanLyBaiDang()
        {
            List<Post> listpost = _db.posts.ToList();
            return View(listpost);
        }
        [Authentication]
        public IActionResult TaoBaiDang()
        {
            ViewBag.Categories = _db.categories.ToList();
            return View();
        }
        // POST
        [Authentication]
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


        [Authentication]
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
        [Authentication]
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
        [Authentication]
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
