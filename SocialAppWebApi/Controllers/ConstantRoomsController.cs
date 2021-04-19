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
    public class ConstantRoomsController : ControllerBase
    {
        IConstantRoomService _constantRoomService;

        public ConstantRoomsController(IConstantRoomService constantRoomService)
        {
            _constantRoomService = constantRoomService;
        }

        [HttpGet("getall")]
        async public Task<IActionResult> GetAll()
        {
            var data = await _constantRoomService.GetAllConstantRoom();
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpGet("getallbylevelid")]
        async public Task<IActionResult> GetByChatLevel(int id)
        {
            var data = await _constantRoomService.GetByChatLevel(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpGet("getbyconstantroomid")]
        async public Task<IActionResult> GetByConstantRoomId(int id)
        {
            var data = await _constantRoomService.GetByConstantRoomId(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
    }
}
