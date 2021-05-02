using Business.Abstract;
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
    public class LikesController : ControllerBase
    {
        ILikedService _likedService;

        public LikesController(ILikedService likedService)
        {
            _likedService = likedService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _likedService.GetAllAsync();
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getbykindid/{id}")]
        public async Task<IActionResult> GetAllByKindIdAsync(int id)
        {
            var data = await _likedService.GetAllByKindIdAsync(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getallbyreceiverid/{id}")]
        public async Task<IActionResult> GetAllByReceiverIdAsync(int id)
        {
            var data = await _likedService.GetAllByReceiverIdAsync(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getallbysenderid/{id}")]
        public async Task<IActionResult> GetAllBySenderIdAsync(int id)
        {
            var data = await _likedService.GetAllBySenderIdAsync(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _likedService.GetByIdAsync(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }
    }
}
