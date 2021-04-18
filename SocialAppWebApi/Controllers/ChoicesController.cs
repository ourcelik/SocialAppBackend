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
    public class ChoicesController : ControllerBase
    {
        IChoiceService _choiceService;

        public ChoicesController(IChoiceService choiceService)
        {
            _choiceService = choiceService;
        }

        [HttpGet("getall")]
        async public Task<IActionResult> GetAll()
        {
            var data = await _choiceService.GetAll();
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpGet("getallbyquestionid")]
        async public Task<IActionResult> GetAllByQuestionId(int id)
        {
            var data = await _choiceService.GetAllByQuestionId(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpGet("getallbychoiceid")]
        async public Task<IActionResult> GetByChoiceId(int id)
        {
            var data = await _choiceService.GetByChoiceId(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }

    }
}
