using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.Patient
{
    public class CreatePatientDto
    {
        public CreatePatientDto(string name, int gender, int age, bool enabled)
        {
            Name = name;
            Gender = gender;
            Age = age;
            Enabled = enabled;
        }

        public string Name { get;  set; }
        public int Gender { get;  set; }
        public int Age { get;  set; }
        public bool Enabled { get;  set; }
    }
}
