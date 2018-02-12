using Flunt.Notifications;
using MedServer.Domain.Dtos.SheduleDtos;
using MedServer.Domain.Entities;
using MedServer.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MedServer.Domain.Services
{
    public interface IScheduleService
    {    
        IEnumerable<Schedule> Get(int skip, int take);
        IEnumerable<Schedule> GetByDoctor(int doctorid, int skip, int take);
        IEnumerable<Schedule> Find(Expression<Func<Schedule, bool>> expression, int skip, int take);
        Schedule Get(int id);
        Schedule Create(CreateScheduleDto schedule);
        Schedule Update(EditScheduleDto schedule);
        Schedule Delete(int id);
        Schedule ChangeStatus(int id, EStatus status);
        IEnumerable<Notification> Validate();

    }
}
