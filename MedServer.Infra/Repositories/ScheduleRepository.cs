using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedServer.Infra.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DataContext _context;

        public ScheduleRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(Schedule schedule)
        {
            _context.Entry(schedule).State = EntityState.Deleted;
        }

        public IEnumerable<Schedule> Get(int skip, int take)
        {
            return _context.Schedules
                    .OrderBy(u => u.Initial)
                    .Include(p => p.Patient)
                    .Include(p => p.TypeConsult)
                    .Include(d => d.Doctor)
                    .Include(u => u.Doctor.User)
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToList();
        }

        public IEnumerable<Schedule> GetFull(int skip, int take, string patientName)
        {
            return _context.Schedules
                    .OrderBy(u => u.Initial)
                    .Include(p => p.TypeConsult)
                    .Include(d => d.Doctor)
                    .Include(u => u.Doctor.User)
                    .Include(p => p.Patient)
                    .Where(x => x.Patient.Name.Contains(patientName))
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToList();
        }

        public Schedule Get(int id)
        {
            return _context.Schedules.Include(r => r.Patient).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void Save(Schedule schedule)
        {
            schedule.Doctor = _context.Doctors.ToList().Where(x => x.Id == schedule.Doctor.Id).FirstOrDefault();
            schedule.Patient = _context.Patients.ToList().Where(x => x.Id == schedule.Patient.Id).FirstOrDefault();
            schedule.TypeConsult = _context.TypesConsult.ToList().Where(x => x.Id == schedule.TypeConsult.Id).FirstOrDefault();
            _context.Schedules.Add(schedule);
        }

        public void Update(Schedule schedule)
        {
             _context.Entry(schedule).State = EntityState.Modified;
        }

        public bool CheckAvailability(DateTime date)
        {
            var valid = _context.Schedules.Where(d => d.Initial >= date && d.Finish <= date).Any();
            return !valid;
        }      
    }
}
