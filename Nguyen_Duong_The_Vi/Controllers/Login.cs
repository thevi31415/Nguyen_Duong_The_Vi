using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nguyen_Duong_The_Vi.Data;
using Nguyen_Duong_The_Vi.Models;
/*Copyright (c) 2024 Nguyen Duong The Vi*/
namespace Nguyen_Duong_The_Vi.Controllers
{
    public class Login : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public Login(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            string MaNguoiDung = HttpContext.Session.GetString("Username");
            string Code = HttpContext.Session.GetString("Code");
            string Role = HttpContext.Session.GetString("Role");
            if (MaNguoiDung == null || Code == null || Role == null)
            {
                return View("Index");
            }
            else
            {
                if (MaNguoiDung != null && Code != null && Role != null)
                {
                    if (Role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                  

                }

            }
            ViewBag.Title = "Đăng nhập";
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            ViewBag.Title = "Đăng nhập";
            string MaNguoiDung = HttpContext.Session.GetString("Username");
            string Code = HttpContext.Session.GetString("Code");
            string Role = HttpContext.Session.GetString("Role");
            Console.WriteLine(MaNguoiDung + " " + Code + " " + Role);    

            if(MaNguoiDung ==null || Code == null || Role == null)
            {

                if (user != null && user.UserName != null && user.Password != null)
                {
                    string username = user.UserName;
                    string password = user.Password;

                    var users = _db.users.FirstOrDefault(u => u.UserName == username && u.Password == password);
                    if (users != null)
                    {
                        users.LastVisit = DateTime.Now;
                        users.NumberOfVisits++;
                        Console.WriteLine(": " + users.Role);
                        HttpContext.Session.SetString("ID", users.ID.ToString());
                        HttpContext.Session.SetString("Role", users.Role.ToString());
                        HttpContext.Session.SetString("Code", users.Code.ToString());
                        HttpContext.Session.SetString("Username", users.UserName.ToString());
                        HttpContext.Session.SetString("Password", users.Password.ToString());
                        _db.SaveChanges();
                        if (HttpContext.Session.GetString("Role") == "Admin")
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                      
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }

            }
            else
            {
                if (MaNguoiDung != null && Code != null && Role != null )
                {
                    if (Role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                  

                }

            }

          
          


            return View();
        }
        public IActionResult DangXuat()
        {
            /*            HttpContext.Session.Clear();
                        HttpContext.Session.Remove("Role");
                        return RedirectToAction("Index", "DangNhap");*/


            // Xóa tất cả thông tin đăng nhập và session
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
        

            // Xóa tất cả cookies
            var cookies = Request.Cookies.Keys;
            foreach (var cookie in cookies)
            {
                Response.Cookies.Delete(cookie);
            }

            // Redirect đến trang đăng nhập
            return RedirectToAction("Index", "Login");
        }
    }
}
