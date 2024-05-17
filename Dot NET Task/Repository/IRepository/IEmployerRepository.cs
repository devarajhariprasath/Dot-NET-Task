using Dot_NET_Task.Models;

namespace Dot_NET_Task.Repository.IRepository
{
    public interface IEmployerRepository
    {
        Task AddFormAsync(Form form);
        Task AddApplicationAsync(Application application);
        Task<Form> GetFormAsync(string id);
        Task UpdateFormAsync(Form form);
        Task<IEnumerable<Application>> GetApplicationsByFormIdAsync(string formId);
        Task<Application> GetApplicationAsync(string id); // New method
    }
}
