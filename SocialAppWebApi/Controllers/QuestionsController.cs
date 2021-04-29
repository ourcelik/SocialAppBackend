using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("getAll")]
        async public Task<IActionResult> GetAll()
        {
            var result = await _questionService.GetAllQuestions();
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getbyquestionid/{id}")]
        async public Task<IActionResult> GetByQuestionId(int id)
        {
            var result = await _questionService.GetQuestionByQuestionId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
