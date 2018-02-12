using Flunt.Notifications;
using MedServer.Domain.Dtos.DoctorDtos;
using MedServer.Domain.Dtos.UserDtos;
using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Domain.Services;
using MedServer.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MedServer.Service
{
    public class DoctorService : Notifiable, IDoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly IUserService _service;

        public DoctorService(IDoctorRepository repository, IUserService service)
        {
            _repository = repository;
            _service = service;
        }

        public Doctor Create(CreateDoctorDto doctor)
        {
            var user = _service.Create(new CreateUserDto(doctor.User.Email, doctor.User.Password, doctor.User.Nickname, (int)doctor.User.Permission ,doctor.User.Enabled));
           
            var doctorTmp = new Doctor(0, doctor.Name, doctor.Specialty, doctor.CodeRegister, user, doctor.Enabled);

            if (_repository.DoctorExists(doctorTmp))
                AddNotification("Doctor", "O Médico já existe!");

            if (doctorTmp.Valid)
                _repository.Save(doctorTmp);

            AddNotifications(user.Notifications);

            return doctorTmp;
        }

        public Doctor Delete(int id)
        {
            var doctor = _repository.Get(id);

            if (doctor == null)
                AddNotification("Doctor", "Não foi encontrado o Doutor solicitado");
            else
                _repository.Delete(doctor);

            return doctor;
        }

        public IEnumerable<Doctor> Find(Expression<Func<Doctor, bool>> expression)
        {
            return _repository.Find(expression);
        }

        public IEnumerable<Doctor> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<Doctor> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public Doctor Get(int id)
        {
            return _repository.Get(id);
        }

        public Doctor Update(EditDoctorDto doctor)
        {
            //TODO: o ID do usuário de ser o que vir pelo TOKEN
            var user = _service.Get(0);
            var doctorTmp = new Doctor(doctor.Id, doctor.Name, doctor.Specialty, doctor.CodeRegister, user, doctor.Enabled);
            if (doctorTmp.Valid)
                _repository.Update(doctorTmp);

            return doctorTmp;
        }
        
        public IEnumerable<Notification> Validate()
        {
            return Notifications;
        }
    }
}
