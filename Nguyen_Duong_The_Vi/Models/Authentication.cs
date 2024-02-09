using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
/*Copyright (c) 2024 Nguyen Duong The Vi*/
namespace Nguyen_Duong_The_Vi.Models
{
    public class Authentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
         /*   string MaNguoiDung = HttpContext.Session.GetString("Username");
            string Code = HttpContext.Session.GetString("Code");
            string Role = HttpContext.Session.GetString("Role");*/
            if (context.HttpContext.Session.GetString("Username") == null || context.HttpContext.Session.GetString("Code") == null
                || context.HttpContext.Session.GetString("Role")!="Admin" || context.HttpContext.Session.GetString("Role") == null)
            {
                context.Result = new RedirectToRouteResult(
                     new RouteValueDictionary
                     {
                         {"Controller", "Login" },
                         {"Action", "Index" }
                     }
                    );
            }
        }
    }
}
