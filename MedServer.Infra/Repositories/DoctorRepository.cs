using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Infra.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

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
            var doctorDelete = Get(doctor.Id);
            var user = doctorDelete.User;
            var sheduleList = _context.Schedules.Include(s => s.Doctor).AsNoTracking().Where(x => x.Doctor.Id == doctor.Id).ToList();

            _context.Remove(user);
            _context.RemoveRange(sheduleList);
            _context.Remove(doctorDelete);
        }

        public bool DoctorExists(Doctor doctor)
        {
            return _context.Doctors.Any(x => x.Name == doctor.Name);
        }

        public IEnumerable<Doctor> Find(Expression<Func<Doctor, bool>> expression)
        {    
            return _context.Doctors.Include(u => u.User).AsNoTracking().Where(expression);
        }

        public IEnumerable<Doctor> Get()
        {
            return _context.Doctors.Include(u => u.User).AsNoTracking().OrderBy(d => d.Name).ToList();
        }

        public IEnumerable<Doctor> Get(int skip, int take)
        {
            return _context.Doctors.Include(u => u.User).AsNoTracking().OrderBy(d => d.Name).Skip(skip).Take(take).ToList();
        }

        public Doctor Get(int id)
        {
            return _context.Doctors.Include(u => u.User).AsNoTracking().FirstOrDefault(x => x.Id == id);
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
