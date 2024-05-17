namespace Dot_NET_Task.Models
{
    public class Form
    {
        public string Id { get; set; }
        public string EmployerId { get; set; }
        public string Title { get; set; }

        public int Description { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
