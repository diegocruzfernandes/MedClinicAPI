using MedServer.Domain.Dtos.DoctorDtos;
using MedServer.Domain.Dtos.TypeConsultDtos;

namespace MedServer.Domain.Dtos.SheduleDtos
{
    public class NewScheduleDto
    {
        public int id { get; set; }
        public int patientid { get; set; }
        public string patient { get; set; }
        public ViewDoctorDto doctor { get; set; }
        public ViewTypeConsultDto typeconsult { get; set; }
    }

    
}
