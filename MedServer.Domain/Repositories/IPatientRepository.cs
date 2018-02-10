using MedServer.Domain.Dtos.Patient;
using MedServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Repositories
{
    public interface IPatientRepository
    {
        IEnumerable<PatientDto> Get();
        IEnumerable<Patient> Get(int skip, int take);
        IEnumerable<Patient> Find(string firstname, string lastname, bool match);
        Patient Get(int id);
        void Save(Patient employee);
        void Update(Patient employee);
        void Delete(Patient employee);
        bool PatientExists(Patient employee);
    }
}
