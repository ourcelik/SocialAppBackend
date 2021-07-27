using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        IProfileService _profileService;

        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _profileService.GetAllAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyemail/{email}")]
         public IActionResult GetByEmail(string email)
        {
            var result = _profileService.GetByEmail(email);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("updateprofile")]
        public async Task<IActionResult> UpdateProfile(UserUpdateProfileDto updateProfile)
        {
            var result = await _profileService.UpdateUserProfileAsync(updateProfile);

            return result.Success ? Ok(result) : BadRequest(result);
        }


    }
}
