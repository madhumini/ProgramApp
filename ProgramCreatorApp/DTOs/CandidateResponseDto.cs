namespace ProgramCreatorApp.DTOs
{
    public class CandidateResponseDto
    {
        public string? id { get; set; }
        public List<ResponseDto>? Responses { get; set; }
    }

    public class ResponseDto
    {
        public string? id { get; set; }
        public string? AnswerText { get; set; } // For Paragraph and Dropdown
        public bool? AnswerYesNo { get; set; } // For YesNo
        public int? AnswerNumber { get; set; } // For Number
        public DateTime? AnswerDate { get; set; } // For Date
        public List<string>? AnswerMultipleChoice { get; set; } // For MultipleChoice
    }
}

