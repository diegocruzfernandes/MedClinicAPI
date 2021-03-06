﻿using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Entities
{
    public class PatientRecords : Notifiable
    {
        #region ctor
        protected PatientRecords() { }

        public PatientRecords(int id, Patient patient, Doctor doctor, DateTime dateOfConsultation, string memo, bool enabled)
        {
            Id = id;
            Patient = patient;
            Doctor = doctor;
            DateOfConsultation = dateOfConsultation;
            Memo = memo;
            Enabled = enabled;
        }
        #endregion

        #region prop
        public int Id { get; private set; }
        public Patient Patient { get; private set; }
        public Doctor Doctor { get; private set; }
        public DateTime DateOfConsultation { get; private set; }
        public string Memo { get; private set; }
        public bool Enabled { get; private set; }
        #endregion
    }
}
