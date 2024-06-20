using System.Text.Json.Serialization;

namespace ProgramCreatorApp.DTOs
{
    public class CreateProgramApplicationDto
    {
        int id { get; set; }
        public string? ProgramName { get; set; }
        public List<CreateQuestionDto>? Questions { get; set; }
    }

    public class CreateQuestionDto
    {
        int id { get; set; }
        public string? Text { get; set; }
        public QuestionType Type { get; set; }
        public string[]? Options { get; set; } // Used for Dropdown and MultipleChoice
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum QuestionType
    {
        Paragraph,
        YesNo,
        Dropdown,
        MultipleChoice,
        Date,
        Number
    }
}

