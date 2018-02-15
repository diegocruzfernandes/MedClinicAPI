using System;

namespace MedServer.Domain.Dtos.PatientDtos
{
    public class CreatePatientDto
    {
        public CreatePatientDto(string name, int gender, string email, string phonenumber, string details, DateTime birthdate, bool enabled)
        {
            Name = name;
            Gender = gender;
            Email = email;
            PhoneNumber = phonenumber;
            Details = details;
            BirthDate = birthdate;
            Enabled = enabled;
        }

        public string Name { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Details { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Enabled { get; set; }
    }
}
