using MedServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MedServer.Domain.Repositories
{
    public interface IScheduleRepository
    {
        IEnumerable<Schedule> Get(int skip, int take);
        IEnumerable<Schedule> Find(Expression<Func<Schedule, bool>> expression, int skip, int take);
        Schedule Get(int id);
        void Save(Schedule schedule);
        void Update(Schedule schedule);
        void Delete(Schedule schedule);
        bool CheckAvailability(DateTime date);
    }
}
