using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nguyen_Duong_The_Vi.Data;
using Nguyen_Duong_The_Vi.Models;

namespace Nguyen_Duong_The_Vi.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public RegisterController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
             Console.WriteLine("uSEE: " + user.UserName);  
            if (user == null)
            {
                return NotFound();
               
            }
            else
            {
                string emal = user.Email.Trim();
                string username = user.UserName.Trim();
                bool emailExists = _db.users.Any(u => u.Email == emal);
                bool userExists = _db.users.Any(u => u.UserName == username);
                if(emailExists == true || userExists == true) {

                    ViewBag.CheckUser = false;

                    if(emailExists == true && userExists == false) {

                        ViewBag.Info = "Đăng ký không thành công ! Email đã có người sử dụng !";


                    }else if(emailExists == false && userExists == true)
                    {
                        ViewBag.Info = "Đăng ký không thành công ! Tên đăng nhập đã có người sử dụng !";
                    }else if (emailExists == true && userExists == true)
                    {
                        ViewBag.Info = "Đăng ký không thành công ! Tên đăng nhập  và email đã có người sử dụng !";
                    }

                }
                else
                {
                    ViewBag.CheckUser = true;
                    user.Role = "User";
                    user.Status = 0;
                    user.UserName = username.Trim();
                    user.Email = emal.Trim();
                    user.Password = user.Password.Trim();
                    user.NumberOfVisits = 0;
                    user.NumberOfPosts = 0;
                    user.Point = 0;
                    user.Code = "123";
                    _db.Add(user);
                    _db.SaveChanges();

                    // Xóa tất cả thông tin đăng nhập và session
                    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.Session.Clear();


                    // Xóa tất cả cookies
                    var cookies = Request.Cookies.Keys;
                    foreach (var cookie in cookies)
                    {
                        Response.Cookies.Delete(cookie);
                    }

                }
            }

            return View();
        }
    }
}
