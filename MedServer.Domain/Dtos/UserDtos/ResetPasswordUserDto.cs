using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.UserDtos
{
    public class ResetPasswordUserDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
