using Microsoft.Azure.Cosmos;
using ProgramCreatorApp.DTOs;
using ProgramCreatorApp.Models;

namespace ProgramCreatorApp.Services

{
    public class CandidateService : ICandidateService
    {
        private readonly Container _responseContainer;

        public CandidateService(CosmosClient cosmosClient)
        {
            _responseContainer = cosmosClient.GetContainer("ProgramCreatorApp", "Responses");
        }

        public async Task<CandidateResponse> SubmitResponseAsync(CandidateResponseDto dto)
        {
            var response = new CandidateResponse
            {
                id = Guid.NewGuid().ToString(),
                ProgramId = dto.id,
                Responses = dto.Responses.Select(r => new Response
                {
                    id = r.id,
                    AnswerText = r.AnswerText,
                    AnswerYesNo = r.AnswerYesNo,
                    AnswerNumber = r.AnswerNumber,
                    AnswerDate = r.AnswerDate,
                    AnswerMultipleChoice = r.AnswerMultipleChoice
                }).ToList()
            };

            await _responseContainer.CreateItemAsync(response);
            return response;
        }
    }
}

