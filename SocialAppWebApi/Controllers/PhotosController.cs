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
    public class PhotosController : ControllerBase
    {
        IPhotoService _photoService;

        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpGet("getbyphotoid/{id}")]
        public async Task<IActionResult> GetByPhotoId(int id)
        {
            var data = await _photoService.GetPhotoByPhotoId(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpGet("getphotosbyprofileid/{id}")]
        public async Task<IActionResult> GetPhotosByProfileId(int id)
        {
            var data = await _photoService.GetPhotosByProfileId(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetPhotosByProfileId()
        {
            var data = await _photoService.GetAllPhotos();
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
    }
}
