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
            //_context.Entry(doctor.User) = EntityState.Deleted;
            _context.Remove(doctor);
            //_context.Entry(doctor).State = EntityState.Deleted;
        }

        public bool DoctorExists(Doctor doctor)
        {
            return _context.Doctors.Any(x => x.Name == doctor.Name);
        }

        public IEnumerable<Doctor> Find(Expression<Func<Doctor, bool>> expression)
        {    
            return _context.Doctors.Where(expression);
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
            return _context.Doctors.FirstOrDefault(x => x.Id == id);
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
