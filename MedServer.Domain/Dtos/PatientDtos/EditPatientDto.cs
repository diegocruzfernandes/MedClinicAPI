using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.PatientDtos
{
    public class EditPatientDto
    {
        public EditPatientDto(int id, string name, int gender, string email, string phoneNumber, string details, DateTime birthDate, bool enabled)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Email = email;
            PhoneNumber = phoneNumber;
            Details = details;
            BirthDate = birthDate;
            Enabled = enabled;
        }

        public int Id { get;  set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Details { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Enabled { get; set; }
    }
}
