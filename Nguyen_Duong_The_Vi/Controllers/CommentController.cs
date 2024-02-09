using Microsoft.AspNetCore.Mvc;
using Nguyen_Duong_The_Vi.Data;
using Nguyen_Duong_The_Vi.Models;

namespace Nguyen_Duong_The_Vi.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _db;
        [HttpPost]
        public JsonResult LeaveComment(CommentViewModel model)
        {
            Comment comment = new Comment();
            comment.COMMENT= model.Text;
          
            comment.IDBAIVIET = model.EntityID;
        /*    comment.RecordID = model.RecordID;
            comment.Rating = model.Rating;*/
            comment.NGAYBINHLUAN = DateTime.Now;
            var result = new {Sucess = _db.comments.Add(comment) };
            JsonResult json = new JsonResult(result);
          
     
            return json;
        }



    }
}
