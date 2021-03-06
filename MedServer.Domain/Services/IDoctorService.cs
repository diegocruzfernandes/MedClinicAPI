﻿using Flunt.Notifications;
using MedServer.Domain.Dtos.DoctorDtos;
using MedServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MedServer.Domain.Services
{
    public interface IDoctorService
    {
        IEnumerable<ViewDoctorDto> Get();
        IEnumerable<ViewDoctorDto> Get(int skip, int take);
        IEnumerable<ViewDoctorDto> Find(Expression<Func<Doctor, bool>> expression);
        ViewDoctorDto Get(int id);
        Doctor Create(CreateDoctorDto doctor);
        Doctor Update(EditDoctorDto doctor);
        Doctor Delete(int id);
        IEnumerable<Notification> Validate();        
    }
}
