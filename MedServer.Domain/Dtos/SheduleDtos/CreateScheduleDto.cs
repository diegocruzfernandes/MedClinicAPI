using MedServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.SheduleDtos
{
    public class CreateScheduleDto
    {
        public CreateScheduleDto(DateTime initial, DateTime finish, int doctorId, int patientId, int typeConsultId, int status)
        {
            Initial = initial;
            Finish = finish;
            DoctorId = doctorId;
            PatientId = patientId;
            TypeConsultId = typeConsultId;
            Status = status;
        }

        public DateTime Initial { get; set; }
        public DateTime Finish { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int TypeConsultId { get; set; }
        public int Status { get; set; }
    }
}
