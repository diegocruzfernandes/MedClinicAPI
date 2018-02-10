using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public int Permission { get; set; }
        public bool Enabled { get; set; }
    }
}
