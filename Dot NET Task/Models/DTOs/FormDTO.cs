namespace Dot_NET_Task.Models.DTOs
{
    public class FormDTO
    {
        public string EmployerId { get; set; }
        public string Title { get; set; }
        public List<QuestionDTO> Questions { get; set; } = new List<QuestionDTO>();
    }
}
