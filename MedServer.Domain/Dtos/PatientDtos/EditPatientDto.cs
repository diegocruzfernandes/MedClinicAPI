using System;

namespace MedServer.Domain.Dtos.PatientDtos
{
    public class EditPatientDto
    {
        public EditPatientDto(int id, string name, int gender, string email, string phonenumber, string details, DateTime birthdate, bool enabled)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.email = email;
            this.phonenumber = phonenumber;
            this.details = details;
            this.birthdate = birthdate;
            this.enabled = enabled;
        }

        public int id { get;  set; }
        public string name { get; set; }
        public int gender { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
        public string details { get; set; }
        public DateTime birthdate { get; set; }
        public bool enabled { get; set; }
    }
}
