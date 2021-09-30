using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SocialAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostLikeController : ControllerBase
    {
        readonly IPostLikeService _postLikeService;

        public PostLikeController(IPostLikeService postLikeService)
        {
            _postLikeService = postLikeService;
        }

        [HttpPost("SendLikeToPost")]
        public async Task<IActionResult> SendLikeToPost(PostLike postLike)
        {
            var result = await _postLikeService.SendLikeToPost(postLike);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetLikeBack")]
        public async Task<IActionResult> GetLikeBack(PostLike postLike)
        {
            var result = await _postLikeService.GetLikeBack(postLike);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllLikesByPostId")]
        public async Task<IActionResult> GetAllLikesByPostId(int id)
        {
            var result = await _postLikeService.GetAllLikesByPostId(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("IsAlreadyLikedPost")]
        public async Task<IActionResult> IsAlreadyLikedPost(IsAlreadyLikedPostDto isAlreadyLikedPost)
        {
            var result = await _postLikeService.IsAlreadyLikedPost(isAlreadyLikedPost);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
