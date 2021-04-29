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
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getallbylevelid/{id}")]
        async public Task<IActionResult> GetByChatLevel(int id)
        {
            var data = await _constantRoomService.GetByChatLevel(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getbyconstantroomid/{id}")]
        async public Task<IActionResult> GetByConstantRoomId(int id)
        {
            var data = await _constantRoomService.GetByConstantRoomId(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }
    }
}
