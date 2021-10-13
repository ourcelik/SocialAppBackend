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

        [HttpDelete("DeletePost")]
        public async Task<IActionResult> DeletePost(DeletePostDto deletePostDto)
        {
            var result = await _postService.DeletePost(deletePostDto);

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

        [HttpGet("GetPostByPostId/{id}")]
        public async Task<IActionResult>  GetPostByPostId(int id)
        {
            var result = await _postService.GetPostByPostId(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("PostCanBeDeletedByThisUser")]
        public async Task<IActionResult> PostCanBeDeletedByThisUser(PostBelongsToDto postBelongsToDto)
        {
            var result = await _postService.PostCanBeDeletedByThisUser(postBelongsToDto);

            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}
