using Business.Abstract;
using Entities.Concrete;
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
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getphotosbyprofileid/{id}")]
        public async Task<IActionResult> GetPhotosByProfileId(int id)
        {
            var data = await _photoService.GetPhotosByProfileId(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetPhotosByProfileId()
        {
            var data = await _photoService.GetAllPhotos();
            return data.Success ? Ok(data) : BadRequest(data);
        }

        [HttpPost("updatephoto")]
        public async Task<IActionResult> UpdatePhoto(Photo photo)
        {
            var data = await _photoService.UpdatePhotoAsync(photo);

            return data.Success ? Ok(data) : BadRequest(data);
        }
    }
}
