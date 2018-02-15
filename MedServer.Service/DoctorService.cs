using Flunt.Notifications;
using MedServer.Domain.Dtos.DoctorDtos;
using MedServer.Domain.Dtos.UserDtos;
using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Domain.Services;
using MedServer.Domain.ValueObjects;
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
            var passwordTMP = doctor.Email.Substring(0, 3).ToLower();

            var user = _service.Create(new CreateUserDto(doctor.Email, passwordTMP, doctor.Nickname, (int)doctor.Permission ,true));
           
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

        public IEnumerable<ViewDoctorDto> Find(Expression<Func<Doctor, bool>> expression)
        {
            List<ViewDoctorDto> viewDoctors = new List<ViewDoctorDto>();

            var doctors = _repository.Find(expression);

            foreach (var doctor in doctors)
            {
                viewDoctors.Add(new ViewDoctorDto(doctor.Id, doctor.Name, doctor.Specialty, doctor.CodeRegister, doctor.Enabled, doctor.User.Id, doctor.User.Email, doctor.User.Nickname, (int)doctor.User.Permission));
            }
            return viewDoctors;
        }

        public IEnumerable<ViewDoctorDto> Get()
        {
            List<ViewDoctorDto> viewDoctors = new List<ViewDoctorDto>();

            var doctors = _repository.Get();

            foreach (var doctor in doctors)
            {
                viewDoctors.Add(new ViewDoctorDto(doctor.Id, doctor.Name, doctor.Specialty, doctor.CodeRegister, doctor.Enabled, doctor.User.Id, doctor.User.Email, doctor.User.Nickname, (int)doctor.User.Permission));
            }
            return viewDoctors;
        }

        public IEnumerable<ViewDoctorDto> Get(int skip, int take)
        {
            List<ViewDoctorDto> viewDoctors = new List<ViewDoctorDto>();

            var doctors = _repository.Get();

            foreach (var doctor in doctors)
            {
                viewDoctors.Add(new ViewDoctorDto(doctor.Id, doctor.Name, doctor.Specialty, doctor.CodeRegister, doctor.Enabled, doctor.User.Id, doctor.User.Email, doctor.User.Nickname, (int)doctor.User.Permission));
            }
            return viewDoctors;
        }

        public ViewDoctorDto Get(int id)
        {
            var doctor = _repository.Get(id);
            return new ViewDoctorDto(doctor.Id, doctor.Name, doctor.Specialty, doctor.CodeRegister, doctor.Enabled, doctor.User.Id, doctor.User.Email, doctor.User.Nickname, (int)doctor.User.Permission);
        }

        public Doctor Update(EditDoctorDto doctor)
        {
            //TODO: o ID do usuário de ser o que vir pelo TOKEN
            var user = _service.Get(doctor.UserId);
            user.ChangeNickname(doctor.Nickname);
            user.ChangePermission((EPermission)doctor.Permission);
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
