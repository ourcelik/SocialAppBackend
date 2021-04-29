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
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getallbyquestionid/{id}")]
        async public Task<IActionResult> GetAllByQuestionId(int id)
        {
            var data = await _choiceService.GetAllByQuestionId(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getallbychoiceid/{id}")]
        async public Task<IActionResult> GetByChoiceId(int id)
        {
            var data = await _choiceService.GetByChoiceId(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }

    }
}
