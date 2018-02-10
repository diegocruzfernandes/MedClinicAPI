﻿using Flunt.Notifications;
using System.Collections.Generic;

namespace MedServer.Domain.Entities
{
    public class Doctor : Notifiable
    {
        protected Doctor() { }

        public Doctor(int id, string name, string specialty, string codeRegister, bool enabled)
        {
            Id = id;
            Name = name;
            Specialty = specialty;
            CodeRegister = codeRegister;
            Enabled = enabled;

            Schedules = new List<Schedule>();

            Validate();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Specialty { get; private set; }
        public string CodeRegister { get; private set; }
        public bool Enabled { get; private set; }

        public List<Schedule> Schedules { get; set; }

        public void Update(string name, string speciality, string codeRegister)
        {
            Name = name;
            Specialty = speciality;
            CodeRegister = codeRegister;
        }

        public void Activate() => Enabled = true;

        public void Deactivate() => Enabled = false;

        public void Validate() => AddNotifications(
            new Flunt.Validations.Contract()
              .HasMinLen(Name, 3, "Name", "O Nome não pode ter menos que 3 caracteres")
              .HasMaxLen(Name, 60, "Name", "O Nome não pode ter mais que 60 caracteres")
              .HasMinLen(Specialty, 3, "Speciality", "A Especialidade não pode ter menos que 3 caracteres")
              .HasMaxLen(Specialty, 60, "Specialty", "A Especialidade não pode ter mais que 60 caracteres")
              .HasMinLen(CodeRegister, 3, "CodeRegister", "O Registro não pode ter menos que 3 caracteres")
              .HasMaxLen(CodeRegister, 60, "CodeRegister", "O Registro não pode ter mais que 60 caracteres")
            );
    }
}