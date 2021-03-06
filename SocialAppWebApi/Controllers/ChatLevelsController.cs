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
            var data = await _chatLevelService.GetAllAsync();
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getbylevel/{level}")]
        async public Task<IActionResult> GetByChatLevel(string level)
        {
            var data = await _chatLevelService.GetByChatLevelAsync(level);
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getbyid/{id}")]
        async public Task<IActionResult> GetByChatLevelId(int id)
        {
            var data = await _chatLevelService.GetByChatLevelId(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getbymatchid/{id}")]
        public IActionResult GetChatLevelByMatchId(int id)
        {
            var data =  _chatLevelService.GetChatLevelByMatch(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }

    }
}
