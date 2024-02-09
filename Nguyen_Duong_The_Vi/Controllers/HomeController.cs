﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nguyen_Duong_The_Vi.Data;
using Nguyen_Duong_The_Vi.Models;

using System.Diagnostics;
using System.Runtime.CompilerServices;

using X.PagedList;

namespace Nguyen_Duong_The_Vi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly INotyfService _notfy;
        public HomeController(ApplicationDbContext db, INotyfService notfy)
        {
            _db = db;
            _notfy = notfy;
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
            ViewBag.Title = "TheVi";

            List<Post> postlist = _db.posts
    .Include(p => p.PostCategories)
    .ThenInclude(pc => pc.Category)
    .OrderByDescending(p => p.PUBLISHED)  // Sắp xếp theo ngày Published mới nhất trước
    .Take(4)
    .ToList();


            return View(postlist);
        }
        
        public IActionResult Contact()
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
        public IActionResult Contact(ContactAll obj)
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
                obj.NgayGui = DateTime.Now;
                _db.contactalls.Add(obj);
                _db.SaveChanges();
                _notfy.Success("Gửi thành công");
              
            }
            Console.WriteLine("gjghk");
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
            ViewBag.Title = "About";
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

            ViewBag.Title = "Blog";

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
        public IActionResult Tag(int? page, int? id)

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


            int? targetCategoryID = id; 
            List<Post> postlist = _db.posts.Include(p => p.PostCategories).ThenInclude(pc => pc.Category).ToList();
            var postsAndCategories = (from pc in _db.postCategories
                                      join p in _db.posts on pc.IDPOST equals p.ID
                                      join c in _db.categories on pc.IDCATEGORY equals c.IDCATEGORY
                                      where c.IDCATEGORY == targetCategoryID // Thêm điều kiện cho category cụ thể
                                      group c by p.ID into groupedCategories
                                      select new PostAndCategrory
                                      {
                                          IDPost = groupedCategories.Key,
                                          Categories = groupedCategories.ToList(),
                                      }).ToList();

            ViewBag.PostsAndCategories = postsAndCategories;

            var posts = postlist
               .Where(p => p.PostCategories != null && p.PostCategories.Any(pc => pc.IDCATEGORY == targetCategoryID))
               .OrderByDescending(p => p.PUBLISHED)
               .ToList();
            Category category = _db.categories
          .FirstOrDefault(c => c.IDCATEGORY == targetCategoryID);
            if (category == null)
            {
                return NotFound();
            }
            ViewBag.NameTags = category.TITLE;
            ViewBag.Title = "Tag " +  ViewBag.NameTags;
            PagedList<Post> lst = new PagedList<Post>(posts, pageNumber, pageSize);

            return View(lst);
        }
        public IActionResult Tags(int? page, int? id)

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
            ViewBag.Title = "Tags";
                       List<CategoryViewModel> categoryWithPostCountList = GetCategoryWithPostCount();
            ViewBag.categoryWithPostCountList = categoryWithPostCountList;

            return View();
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


            post.VIEW = (post.VIEW ?? 0) + 1;

          
            _db.Entry(post).State = EntityState.Modified;


            _db.SaveChanges();
            List<Category> categories = _db.postCategories
                .Where(pc => pc.IDPOST == post.ID)
                .Select(pc => pc.Category)
                .ToList();

   
            PostAndCategrory postAndCategory = new PostAndCategrory
            {
                IDPost = post.ID,
                Categories = categories
            };


            var previousPost = _db.posts
                .OrderByDescending(p => p.PUBLISHED)
                .FirstOrDefault(p => p.PUBLISHED < post.PUBLISHED);

            var nextPost = _db.posts
                .OrderBy(p => p.PUBLISHED)
                .FirstOrDefault(p => p.PUBLISHED > post.PUBLISHED);
            ViewBag.PreviousPost = previousPost;
            ViewBag.NextPost = nextPost;
            ViewBag.PostCategories = postAndCategory;
            ViewBag.Title = post.TITLE;


            var comment = _db.comments
            .Where(c => c.IDBAIVIET == id).OrderByDescending(c => c.NGAYBINHLUAN)
            .ToList();

            ViewBag.CommentList= comment;
            return View(post);
        }


        [HttpPost]
        public IActionResult TaoBinhLuan(int IDBAIVIET, string COMMENT)

        {

            /*  var comment = new Comment
              {
                  IDBAIVIET = IDBAIVIET,
                  COMMENT = COMMENT,
                  NGAYBINHLUAN = DateTime.Now
              };

              _db.comments.Add(comment);
              _db.SaveChanges();

              // Load lại danh sách bình luận và trả về JSON
              var updatedComments = _db.comments
                  .Where(c => c.IDBAIVIET == IDBAIVIET)
                  .ToList();

              return Json(updatedComments);*/
      
            string username = HttpContext.Session.GetString("Username");
            var comment = new Comment();
            comment.IDBAIVIET = IDBAIVIET;
            comment.COMMENT = COMMENT;
            comment.NGAYBINHLUAN = DateTime.Now;
            comment.TENUSER = username;
            _db.comments.Add(comment);
            _db.SaveChanges();

            var updatedCommentList = _db.comments.Where(c => c.IDBAIVIET == IDBAIVIET)
                                                 .OrderByDescending(c => c.NGAYBINHLUAN)
                                                 .ToList();


            return PartialView("_CommentListPartial", updatedCommentList);
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
                          group new { category, postCategory } by new { category.IDCATEGORY, category.TITLE, category.CONTEXT } into grouped
                          select new CategoryViewModel
                          {
                              IDCATEGORY = grouped.Key.IDCATEGORY,
                              TITLECATEGORY = grouped.Key.TITLE,
                              CONTEXT = grouped.Key.CONTEXT,
                              PostCount = grouped.Count()
                          })
                .OrderByDescending(c => c.PostCount)
                .ToList();

            return result;
        }

    }
}
