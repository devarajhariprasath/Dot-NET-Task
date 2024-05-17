using Dot_NET_Task.Mapping;
using Dot_NET_Task.Models.DTOs;
using Dot_NET_Task.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dot_NET_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IEmployerRepository _employerRepository;
        public ApplicationController(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitApplication([FromBody] ApplicationDTO applicationDto)
        {
            var application = applicationDto.ToModel();
            await _employerRepository.AddApplicationAsync(application);
            return Ok("Application submitted successfully.");
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
