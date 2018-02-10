using Flunt.Notifications;
using MedServer.Domain.Dtos.Doctor;
using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Domain.Services;
using MedServer.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Service
{
    public class DoctorService : Notifiable, IDoctorService
    {
        private readonly IDoctorRepository _repository;

        public DoctorService(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public Doctor Create(CreateDoctorDto doctor)
        {
            var doctorTmp = new Doctor(0, doctor.Name, doctor.Specialty, doctor.CodeRegister, doctor.Enabled);

            if (_repository.DoctorExists(doctorTmp))
                doctorTmp.AddNotification("Doctor", "O Doutor já existe!");

            if (doctorTmp.Valid)
                _repository.Save(doctorTmp);

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

        public IEnumerable<Doctor> Find(string name)
        {
            return _repository.Find(name);
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
            var doctorTmp = new Doctor(doctor.Id, doctor.Name, doctor.Specialty, doctor.CodeRegister, doctor.Enabled);
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
