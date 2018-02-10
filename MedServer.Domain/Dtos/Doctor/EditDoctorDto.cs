using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.Doctor
{
    public class EditDoctorDto
    {
        public EditDoctorDto(string name, string specialty, string codeRegister, bool enabled)
        {
            Name = name;
            Specialty = specialty;
            CodeRegister = codeRegister;
            Enabled = enabled;
        }

        public string Name { get; set; }
        public string Specialty { get; set; }
        public string CodeRegister { get;  set; }
        public bool Enabled { get;  set; }
    }
}
