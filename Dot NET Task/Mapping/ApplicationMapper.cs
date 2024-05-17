using Dot_NET_Task.Models.DTOs;
using Dot_NET_Task.Models;

namespace Dot_NET_Task.Mapping
{
    public static class ApplicationMapper
    {
      
            public static Application ToModel(this ApplicationDTO dto)
            {
                return new Application
                {
                    Id = Guid.NewGuid().ToString(),
                    FormId = dto.FormId,
                    ApplicantId = dto.ApplicantId,
                    PersonalInfo = new PersonalInfo
                    {
                        FirstName = dto.PersonalInfo.FirstName,
                        LastName = dto.PersonalInfo.LastName,
                        Email = dto.PersonalInfo.Email,
                        Phone = dto.PersonalInfo.Phone,
                        Nationality = dto.PersonalInfo.Nationality,
                        CurrentResidence = dto.PersonalInfo.CurrentResidence,
                        IdNumber = dto.PersonalInfo.IdNumber,
                        DateOfBirth = dto.PersonalInfo.DateOfBirth,
                        Gender = dto.PersonalInfo.Gender
                    },
                    Responses = dto.Responses
                };
            }

        public static ApplicationDTO ToDTO(this Application application)
        {
            return new ApplicationDTO
            {
                FormId = application.FormId,
                ApplicantId = application.ApplicantId,
                PersonalInfo = new PersonalInforDTO
                {
                    FirstName = application.PersonalInfo.FirstName,
                    LastName = application.PersonalInfo.LastName,
                    Email = application.PersonalInfo.Email,
                    Phone = application.PersonalInfo.Phone,
                    Nationality = application.PersonalInfo.Nationality,
                    CurrentResidence = application.PersonalInfo.CurrentResidence,
                    IdNumber = application.PersonalInfo.IdNumber,
                    DateOfBirth = application.PersonalInfo.DateOfBirth,
                    Gender = application.PersonalInfo.Gender
                },
                Responses = application.Responses
            };
        }
    }
    
}
