namespace Dot_NET_Task.Models
{
    public class Question
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; } // e.g., "paragraph", "yesno", "dropdown", "date", "number"
        public List<string> Options { get; set; } = new List<string>(); // For dropdown options
        public string DefaultValue { get; set; } // For YesNo, Date, and Number types
    }
}
