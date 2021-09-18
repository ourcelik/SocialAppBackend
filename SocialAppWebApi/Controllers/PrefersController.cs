using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialAppWebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PrefersController : ControllerBase
    {
        IPreferService _preferService;

        public PrefersController(IPreferService preferService)
        {
            _preferService = preferService;
        }

        [HttpGet("getbyId/{id}")]
        async public Task<IActionResult> GetById(int id)
        {
            var data = await _preferService.GetPreferSettingById(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getByUserId/{id}")]
        public IActionResult GetByUserId(int id)
        {
            var data = _preferService.GetPreferSettingsByUserId(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }

        [HttpPost("UpdatePreferSettings")]
        public async Task<IActionResult> UpdatePreferSettings(Prefer prefer)
        {
            var data = await _preferService.UpdatePreferSettingsAsync(prefer);

            return data.Success ? Ok(data) : BadRequest(data);
        }
    }
}
