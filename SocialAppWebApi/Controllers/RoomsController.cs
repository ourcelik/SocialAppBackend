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
    public class RoomsController : ControllerBase
    {
        IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("getall")]
        async public Task<IActionResult> GetAllAsync()
        {
            var data = await _roomService.GetAllAsync();
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getroombyid/{id}")]
        async public Task<IActionResult> GetRoomByIdAsync(int id)
        {
            var data = await _roomService.GetRoomByIdAsync(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getroomsbylevelid/{id}")]
        async public Task<IActionResult> GetRoomsByLevelIdAsync(int id)
        {
            var data = await _roomService.GetRoomsByLevelIdAsync(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }
    }
}
