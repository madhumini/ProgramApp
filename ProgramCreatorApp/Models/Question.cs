using System.Text.Json.Serialization;


namespace ProgramCreatorApp.Models
    
{
    public class Question
    {
        public string? id { get; set; }
        
        public string? Text { get; set; }
        
        
        public QuestionType Type { get; set; }
        public string[]? Options { get; set; } // Used for Dropdown and MultipleChoice
    }

    public class Response
    {
        public string? id { get; set; }
        public string? AnswerText { get; set; } // For Paragraph and Dropdown
        public bool? AnswerYesNo { get; set; } // For YesNo
        public int? AnswerNumber { get; set; } // For Number
        public DateTime? AnswerDate { get; set; } // For Date
        public List<string>? AnswerMultipleChoice { get; set; } // For MultipleChoice
    }

    public class ProgramApplication
    {
        public string? id { get; set; }
        public string? ProgramName { get; set; }
        public List<Question>? Questions { get; set; }
    }

    public class CandidateResponse
    {
        public String? id { get; set; }
        public string? ProgramId { get; set; }
        public List<Response>? Responses { get; set; }
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

