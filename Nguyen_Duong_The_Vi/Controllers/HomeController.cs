using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nguyen_Duong_The_Vi.Data;
using Nguyen_Duong_The_Vi.Models;
using System.Diagnostics;
using X.PagedList;

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
        public IActionResult Blog(int? page, string searchString, string searchBy)
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
            


            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;



            IQueryable<Post> postlist = _db.posts;

           
            Console.WriteLine("Tìm kiem: searchby: " + searchBy);
            Console.WriteLine("Tìm kiem: searchstring: " + searchString);
            if (!string.IsNullOrEmpty(searchString))
            {
               
                    postlist = postlist.Where(x => x.TITLE.Contains(searchString));
                
             
            }
            else
            {
                postlist = _db.posts;
            }


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

            var posts = postlist.OrderByDescending(p => p.PUBLISHED).ToList();
            PagedList<Post> lst = new PagedList<Post>(posts, pageNumber, pageSize);


            ViewData["CurrentFilter"] = searchString;
            ViewData["SearchBy"] = searchBy;



            List<CategoryViewModel> categoryWithPostCountList = GetCategoryWithPostCount();
            ViewBag.categoryWithPostCountList = categoryWithPostCountList;
            

            return View(lst);
          
        }
        public IActionResult BaiDang(int? id)
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
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = _db.posts
         .Include(p => p.PostCategories)
         .FirstOrDefault(c => c.ID == id);


            if (post == null)
            {
                return NotFound();
            }



            List<Category> categories = _db.postCategories
                .Where(pc => pc.IDPOST == post.ID)
                .Select(pc => pc.Category)
                .ToList();

   
            PostAndCategrory postAndCategory = new PostAndCategrory
            {
                IDPost = post.ID,
                Categories = categories
            };


            ViewBag.PostCategories = postAndCategory;
            return View(post);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public List<CategoryViewModel> GetCategoryWithPostCount()
        {
            var result = (from category in _db.categories
                          join postCategory in _db.postCategories on category.IDCATEGORY equals postCategory.IDCATEGORY
                          group postCategory by new { category.IDCATEGORY, category.TITLE } into grouped
                          select new CategoryViewModel
                          {
                              IDCATEGORY = grouped.Key.IDCATEGORY,
                              TITLECATEGORY = grouped.Key.TITLE,
                              PostCount = grouped.Count()
                          })
                .OrderByDescending(c => c.PostCount)
                .ToList();

            return result;
        }
    }
}
