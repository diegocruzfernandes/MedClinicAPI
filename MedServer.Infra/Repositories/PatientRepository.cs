using Microsoft.EntityFrameworkCore;
using MedServer.Domain.Dtos.Patient;
using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Infra.Context;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Infra.Repositories
{
    public class PatientRepository : IPatientRepository
    {

        private readonly DataContext _context;

        public PatientRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Deleted;
        }

        public IEnumerable<Patient> Find(string name)
        {
            return _context.Patients.Include(x => x.Records).AsNoTracking().Where(x => x.Name == name);
        }

        public IEnumerable<Patient> Get()
        {
            return _context.Patients
                    .OrderBy(u => u.Name)
                    .ToList();
        }

        public IEnumerable<Patient> Get(int skip, int take)
        {
            return _context.Patients
                    .OrderBy(u => u.Name)
                    .Skip(skip)
                    .Take(take)
                    .ToList();
        }

        public Patient Get(int id)
        {
            return _context.Patients.Include(r => r.Records).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public bool PatientExists(Patient patient)
        {
            return _context.Patients.Any(x => x.Name == patient.Name);
        }

        public void Save(Patient patient)
        {
            _context.Patients.Add(patient);
        }

        public void Update(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
        }
    }
}
