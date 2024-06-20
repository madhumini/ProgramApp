using Microsoft.Azure.Cosmos;
using ProgramCreatorApp.DTOs;
using ProgramCreatorApp.Models;

namespace ProgramCreatorApp.Services
{
    public class ProgramService : IProgramService
    {
        private readonly Container _programContainer;

        public ProgramService(CosmosClient cosmosClient)
        {
            _programContainer = cosmosClient.GetContainer("ProgramCreatorApp", "ProgramApplication");
        }

        public async Task<ProgramApplication> CreateProgramAsync(CreateProgramApplicationDto dto)
        {
            var program = new ProgramApplication
            {
                id = Guid.NewGuid().ToString(),
                ProgramName = dto.ProgramName,
                Questions = dto.Questions?.Select(q => new Question
                {
                    id = Guid.NewGuid().ToString(),
                    Text = q.Text,
                    Type = (Models.QuestionType)q.Type,
                    Options = q.Options
                }).ToList()
            };

            await _programContainer.CreateItemAsync(program, new PartitionKey(program.id));
            return program;
        }

        public async Task<Question> UpdateQuestionAsync(string programId, string questionId, UpdateQuestionDto dto)
        {
            var program = await _programContainer.ReadItemAsync<Models.ProgramApplication>(programId, new PartitionKey(programId));
            var question = program.Resource.Questions.FirstOrDefault(q => q.id == questionId);

            if (question == null)
            {
                return null;
            }

            question.Text = dto.Text;
            question.Type = (Models.QuestionType)dto.Type;
            question.Options = dto.Options;

            await _programContainer.ReplaceItemAsync(program.Resource, program.Resource.id);
            return question;
        }

        public async Task<ProgramApplication> GetProgramAsync(string programId)
        {
            var response = await _programContainer.ReadItemAsync<ProgramApplication>(programId, new PartitionKey(programId));
            return response.Resource;
        }

        public async Task<List<Question>> GetQuestionsAsync(string programId)
        {
            var program = await _programContainer.ReadItemAsync<Models.ProgramApplication>(programId, new PartitionKey(programId));
            return program.Resource.Questions;
        }

        Task<ProgramApplication> IProgramService.GetProgramAsync(string programId)
        {
            throw new NotImplementedException();
        }
    }

}



