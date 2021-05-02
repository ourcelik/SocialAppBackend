using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SocialAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomMembersController : ControllerBase
    {
        IRoomMemberService _RoomMemberService;

        public RoomMembersController(IRoomMemberService roomMemberService)
        {
            _RoomMemberService = roomMemberService;
        }

        [HttpGet("getbyroomid/{id}")]
        public async Task<IActionResult> GetMembersByRoomId(int id)
        {
            var data = await _RoomMemberService.GetMembersByRoomIdAsync(id);

            return data.Success ? Ok(data) : BadRequest(data);
        }

        [HttpGet("getbyrankid{id}")]
        public async Task<IActionResult> GetAllByChoiceIdAsync(int id)
        {
            var data = await _RoomMemberService.GetMembersByRankAsync(id);

            return data.Success ? Ok(data) : BadRequest(data);
        }
    }

}
