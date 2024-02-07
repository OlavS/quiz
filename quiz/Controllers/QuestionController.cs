using Microsoft.AspNetCore.Mvc;
using quiz.Dtos;
using quiz.Services;

namespace quiz.Controllers
{
    [ApiController]
    [Route("Question")]
    public class QuestionController : ControllerBase
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly IQuestionService _questionService;

        public QuestionController(ILogger<QuestionController> logger, IQuestionService questionService)
        {
            _logger = logger;
            _questionService = questionService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<QuestionDto>> GetAll()
        {
            return await _questionService.GetAll();
        }
    }
}