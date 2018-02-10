using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.Doctor
{
    public class DoctorDto
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string CodeRegister { get; set; }
        public bool Enabled { get; set; }
    }
}
