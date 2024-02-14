using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nguyen_Duong_The_Vi.Data;
using Nguyen_Duong_The_Vi.Models;
using System.Reflection.Metadata.Ecma335;
/*Copyright (c) 2024 Nguyen Duong The Vi*/
namespace Nguyen_Duong_The_Vi.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authentication]
        public IActionResult DuyetBaiViet()
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
            var baiviet = _db.postTemps.OrderByDescending(post => post.PUBLISHED).ToList();

            return View(baiviet);
        }
        [Authentication]
        public IActionResult DuyetDuyetBaiViet(int? id)
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

            var posttemp = _db.postTemps.Find(id);
            Post post = new Post();

            post.TITLE = posttemp.TITLE;
            post.AUTHOR = posttemp.AUTHOR;
            post.SUMMARY = posttemp.SUMMARY;
            post.IDTAUTHOR = posttemp.IDTAUTHOR;
            post.VIEW = 0;
            post.LIKE = 0;
            post.PUBLISHED = posttemp.PUBLISHED;    
            post.CONTEXT = posttemp.CONTEXT;

            _db.posts.Add(post);
            _db.SaveChanges();

            var lastId = _db.posts.Max(e => (int?)e.ID) ?? 0;
            var posttempcategory = _db.postCategoryTemps
            .Where(pc => pc.IDPOSTTEMP == posttemp.ID);

            foreach (var category in posttempcategory)
            {
                PostCategory pc = new PostCategory();
                pc.IDPOST = lastId;
                pc.IDCATEGORY = category.IDCATEGORY;
                _db.postCategories.Add(pc);
           
            }
            _db.SaveChanges();
            var newEntity = new PostCategoryTemp { IDPOSTTEMP = posttemp.ID, /* Các thuộc tính khác */ };
            _db.postCategoryTemps.Add(newEntity);
            _db.SaveChanges();



            var postCategoryTempsToDelete =_db.postCategoryTemps
           .Where(pct => pct.IDPOSTTEMP == posttemp.ID);

            if (postCategoryTempsToDelete.Any())
            {
                _db.postCategoryTemps.RemoveRange(postCategoryTempsToDelete);
                _db.SaveChanges();
            }


            User user = _db.users.Find((posttemp.IDTAUTHOR));

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
            _db.SaveChanges();



            _db.postTemps.Remove(posttemp);
            _db.SaveChanges();
            /*    public int ID { get; set; }

         public int? VIEW { get; set; }

         public int? IDTAUTHOR { get; set; }
         public int? LIKE { get; set; }
         public string? AUTHOR { get; set; }

         public string? SUMMARY { get; set; }

         public string? TITLE { get; set; }

         public DateTime PUBLISHED { get; set; }

         public string? CONTEXT { get; set; }
 */
            return View("Index");
        }
    
        public IActionResult XoaDuyetBaiViet(int? id)
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
            var bv = _db.postTemps.FirstOrDefault(c => c.ID == id);
            if (bv == null)
            {
                return NotFound();
            }
            _db.postTemps.Remove(bv);
            _db.SaveChanges();
            return RedirectToAction("DuyetBaiViet");

            
        }
        [Authentication]
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
        [Authentication]
        public IActionResult PhanQuyen()
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
        [Authentication]
        public IActionResult TinhDiem()
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
            // Lấy tất cả người dùng từ cơ sở dữ liệu
            List<User> users = _db.users.ToList();

            // Tính điểm cho từng người dùng và cập nhật vào cơ sở dữ liệu
            foreach (var user in users)
            {
                int points = (user.NumberOfPosts ?? 0) * 10 + (user.NumberOfComment ?? 0) * 1;
                user.Point = points;

                // Cập nhật lại người dùng trong cơ sở dữ liệu
                _db.users.Update(user);
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            _db.SaveChanges();
            return RedirectToAction("QuanLyTaiKhoan");
        }
        [Authentication]
        public IActionResult ChinhSuaPhanQuyen(int? id)
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

            var user = _db.users.FirstOrDefault(c => c.ID == id);
            if (user == null)
            {
                return NotFound();
            }


            return View(user);
        }
        [Authentication]
        [HttpPost]
        public IActionResult ChinhSuaPhanQuyen(User user)
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

            var userex = _db.users.FirstOrDefault(c => c.ID == user.ID);
            if (userex == null)
            {
                return NotFound();
            }
            userex.Status = user.Status;
            userex.Role = user.Role;

            _db.users.Update(userex);
            _db.SaveChanges();

            var comments = _db.comments.Where(c => c.IDUSER == userex.ID).ToList();

            foreach (var comment in comments)
            {
                comment.XACMINH = userex.Status;
                comment.Role = userex.Role;
            }

            _db.SaveChanges();


            return RedirectToAction("PhanQuyen");
        }
        [Authentication]
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
        [Authentication]
        public IActionResult XoaTaiKhoan(int? id)
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
            var category = _db.users.FirstOrDefault(c => c.ID == id);
            if (category == null)
            {
                return NotFound();
            }
            _db.users.Remove(category);
            _db.SaveChanges();
          return  RedirectToAction("QuanLyTaiKhoan");
        }
        [Authentication]
        public IActionResult QuanLyBinhLuan()

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
            List<Comment> listcommern = _db.comments.OrderByDescending(c => c.NGAYBINHLUAN).ToList();

            return View(listcommern);
        }
        [Authentication]
        public IActionResult XoaBinhLuan(int? id)

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


            var category = _db.comments.FirstOrDefault(c => c.ID == id);
            if (category == null)
            {
                return NotFound();
            }


            _db.comments.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("QuanLyBinhLuan");
        }
        [Authentication]
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
                user.NumberOfPosts = 0;
                user.NumberOfComment = 0;
                user.Point = 0;
                user.NumberOfVisits = 0;
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
                // Chọn múi giờ của Việt Nam
                TimeZoneInfo vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

                // Lấy thời gian hiện tại theo múi giờ của Việt Nam
                DateTime nowInVietnam = TimeZoneInfo.ConvertTime(DateTime.Now, vnTimeZone);

                // Gán giá trị cho NGAYBINHLUAN
                string id = HttpContext.Session.GetString("ID");
                if(id == null)
                {
                    return NotFound();
                }
                obj.IDTAUTHOR = int.Parse(id);
                obj.PUBLISHED = nowInVietnam;
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
                if (id == null)
                {
                    return NotFound();
                }
                // Lấy người dùng từ cơ sở dữ liệu dựa trên ID
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
                _db.SaveChanges();
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
                // Chọn múi giờ của Việt Nam
                TimeZoneInfo vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

                // Lấy thời gian hiện tại theo múi giờ của Việt Nam
                DateTime nowInVietnam = TimeZoneInfo.ConvertTime(DateTime.Now, vnTimeZone);
                var post = _db.posts.Find(obj.ID);
                post.CONTEXT = obj.CONTEXT;
                post.TITLE = obj.TITLE;
                post.SUMMARY = obj.SUMMARY;
                post.PUBLISHED = nowInVietnam;
                obj.PUBLISHED = nowInVietnam;
                _db.posts.Update(post);
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






            // Lấy tất cả các comment dựa trên IDBAIVIET
            List<Comment> commentsToDelete = _db.comments.Where(c => c.IDBAIVIET == id).ToList();

            // Lấy tất cả các IDUSER của các comment sẽ bị xóa
            List<int?> userIdsToDelete = commentsToDelete.Select(c => c.IDUSER).ToList();

            // Xóa tất cả các comment
            _db.comments.RemoveRange(commentsToDelete);

            // Lưu thay đổi vào cơ sở dữ liệu
            _db.SaveChanges();

            // Giảm giá trị NumberOfComment của các người dùng tương ứng
            foreach (var userId in userIdsToDelete)
            {
                if (userId.HasValue)
                {
                    User user = _db.users.Find(userId.Value);
                    if (user != null && user.NumberOfComment != null && user.NumberOfComment > 0)
                    {
                        user.NumberOfComment -= 1;
                        _db.users.Update(user);
                    }
                }
            }

            _db.SaveChanges();





             // Find the user by ID
            var user1 = _db.users.Find(post.IDTAUTHOR);

            if (user1 != null && user1.NumberOfPosts > 0)
            {
                // Decrease the NumberOfPosts for the user
               user1.NumberOfPosts--;

                // Save changes to the database
                _db.SaveChanges();
            }











            return RedirectToAction("QuanLyBaiDang");
        }

        [Authentication]
        public IActionResult QuanLyThongTin()
        {
           


            var thongtin = _db.thongTins.FirstOrDefault();
            if (thongtin == null)
            {
                return NotFound();
            }
            return View(thongtin);
        }
        [Authentication]
        public IActionResult CapNhatThongTin(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.thongTins.FirstOrDefault(c => c.ID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);


        }
        [Authentication]
        [HttpPost]
        public IActionResult CapNhatThongTin(ThongTin obj)
        {
            if (ModelState.IsValid)
            {
                _db.thongTins.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["success"] = "Update thành công !";
            return View(obj);
       


        }

    }
}
