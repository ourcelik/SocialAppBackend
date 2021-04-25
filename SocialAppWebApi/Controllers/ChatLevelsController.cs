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
    public class ChatLevelsController : ControllerBase
    {
        IChatLevelService _chatLevelService;

        public ChatLevelsController(IChatLevelService chatLevelService)
        {
            _chatLevelService = chatLevelService;
        }

        [HttpGet("getall")]
        async public Task<IActionResult> GetAll()
        {
            var data = await _chatLevelService.GetAll();
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpGet("getbylevel/{id}")]
        async public Task<IActionResult> GetByChatLevel(string level)
        {
            var data = await _chatLevelService.GetByChatLevel(level);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpGet("getbyid/{id}")]
        async public Task<IActionResult> GetByChatLevelId(int id)
        {
            var data = await _chatLevelService.GetByChatLevelId(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpGet("getbymatchid/{id}")]
        public IActionResult GetChatLevelByMatchId(int id)
        {
            var data =  _chatLevelService.GetChatLevelByMatch(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }

    }
}
