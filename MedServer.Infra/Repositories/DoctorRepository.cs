using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Infra.Context;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Infra.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        public readonly DataContext _context;

        public DoctorRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Deleted;
        }

        public bool DoctorExists(Doctor doctor)
        {
            return _context.Doctors.Any(x => x.Name == doctor.Name);
        }

        public IEnumerable<Doctor> Find(string name)
        {
            return _context.Doctors.Include(x => x.Schedules).AsNoTracking().Where(x => x.Name == name);
        }

        public IEnumerable<Doctor> Get()
        {
            return _context.Doctors.OrderBy(d => d.Name).ToList();
        }

        public IEnumerable<Doctor> Get(int skip, int take)
        {
            return _context.Doctors.OrderBy(d => d.Name).Skip(skip).Take(take).ToList();
        }

        public Doctor Get(int id)
        {
            return _context.Doctors.Include(s => s.Schedules).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void Save(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
        }

        public void Update(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;
        }
    }
}
