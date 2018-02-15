using Flunt.Notifications;
using MedServer.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace MedServer.Domain.Entities
{
    public class Patient : Notifiable
    {
        #region ctor
        protected Patient() { }

        public Patient(int id, string name, EGender gender, string email, string phoneNumber, string details, DateTime birthDate, bool enabled)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Email = email;
            PhoneNumber = phoneNumber;
            Details = details;
            BirthDate = birthDate;
            Enabled = enabled;
            Records = new HashSet<PatientRecords>();
            Schedules = new HashSet<Schedule>();

            Validate();
        }
        #endregion

        #region prop
        public int Id { get; private set; }
        public string Name { get; private set; }
        public EGender Gender { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Details { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Enabled { get; private set; }

        public ICollection<PatientRecords> Records { get; private set; }
        public ICollection<Schedule> Schedules { get; private set; }
        #endregion

        #region methods
        public void Update(string name, EGender gender, string email, string phoneNumber, string details, DateTime birthDate)
        {
            Name = name;
            Gender = gender;
            Email = email;
            PhoneNumber = phoneNumber;
            Details = details;
            BirthDate = birthDate;
            Validate();
        }

        public void Activate() => Enabled = true;

        public void Deactivate() => Enabled = false;

        public void Validate() => AddNotifications(
           new Flunt.Validations.Contract()
             .HasMinLen(Name, 3, "Name", "O Nome não pode ter menos que 3 caracteres")
             .HasMaxLen(Name, 60, "Name", "O Nome não pode ter mais que 60 caracteres")
             .IsEmail(Email, "Email", "E-mail com formato errado")
             .HasMinLen(PhoneNumber, 3, "PhoneNumber", "O telefone não pode ter menos que 3 caracteres")
             .HasMaxLen(PhoneNumber, 60, "PhoneNumber", "O telefone não pode ter mais que 60 caracteres")
             .HasMaxLen(Details, 255, "Details", "O detalhes não pode ter mais que 60 caracteres")
            );
        #endregion
    }
}
