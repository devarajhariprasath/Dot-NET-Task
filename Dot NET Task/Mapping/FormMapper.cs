using Dot_NET_Task.Models.DTOs;
using Dot_NET_Task.Models;

namespace Dot_NET_Task.Mapping
{
    public static class FormMapper
    {
        public static Form ToModel(this FormDTO dto)
        {
            return new Form
            {
                Id = Guid.NewGuid().ToString(),
                EmployerId = dto.EmployerId,
                Title = dto.Title,
                Questions = dto.Questions.Select(q => new Question
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = q.Text,
                    Type = q.Type,
                    Options = q.Options
                }).ToList()
            };
        }

        public static FormDTO ToDTO(this Form form)
        {
            return new FormDTO
            {
                EmployerId = form.EmployerId,
                Title = form.Title,
                Questions = form.Questions.Select(q => new QuestionDTO
                {
                    Text = q.Text,
                    Type = q.Type,
                    Options = q.Options
                }).ToList()
            };
        }
    }
}
