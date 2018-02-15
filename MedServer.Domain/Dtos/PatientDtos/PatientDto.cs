using System;

namespace MedServer.Domain.Dtos.PatientDtos
{
    public class PatientDto
    {
        public PatientDto(string name, int gender, DateTime birthDate, bool enabled)
        {
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Enabled = enabled;
        }

        public string Name { get; set; }
        public int Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Enabled { get; set; }
    }
}
