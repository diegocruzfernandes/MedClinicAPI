using System;

namespace MedServer.Domain.Dtos.SheduleDtos
{
    public class EditScheduleDto
    {
        public EditScheduleDto(int id, DateTime initial, DateTime finish, int status)
        {
            Id = id;
            Initial = initial;
            Finish = finish;
            Status = status;
        }

        public int Id { get; set; }
        public DateTime Initial { get; set; }
        public DateTime Finish { get; set; } 
        public int Status { get; set; }
    }
}
