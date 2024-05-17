
using Dot_NET_Task.Mapping;
using Dot_NET_Task.Models;
using Dot_NET_Task.Models.DTOs;
using Dot_NET_Task.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace StartingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {

        private readonly IEmployerRepository _employerRepository;

        public FormsController(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }




        [HttpPost]
        public async Task<IActionResult> CreateForm([FromBody] FormDTO formDto)
        {
            var form = formDto.ToModel();
            await _employerRepository.AddFormAsync(form);
            return Ok(form.ToDTO());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetForm(string id)
        {
            var form = await _employerRepository.GetFormAsync(id);
            if (form == null)
            {
                return NotFound();
            }
            return Ok(form.ToDTO());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateForm(string id, [FromBody] FormDTO formDto)
        {
            var existingForm = await _employerRepository.GetFormAsync(id);
            if (existingForm == null)
            {
                return NotFound();
            }

            existingForm.Title = formDto.Title;
            existingForm.Questions = formDto.Questions.Select(q => new Question
            {
                Id = Guid.NewGuid().ToString(),
                Text = q.Text,
                Type = q.Type,
                Options = q.Options,
                DefaultValue = q.DefaultValue
            }).ToList();

            await _employerRepository.UpdateFormAsync(existingForm);
            return Ok(existingForm.ToDTO());
        }

      

        [HttpGet("questions/{formId}")]
        public async Task<IActionResult> GetQuestions(string formId)
        {
            var form = await _employerRepository.GetFormAsync(formId);
            if (form == null)
            {
                return NotFound("Form not found.");
            }

            // Extract questions from the form
            var questions = form.Questions.Select(q => new QuestionDTO
            {
                Text = q.Text,
                Type = q.Type,
                Options = q.Options
            }).ToList();

            return Ok(questions);
        }





    }
}
