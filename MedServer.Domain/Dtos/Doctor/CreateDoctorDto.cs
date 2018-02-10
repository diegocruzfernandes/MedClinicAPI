using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.Doctor
{
    public class CreateDoctorDto
    {
        public CreateDoctorDto(int id, string name, string specialty, string codeRegister, bool enabled)
        {
            Id = id;
            Name = name;
            Specialty = specialty;
            CodeRegister = codeRegister;
            Enabled = enabled;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string CodeRegister { get; set; }
        public bool Enabled { get;  set; }
    }
}
