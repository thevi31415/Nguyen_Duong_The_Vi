using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nguyen_Duong_The_Vi.Data;
using Nguyen_Duong_The_Vi.Models;
using System.Diagnostics;

namespace Nguyen_Duong_The_Vi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
   
        public IActionResult Index()
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

        public IActionResult Privacy()
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
        public IActionResult About()
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
        public IActionResult Blog()
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

            var posts = _db.posts.ToList();
            var categrory = _db.categories.ToList();
            var categrorypost = _db.postCategories.ToList();
            var postsAndCategories = (from pc in _db.postCategories
                                      join p in _db.posts on pc.IDPOST equals p.ID
                                      join c in _db.categories on pc.IDCATEGORY equals c.IDCATEGORY
                                      group c by p.ID into groupedCategories
                                      select new PostAndCategrory
                                      {
                                          IDPost = groupedCategories.Key,
                                          Categories = groupedCategories.ToList(),
                                      }).ToList();
            ViewBag.PostsAndCategories = postsAndCategories;
            return View(posts);
          
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
