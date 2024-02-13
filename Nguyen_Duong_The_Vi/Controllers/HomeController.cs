using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nguyen_Duong_The_Vi.Data;
using Nguyen_Duong_The_Vi.Models;

using System.Diagnostics;
using System.Runtime.CompilerServices;

using X.PagedList;
/*Copyright (c) 2024 Nguyen Duong The Vi*/
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



        public IActionResult DangBai()
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
            string id = HttpContext.Session.GetString("ID");
            ViewBag.Categories = _db.categories.ToList();
            var postTemplist = _db.postTemps.Where(p => p.IDTAUTHOR == int.Parse(id)).ToList();
            ViewBag.PostTemplist = postTemplist;
            ViewBag.Title = "TheVi";
            return View();
        }

        public IActionResult TaoBaiViet()
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
            string id = HttpContext.Session.GetString("ID");
            ViewBag.Categories = _db.categories.ToList();
            var postTemplist = _db.postTemps.Where(p => p.IDTAUTHOR == int.Parse(id)).ToList();

            // Gán kết quả vào ViewBag
            ViewBag.PostTemplist = postTemplist;
            ViewBag.Title = "TheVi";
            Console.WriteLine("ID: " +id);
            return View();
        }


        // POST
  
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult TaoBaiViet(PostTemp obj, IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                obj.LIKE = 0;
                obj.VIEW = 0;
                // Chọn múi giờ của Việt Nam
                TimeZoneInfo vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

                // Lấy thời gian hiện tại theo múi giờ của Việt Nam
                DateTime nowInVietnam = TimeZoneInfo.ConvertTime(DateTime.Now, vnTimeZone);

                // Gán giá trị cho NGAYBINHLUAN
                string id = HttpContext.Session.GetString("ID");
                string name = HttpContext.Session.GetString("Username");
                Console.WriteLine("Name: " + name);
                if (id == null)
                {
                    return NotFound();
                }
                obj.IDTAUTHOR = int.Parse(id);
                obj.PUBLISHED = nowInVietnam;
                obj.AUTHOR = name;
                _db.postTemps.Add(obj);
                _db.SaveChanges();

                int[] selectedCategories = form["PostCategories"].Select(int.Parse).ToArray();

                if (selectedCategories != null)
                {
                    foreach (int categoryID in selectedCategories)
                    {
                        PostCategoryTemp postCategorytem = new PostCategoryTemp();
                        postCategorytem.IDPOSTTEMP=obj.ID;
                        postCategorytem.IDCATEGORY = categoryID;
                        _db.postCategoryTemps.Add(postCategorytem);
                    }
                    _db.SaveChanges();
                }
                if (id == null)
                {
                    return NotFound();
                }
              /*  // Lấy người dùng từ cơ sở dữ liệu dựa trên ID
                User user = _db.users.Find(int.Parse(id));

                // Nếu người dùng không tồn tại, xử lý theo ý của bạn (ví dụ: trả về lỗi 404)
                if (user == null)
                {
                    return NotFound();
                }

                // Kiểm tra xem NumberOfPosts có phải là null hay không
                if (user.NumberOfPosts == null)
                {
                    user.NumberOfPosts = 0; // Nếu là null, gán bằng 0 trước khi cộng thêm 1
                }

                // Cộng thêm 1 vào NumberOfPosts
                user.NumberOfPosts += 1;

                // Cập nhật lại người dùng trong cơ sở dữ liệu
                _db.users.Update(user);

                // Lưu thay đổi vào cơ sở dữ liệu
                _db.SaveChanges();*/
                return RedirectToAction("DangBai");
            }
            return View(obj);
           
        }









        public IActionResult ChinhSuaTaiKhoan(int? id)
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
            string ID = HttpContext.Session.GetString("ID");
            if (ID == null)
            {
                return NotFound();
            }
            else
            {
                if (id != int.Parse(ID))
                {
                    return NotFound();
                }
            }
       




            var user = _db.users.FirstOrDefault(c => c.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.Title = "TheVi";
            return View(user);
        }



        [HttpPost]
        public IActionResult ChinhSuaTaiKhoan(User user)
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
            string ID = HttpContext.Session.GetString("ID");
            if (ID == null)
            {
                return NotFound();
            }
            else
            {
                var existingUser = _db.users.FirstOrDefault(u => u.ID == user.ID);
                if(existingUser == null)
                {
                    return NotFound();
                }
                else
                {
                    if (existingUser.ID != int.Parse(ID))
                    {
                        return NotFound();
                    }
                }
             
            }
            Console.WriteLine("Update tài khoảnxxx");
            if (ModelState.IsValid)
            {
                // You may need to fetch the existing user from the database and update only the properties you want to update
                var existingUser = _db.users.FirstOrDefault(u => u.ID == user.ID);
                Console.WriteLine("User: " + existingUser.UserName);
                if (existingUser != null)
                {
                    existingUser.Job = user.Job;
                    existingUser.Address = user.Address;
                    existingUser.Organization = user.Organization;
                    existingUser.Linkedln = user.Linkedln;
                    existingUser.Youtube = user.Youtube;
                    existingUser.Facebook = user.Facebook;
                    existingUser.Instagram = user.Instagram;
                    existingUser.Twitter = user.Twitter;
                    existingUser.About = user.About;
                    Console.WriteLine("User: " + existingUser.UserName);
                    _db.users.Update(existingUser);
                    _db.SaveChanges();

                    return RedirectToAction("User", "Home", new { id = int.Parse(ID) });
                }
                else
                {
                    return NotFound();
                }
                
               

            }
            return View(user);
        }
        public IActionResult Index()
        {
            Console.WriteLine("Index Home");
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


            var top5Admins = _db.users
            .Where(u => u.Role == "Admin")
            .OrderByDescending(u => u.Point)
            .Take(5)
            .ToList();

            ViewBag.Top5Admins = top5Admins;



            var top5Users = _db.users
          .OrderByDescending(u => u.Point)
          .Take(5)
          .ToList();


            ViewBag.Top5User = top5Users;
            return View(postlist);
        }

        public IActionResult User(int? id)
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
            if (id == null)
            {
                return NotFound();
            }
            User user = _db.users
                     .Where(t => t.ID == id)
                     .FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }
            ViewBag.Title = user.UserName;
            return View(user);
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
      
            string username = HttpContext.Session.GetString("Username");
            string code = HttpContext.Session.GetString("Code");
            string role = HttpContext.Session.GetString("Role");
            string id = HttpContext.Session.GetString("ID");
            string status = HttpContext.Session.GetString("Status");
            if (username != null && code!=null && role!=null)
            {
                Console.WriteLine("TaoBinhTuan");
                var comment = new Comment();
                comment.IDBAIVIET = IDBAIVIET;
                comment.COMMENT = COMMENT;
                comment.Role = role;
                comment.IDUSER = int.Parse(id);
                comment.XACMINH = int.Parse(status);
                // Chọn múi giờ của Việt Nam
                TimeZoneInfo vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

                DateTime nowInVietnam = TimeZoneInfo.ConvertTime(DateTime.Now, vnTimeZone);

                comment.NGAYBINHLUAN = nowInVietnam;

                comment.TENUSER = username;
                _db.comments.Add(comment);
                _db.SaveChanges();

                var updatedCommentList = _db.comments.Where(c => c.IDBAIVIET == IDBAIVIET)
                                                     .OrderByDescending(c => c.NGAYBINHLUAN)
                                                     .ToList();
                User user = _db.users.Find(int.Parse(id));
                if (user == null)
                {
                    return NotFound();
                }

                if (user.NumberOfComment == null)
                {
                    user.NumberOfComment = 0; 
                }
                user.NumberOfComment += 1;

                _db.users.Update(user);

                _db.SaveChanges();

                return PartialView("_CommentListPartial", updatedCommentList);
            }
            return RedirectToAction("Index", "Login");
          
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
