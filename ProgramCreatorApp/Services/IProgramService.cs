using ProgramCreatorApp.DTOs;
using ProgramCreatorApp.Models;

namespace ProgramCreatorApp.Services
{
    public interface IProgramService
    {
        Task<ProgramApplication> CreateProgramAsync(CreateProgramApplicationDto dto);
        Task<Question> UpdateQuestionAsync(string programId, string questionId, UpdateQuestionDto dto);
        Task<ProgramApplication> GetProgramAsync(string programId);
        Task<List<Question>> GetQuestionsAsync(string programId);
    }
}


