using Flunt.Notifications;
using MedServer.Domain.Dtos.PatientDtos;
using MedServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Services
{
    public interface IPatientService
    {
        IEnumerable<Patient> Get();
        IEnumerable<Patient> Get(int skip, int take);
        IEnumerable<Patient> Find(string name);
        Patient Get(int id);
        Patient Create(CreatePatientDto patient);
        Patient Update(EditPatientDto patient);
        Patient Delete(int id);
        IEnumerable<Notification> Validate();        
    }
}
