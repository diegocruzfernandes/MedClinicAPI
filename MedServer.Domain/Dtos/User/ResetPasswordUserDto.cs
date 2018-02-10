using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.User
{
    public class ResetPasswordUserDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
