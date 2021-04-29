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
    public class MatchesController : ControllerBase
    {
        IMatchService _matchService;

        public MatchesController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _matchService.GetAllMatchesAsync();
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getmatchbyid/{id}")]
        public async Task<IActionResult> GetMatchByIdAsync(int id)
        {
            var data = await _matchService.GetMatchByIdAsync(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getmatchbylevel/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var data = await _matchService.GetMatchesByLevelIdAsync(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }

        [HttpGet("getmatchbyuserid/{id}")]
        public async Task<IActionResult> GetMatchesByUserIdAsync(int id)
        {
            var data = await _matchService.GetMatchesByUserIdAsync(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }

    }
}
