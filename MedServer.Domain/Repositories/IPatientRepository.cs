using MedServer.Domain.Dtos.PatientDtos;
using MedServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Repositories
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> Get();
        IEnumerable<Patient> Get(int skip, int take);
        IEnumerable<Patient> Find(string name);
        Patient Get(int id);
        void Save(Patient patient);
        void Update(Patient patient);
        void Delete(Patient patient);
        bool PatientExists(Patient patient);
    }
}
