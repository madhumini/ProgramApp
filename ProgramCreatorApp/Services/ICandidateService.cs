using ProgramCreatorApp.DTOs;
using ProgramCreatorApp.Models;

namespace ProgramCreatorApp.Services

{
    public interface ICandidateService
    {
        Task<CandidateResponse> SubmitResponseAsync(CandidateResponseDto dto);
    }
}

