using Flunt.Notifications;
using MedServer.Domain.Dtos.TypeConsultDtos;
using MedServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Services
{
    public interface ITypeConsultService
    {
        IEnumerable<TypeConsult> Get();
        TypeConsult Get(int id);
        TypeConsult Create(CreateTypeConsultDto type);
        TypeConsult Update(EditTypeConsultDto type);
        TypeConsult Delete(int id);
        IEnumerable<Notification> Validate();
    }
}
