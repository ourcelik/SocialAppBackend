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
    public class LikeKindsController : ControllerBase
    {
        ILikeKindService _likeKindService;

        public LikeKindsController(ILikeKindService likeKindService)
        {
            _likeKindService = likeKindService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllKindsAsync()
        {
            var data =await _likeKindService.GetAllKindsAsync();
            return data.Success ? Ok(data) : BadRequest(data);
        }
    }
}
