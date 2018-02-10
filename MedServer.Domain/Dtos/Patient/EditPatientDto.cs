using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.Patient
{
    public class EditPatientDto
    {
        public EditPatientDto(int id, string name, int gender, int age, bool enabled)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Age = age;
            Enabled = enabled;
        }

        public int Id { get;  set; }
        public string Name { get;  set; }
        public int Gender { get;  set; }
        public int Age { get;  set; }
        public bool Enabled { get;  set; }
    }
}
