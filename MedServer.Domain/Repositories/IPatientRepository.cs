using MedServer.Domain.Entities;
using System.Collections.Generic;

namespace MedServer.Domain.Repositories
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> Get();
        IEnumerable<Patient> Get(int skip, int take);
        IEnumerable<Patient> Find(string name, int skip, int take);
        Patient Get(int id);
        void Save(Patient patient);
        void Update(Patient patient);
        void Delete(Patient patient);
        bool PatientExists(Patient patient);
    }
}
