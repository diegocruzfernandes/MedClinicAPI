using Flunt.Notifications;
using MedServer.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Entities
{
    public class Schedule : Notifiable
    {
        protected Schedule() { }

        public Schedule(int id, Doctor doctor, Patient patient, DateTime initial, DateTime end, EStatus status)
        {
            Id = id;
            Doctor = doctor;
            Patient = patient;
            Initial = initial;
            End = end;
            Status = status;
        }

        public int Id { get; private set; }
        public Doctor Doctor { get; private set; }
        public Patient Patient { get; private set; }
        public DateTime Initial { get; private set; }
        public DateTime End { get; private set; }
        public EStatus Status { get; private set; }
    }
}
