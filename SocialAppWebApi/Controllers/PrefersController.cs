using Business.Abstract;
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
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
    }
}
