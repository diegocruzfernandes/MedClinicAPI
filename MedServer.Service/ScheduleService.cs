using Flunt.Notifications;
using MedServer.Domain.Dtos.SheduleDtos;
using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Domain.Services;
using MedServer.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace MedServer.Service
{
    public class ScheduleService : Notifiable, IScheduleService
    {
        private readonly IScheduleRepository _repository;

        private readonly IDoctorRepository _repositoryDoctor;
        private readonly IPatientRepository _repositoryPatient;
        private readonly ITypeConsultRepository _repositoryTypeConsult;

        public ScheduleService(
            IScheduleRepository repository,
            IDoctorRepository repositoryDoctor,
            IPatientRepository repositoryPatient,
            ITypeConsultRepository repositoryTypeConsult
            )
        {
            _repository = repository;
            _repositoryDoctor = repositoryDoctor;
            _repositoryPatient = repositoryPatient;
            _repositoryTypeConsult = repositoryTypeConsult;
        }

        public Schedule ChangeStatus(int id, EStatus status)
        {
            var schedule = _repository.Get(id);
            if (schedule == null)
                AddNotification("Schedulle", "Não foi possivel localizar o agendamento");
            else
            {
                schedule.ChangeStatus(status);
                _repository.Save(schedule);
            }
            return schedule;
        }

        public Schedule Create(CreateScheduleDto schedule)
        {
            if (!_repository.CheckAvailability(schedule.Initial))
            {
                AddNotification("Schedule", "A data escolhida não está disponivel");
                return null;
            }
            var doctor = _repositoryDoctor.Get(schedule.DoctorId);
            var patient = _repositoryPatient.Get(schedule.PatientId);
            var typeConsult = _repositoryTypeConsult.Get(schedule.TypeConsultId);
            var scheduleTmp = new Schedule(0, doctor, patient, schedule.Initial, schedule.Finish, DateTime.Now, typeConsult, (EStatus)schedule.Status);
            if (scheduleTmp.Valid)
                _repository.Save(scheduleTmp);
            return scheduleTmp;
        }

        public Schedule Delete(int id)
        {
            var schedule = _repository.Get(id);
            if (schedule == null)
                AddNotification("Schedulle", "Não foi possivel localizar o agendamento");
            else
                _repository.Delete(schedule);
            return schedule;
        }

        public IEnumerable<ViewScheduleDto> GetAll(int skip, int take, string patientName)
        {
            IEnumerable<Schedule> schedules;
            List<ViewScheduleDto> list = new List<ViewScheduleDto>();

            if (string.IsNullOrEmpty(patientName))
                schedules = _repository.GetFull(skip, take, patientName);
            else
                schedules = _repository.Get(skip, take);

            foreach (var item in schedules)
            {
                list.Add(new ViewScheduleDto(item.Id, item.Patient.Id, item.Patient.Name, item.Doctor.Id, item.Doctor.User.Nickname, item.TypeConsult.Id, item.TypeConsult.Name, (int)item.Status, Enum.GetName(typeof(EStatus), item.Status), item.Initial, item.Finish));
            }
            return list;
        }

        public Schedule Get(int id)
        {
            return _repository.Get(id);
        }

        public Schedule Update(EditScheduleDto schedule)
        {
            var scheduleTmp = _repository.Get(schedule.Id);
            if (scheduleTmp == null)
            {
                AddNotification("Schedule", "Não foi encontrado o agendamento");
                return null;
            }
            if (!_repository.CheckAvailability(schedule.Initial))
            {
                AddNotification("Schedule", "A data escolhida não está disponivel");
                return null;
            }
            scheduleTmp.ChangeHours(schedule.Initial, schedule.Finish);
            scheduleTmp.ChangeStatus((EStatus)schedule.Status);
            if (scheduleTmp.Valid)
                _repository.Update(scheduleTmp);
            return scheduleTmp;
        }

        public IEnumerable<Notification> Validate()
        {
            return Notifications;
        }
    }
}
