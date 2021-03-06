﻿using MedServer.Domain.Entities;

namespace MedServer.Domain.Dtos.DoctorDtos
{ 
    public class DoctorDto
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string CodeRegister { get; set; }
        public User User { get; set; }
        public bool Enabled { get; set; }
    }
}
