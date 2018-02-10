using MedServer.Domain.Dtos.Doctor;
using MedServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Repositories
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> Get();
        IEnumerable<Doctor> Get(int skip, int take);
        IEnumerable<Doctor> Find(string name);
        Doctor Get(int id);
        void Save(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
        bool DoctorExists(Doctor doctor);
    }
}
