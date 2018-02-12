using Flunt.Notifications;
using MedServer.Domain.Dtos.DoctorDtos;
using MedServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MedServer.Domain.Services
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> Get();
        IEnumerable<Doctor> Get(int skip, int take);
        IEnumerable<Doctor> Find(Expression<Func<Doctor, bool>> expression);
        Doctor Get(int id);
        Doctor Create(CreateDoctorDto doctor);
        Doctor Update(EditDoctorDto doctor);
        Doctor Delete(int id);
        IEnumerable<Notification> Validate();        
    }
}
