using Flunt.Notifications;
using MedServer.Domain.Dtos.PatientDtos;
using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Domain.Services;
using MedServer.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Service
{
    public class PatientService : Notifiable, IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public Patient Create(CreatePatientDto patient)
        {
            var patientTmp = new Patient(0, patient.Name, (EGender)patient.Gender, patient.Email,patient.PhoneNumber, patient.Details, patient.BirthDate, patient.Enabled);

            if (_repository.PatientExists(patientTmp))
                patientTmp.AddNotification("Patient", "O usuário já existe");

            if (patientTmp.Valid)
                _repository.Save(patientTmp);

            return patientTmp;
        }
        
        public IEnumerable<Patient> Find(string name)
        {
            return _repository.Find(name);
        }

        public IEnumerable<Patient> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<Patient> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public Patient Get(int id)
        {
            return _repository.Get(id);
        }

        public Patient Update(EditPatientDto patient)
        {
            var patientTmp = new Patient(patient.Id, patient.Name, (EGender)patient.Gender, patient.Email, patient.PhoneNumber, patient.Details, patient.BirthDate, patient.Enabled);

            if (patientTmp.Valid)
                _repository.Update(patientTmp);

            return patientTmp;
        }

        public IEnumerable<Notification> Validate()
        {
            return Notifications;
        }

        Patient IPatientService.Delete(int id)
        {
            var patient = _repository.Get(id);

            if (patient == null)
                AddNotification("Patient", "Não foi encontrado o Paciente solicitado");
            else
                _repository.Delete(patient);

            return patient;
        }       
    }
}
