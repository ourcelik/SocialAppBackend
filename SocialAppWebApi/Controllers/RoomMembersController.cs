using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SocialAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomMembersController : ControllerBase
    {
        readonly IRoomMemberService _RoomMemberService;

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

        [HttpPost("SubscribeUserToRoom")]
        public async Task<IActionResult> SubscribeUserToRoom(RoomMember roomMember)
        {
            var data = await _RoomMemberService.SubscribeUserToRoomAsync(roomMember);

            return data.Success ? Ok(data) : BadRequest(data);
        }

        [HttpPost("UnSubscribeUserToRoom")]
        public async Task<IActionResult> UnSubscribeUserToRoom(UnSubcribeRoomMemberDto unSubcribeRoomMemberDto)
        {
            var data = await _RoomMemberService.UnSubscribeUserToRoom(unSubcribeRoomMemberDto);

            return data.Success ? Ok(data) : BadRequest(data);
        }

        [HttpPost("IsSubscribed")]
        public async Task<IActionResult> IsSubscribed(IsSubscribedRoomMemberDto isSubscribedRoomMemberDto)
        {
            var data = await _RoomMemberService.IsAlreadySubscribed(isSubscribedRoomMemberDto);

            return data.Success ? Ok(data) : BadRequest(data); 

        }
    }

}
