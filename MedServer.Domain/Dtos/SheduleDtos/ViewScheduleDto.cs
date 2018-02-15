using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.SheduleDtos
{
    public class ViewScheduleDto
    {
        public ViewScheduleDto(int id, int patientid, string patient, int doctorid, string doctor, int typeConsultid, string typeconsult, int statusid, string status, DateTime initial, DateTime finish)
        {
            this.id = id;
            this.patientid = patientid;
            this.patient = patient;
            this.doctorid = doctorid;
            this.doctor = doctor;
            this.typeConsultid = typeConsultid;
            this.typeconsult = typeconsult;
            this.statusid = statusid;
            this.status = status;
            this.initial = initial;
            this.finish = finish;
        }

        public int id { get; set; }
        public int patientid { get; set; }
        public string patient { get; set; }
        public int doctorid { get; set; }
        public string doctor { get; set; }      
        public int typeConsultid { get; set; }
        public string typeconsult { get; set; }
        public int statusid { get; set; }
        public string status { get; set; }
        public DateTime initial { get; set; }
        public DateTime finish { get; set; }
    }
}
