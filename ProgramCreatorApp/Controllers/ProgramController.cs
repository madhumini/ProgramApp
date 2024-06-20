using Microsoft.AspNetCore.Mvc;
using ProgramCreatorApp.DTOs;
using ProgramCreatorApp.Services;

namespace ProgramCreatorApp.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _programService;

        public ProgramController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgram([FromBody] CreateProgramApplicationDto dto)
        {
            var program = await _programService.CreateProgramAsync(dto);
            return Ok(program);
        }

        [HttpPut("{programId}/questions/{questionId}")]
        public async Task<IActionResult> UpdateQuestion(string programId, string questionId, [FromBody] UpdateQuestionDto dto)
        {
            var question = await _programService.UpdateQuestionAsync(programId, questionId, dto);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpGet("{programId}")]
        public async Task<IActionResult> GetProgram(string programId)
        {
            var program = await _programService.GetProgramAsync(programId);
            return Ok(program);
        }

        [HttpGet("{programId}/questions")]
        public async Task<IActionResult> GetQuestions(string programId)
        {
            var questions = await _programService.GetQuestionsAsync(programId);
            return Ok(questions);
        }
    }
}

