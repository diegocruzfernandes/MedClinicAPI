using Flunt.Notifications;
using MedServer.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Entities
{
    public class Patient : Notifiable
    {
        protected Patient() { }

        public Patient(int id, string name, EGender gender, int age, bool enabled)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Age = age;
            Enabled = enabled;
            Validate();

            Records = new List<PatientRecords>();
            Schedules = new List<Schedule>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public EGender Gender { get; private set; }
        public int Age { get; private set; }
        public bool Enabled { get; private set; }

        public List<PatientRecords> Records { get; private set; }
        public List<Schedule> Schedules { get; private set; }

        public void Update(string name, EGender gender, int age)
        {
            Name = name;
            Gender = gender;
            Age = age;
            Validate();
        }

        public void Activate() => Enabled = true;

        public void Deactivate() => Enabled = false;

        public void Validate() => AddNotifications(
           new Flunt.Validations.Contract()
             .HasMinLen(Name, 3, "Name", "O Nome não pode ter menos que 3 caracteres")
             .HasMaxLen(Name, 60, "Name", "O Nome não pode ter mais que 60 caracteres")
             .IsGreaterThan(Age, 1,"Age", "O paciente não pode ter idade inferior há 1 ano") 
            );
    }
}
