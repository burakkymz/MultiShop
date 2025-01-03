using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _context.UserComments.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult CommentDetail(int id)
        {
            var value = _context.UserComments.Find(id);
            return Ok(value);
        }


        [HttpPost]
        public IActionResult CreateComment(UserComment comment)
        {
            _context.UserComments.Add(comment);
            _context.SaveChanges();
            return Ok("Yorum başarıyla eklendi");
        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment comment)
        {
            _context.UserComments.Update(comment);
            _context.SaveChanges();
            return Ok("Yorum başarıyla güncellendi");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var comment = _context.UserComments.Find(id);
            _context.UserComments.Remove(comment);
            _context.SaveChanges();
            return Ok("Yorum başarıyla silindi");
        }

        [HttpGet("CommentListByProductId")]
        public IActionResult CommentListByProductId(string id)
        {
            var values = _context.UserComments.Where(x => x.ProductID == id).ToList();
            return Ok(values);
        }
    }
}
