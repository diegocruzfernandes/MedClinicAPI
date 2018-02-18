using Flunt.Notifications;
using MedServer.Domain.Dtos.SheduleDtos;
using MedServer.Domain.Entities;
using MedServer.Domain.ValueObjects;
using System.Collections.Generic;

namespace MedServer.Domain.Services
{
    public interface IScheduleService
    {    
        IEnumerable<ViewScheduleDto> GetAll(int skip, int take, string patientName);
        Schedule Get(int id);
        Schedule Create(CreateScheduleDto schedule);
        Schedule Update(EditScheduleDto schedule);
        Schedule Delete(int id);
        Schedule ChangeStatus(int id, EStatus status);
        IEnumerable<Notification> Validate();

    }
}
