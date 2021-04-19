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
    public class RanksController : ControllerBase
    {
        IRankService _rankService;

        public RanksController(IRankService rankService)
        {
            _rankService = rankService;
        }

        [HttpGet("getall")]
        async public Task<IActionResult> GetAll()
        {
            var data = await _rankService.GetAll();
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }

        [HttpGet("getbyrankid")]
        async public Task<IActionResult> GetByRankId(int id)
        {
            var data = await _rankService.GetByRankId(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
    }
}
