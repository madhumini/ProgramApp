using Microsoft.AspNetCore.Mvc;
using ProgramCreatorApp.DTOs;
using ProgramCreatorApp.Services;

namespace ProgramCreatorApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitResponse([FromBody] CandidateResponseDto dto)
        {
            var response = await _candidateService.SubmitResponseAsync(dto);
            return Ok(response);
        }
    }
}

