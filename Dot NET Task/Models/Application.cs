namespace Dot_NET_Task.Models
{
    public class Application
    {
        public string Id { get; set; }
        public string FormId { get; set; }
        public string ApplicantId { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public Dictionary<string, string> Responses { get; set; } = new Dictionary<string, string>();
    }
}
