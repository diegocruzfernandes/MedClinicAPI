using Flunt.Notifications;
using Flunt.Validations;
using MedServer.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Entities
{
    public class Schedule : Notifiable
    {
        protected Schedule() { }

        public Schedule(int id, Doctor doctor, Patient patient, DateTime initial, DateTime finish, DateTime dateReg, TypeConsult typeConsult, EStatus status)
        {
            Id = id;
            Doctor = doctor;
            Patient = patient;
            Initial = initial;
            Finish = finish;
            DateReg = dateReg;
            TypeConsult = typeConsult;
            Status = status;

            AddNotifications(new Contract());
        }

        public int Id { get; private set; }
        public DateTime Initial { get; private set; }
        public DateTime Finish { get; private set; }
        public DateTime DateReg { get; private set; }
        public EStatus Status { get; private set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual TypeConsult TypeConsult { get;  set; }

        public void ChangeHours(DateTime initial, DateTime finish)
        {
            Initial = initial;
            Finish = finish;
        }

        public void ChangeStatus(EStatus status)
        {
            Status = status;
        }

        public void ChangeTypeConsult(TypeConsult typeConsult)
        {
            TypeConsult = typeConsult;
        }


    }
}
