using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SocialAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCommentController : ControllerBase
    {
        readonly IPostCommentService _postCommentService;

        public PostCommentController(IPostCommentService postCommentService)
        {
            _postCommentService = postCommentService;
        }

        [HttpGet("GetAllCommentsByPostId")]
        public async Task<IActionResult> GetAllCommentsByPostId(int id)
        {
            var result = await _postCommentService.GetCommentsByPostId(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllComments")]
        public async Task<IActionResult> GetAllComments()
        {
            var result = await _postCommentService.GetAllComments();

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("CreateNewComment")]
        public async Task<IActionResult> CreateNewComment(PostComment postComment)
        {
            var result = await _postCommentService.CreateComment(postComment);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("UpdateComment")]
        public async Task<IActionResult> UpdateComment(PostComment postComment)
        {
            var result = await _postCommentService.UpdateComment(postComment);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
