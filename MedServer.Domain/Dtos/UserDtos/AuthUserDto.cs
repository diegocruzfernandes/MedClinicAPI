using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.UserDtos
{
    public class AuthUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
