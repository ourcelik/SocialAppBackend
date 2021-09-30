using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("CreateNewPost")]
        public async Task<IActionResult> CreateNewPost(Post post)
        {
            var result =  await _postService.CreatePost(post);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("DeletePost/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var result = await _postService.DeletePost(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPatch("UpdatePost")]
        public async Task<IActionResult> UpdatePost(UpdatePostDto updatePost)
        {
            var result = await _postService.UpdatePost(updatePost);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            var result = await _postService.GetAllPost();

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetPostsByRoomId/{id}")]
        public async Task<IActionResult> GetPostsByRoomId(int id)
        {
            var result = await _postService.GetPostByRoomId(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetPostsWithPostInfoByRoomId/{id}")]
        public IActionResult GetPostsWithPostInfoByRoomId(int id)
        {
            var result =  _postService.GetPostWithPostInfoByRoomId(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}
