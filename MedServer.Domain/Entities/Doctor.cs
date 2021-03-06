﻿using Flunt.Notifications;
using Flunt.Validations;
using System.Collections.Generic;

namespace MedServer.Domain.Entities
{
    public class Doctor : Notifiable
    {
        #region ctor
        protected Doctor() { }

        public Doctor(int id, string name, string specialty, string codeRegister,User user ,bool enabled)
        {
            Id = id;
            Name = name;
            Specialty = specialty;
            CodeRegister = codeRegister;
            Enabled = enabled;
            User = user;          
            Schedules = new List<Schedule>();

            Validate();
        }
        #endregion

        #region prop
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Specialty { get; private set; }
        public string CodeRegister { get; private set; }
        public bool Enabled { get; private set; }
        public User User { get; private set; }

        public virtual ICollection<Schedule> Schedules { get; private set; }
        #endregion

        #region methods
        public void Update(string name, string speciality, string codeRegister)
        {
            Name = name;
            Specialty = speciality;
            CodeRegister = codeRegister;
        }

        public void Activate() => Enabled = true;

        public void Deactivate() => Enabled = false;

        public void Validate() => AddNotifications(
            new Contract()
              .HasMinLen(Name, 3, "Name", "O Nome não pode ter menos que 3 caracteres")
              .HasMaxLen(Name, 60, "Name", "O Nome não pode ter mais que 60 caracteres")
              .IsNotNull(Specialty, "Specialty", "A especialidade não pode ser nula")
              .HasMinLen(Specialty, 3, "Specialty", "A Especialidade não pode ter menos que 3 caracteres")
              .HasMaxLen(Specialty, 60, "Specialty", "A Especialidade não pode ter mais que 60 caracteres")
              .HasMinLen(CodeRegister, 3, "CodeRegister", "O Registro não pode ter menos que 3 caracteres")
              .HasMaxLen(CodeRegister, 60, "CodeRegister", "O Registro não pode ter mais que 60 caracteres")
            );
        #endregion
    }
}
