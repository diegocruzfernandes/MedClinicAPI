using MedServer.Domain.Dtos.Doctor;
using MedServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Repositories
{
    public interface IDoctorRepository
    {
        IEnumerable<DoctorDto> Get();
        IEnumerable<Doctor> Get(int skip, int take);
        IEnumerable<Doctor> Find(string firstname, string lastname, bool match);
        Doctor Get(int id);
        void Save(Doctor employee);
        void Update(Doctor employee);
        void Delete(Doctor employee);
        bool DoctorExists(Doctor employee);
    }
}
