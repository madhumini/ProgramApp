using Microsoft.AspNetCore.Mvc.TagHelpers;
using ProgramCreatorApp.Models;

namespace ProgramCreatorApp.DTOs
{
    public class UpdateQuestionDto
    {
        int id { get; set; }
        public string? Text { get; set; }
        public QuestionType Type { get; set; }
        public string[]? Options { get; set; } // Used for Dropdown and MultipleChoice
    }
}

