using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.UserDtos
{
    public class EditUserDto
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public bool Enabled { get; private set; }
    }
}
