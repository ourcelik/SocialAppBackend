using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SocialAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstantRoomMembersController : ControllerBase
    {
        IConstantRoomMemberService _constantRoomMemberService;

        public ConstantRoomMembersController(IConstantRoomMemberService constantRoomMemberService)
        {
            _constantRoomMemberService = constantRoomMemberService;
        }

        [HttpGet("getbyroomid/{id}")]
        public async Task<IActionResult> GetMembersByRoomId(int id)
        {
            var data = await _constantRoomMemberService.GetMembersByRoomId(id);

            return data.Success ? Ok(data) : BadRequest(data);
        }

        [HttpGet("getbyrankid{id}")]
        public async Task<IActionResult> GetAllByChoiceIdAsync(int id)
        {
            var data = await _constantRoomMemberService.GetMembersByRank(id);

            return data.Success ? Ok(data) : BadRequest(data);
        }
    }

}
