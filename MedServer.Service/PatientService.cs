using Flunt.Notifications;
using MedServer.Domain.Dtos.PatientDtos;
using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Domain.Services;
using MedServer.Domain.ValueObjects;
using System.Collections.Generic;

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
            var patientTmp = new Patient(0, patient.Name, (EGender)patient.Gender, patient.Email, patient.PhoneNumber, patient.Details, patient.BirthDate, patient.Enabled);
            if (_repository.PatientExists(patientTmp))
                patientTmp.AddNotification("Patient", "Paciente já existe");
            if (patientTmp.Valid)
                _repository.Save(patientTmp);
            return patientTmp;
        }

        public IEnumerable<Patient> Find(string name, int skip, int take)
        {
            return _repository.Find(name, skip, take);
        }

        public IEnumerable<Patient> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<Patient> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public ViewPatientDto Get(int id)
        {
            var patient = _repository.Get(id);
            return new ViewPatientDto(patient.Id, patient.Name, (int)patient.Gender, patient.Email, patient.PhoneNumber, patient.Details, patient.BirthDate, patient.Enabled);
        }

        public Patient Update(EditPatientDto patient)
        {
            var patientTmp = new Patient(patient.id, patient.name, (EGender)patient.gender, patient.email, patient.phonenumber, patient.details, patient.birthdate, patient.enabled);
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
