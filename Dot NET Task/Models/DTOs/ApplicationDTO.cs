namespace Dot_NET_Task.Models.DTOs
{
    public class ApplicationDTO
    {
        public string FormId { get; set; }
        public string ApplicantId { get; set; }
        public PersonalInforDTO PersonalInfo { get; set; }
        public Dictionary<string, string> Responses { get; set; } = new Dictionary<string, string>();
        public FormDTO Form { get; set; } // Add Form DTO here
    }
}
