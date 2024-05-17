namespace Dot_NET_Task.Models.DTOs
{
    public class QuestionDTO
    {
        public string Text { get; set; }
        public string Type { get; set; }
        public List<string> Options { get; set; } = new List<string>(); // For dropdown options
        public string DefaultValue { get; set; } // For YesNo, Date, and Number types
    }
}
