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
    public class ProfileQuestionsController : ControllerBase
    {
        IProfileQuestionService _profileQuestionService;

        public ProfileQuestionsController(IProfileQuestionService profileQuestionService)
        {
            _profileQuestionService = profileQuestionService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _profileQuestionService.GetAllAsync();

            return data.Success ? Ok(data) : BadRequest(data);
        }

        [HttpGet("getbychoiceid/{id}")]
        public async Task<IActionResult> GetAllByChoiceIdAsync(int id)
        {
            var data = await _profileQuestionService.GetAllByChoiceIdAsync(id);

            return data.Success ? Ok(data) : BadRequest(data);
        }

        [HttpGet("getbyprofileid/{id}")]
        public async Task<IActionResult> GetAllByProfileIdAsync(int id)
        {
            var data = await _profileQuestionService.GetAllByProfileIdAsync(id);

            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpGet("getbyquestionid/{id}")]
        public async Task<IActionResult> GetAllByQuestionIdAsync(int id)
        {
            var data = await _profileQuestionService.GetAllByQuestionIdAsync(id);

            return data.Success ? Ok(data) : BadRequest(data);
        }
    }

}
