using MedServer.Domain.Dtos.UserDtos;
using MedServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.DoctorDtos
{
    public class CreateDoctorDto
    {
        public CreateDoctorDto( string name, string specialty, string codeRegister, CreateUserDto user, bool enabled)
        {   
            Name = name;
            Specialty = specialty;
            CodeRegister = codeRegister;
            User = user;
            Enabled = enabled;
        }

      
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string CodeRegister { get; set; }
        public CreateUserDto User { get; set; }
        public bool Enabled { get;  set; }
    }
}
