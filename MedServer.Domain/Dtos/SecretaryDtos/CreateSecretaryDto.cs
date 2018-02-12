using MedServer.Domain.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.SecretaryDtos
{
    public class CreateSecretaryDto
    {
        public CreateSecretaryDto(string name, string document, bool enabled, CreateUserDto user)
        {
            Name = name;
            Document = document;
            Enabled = enabled;
            User = user;
        }

        public string Name { get;  set; }
        public string Document { get;  set; }
        public bool Enabled { get;  set; }
        public CreateUserDto User { get;  set; }
    }
}
