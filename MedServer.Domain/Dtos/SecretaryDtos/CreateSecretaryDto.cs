using MedServer.Domain.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.SecretaryDtos
{
    public class CreateSecretaryDto
    {
        public CreateSecretaryDto(string name, string document, bool enabled, int userid, string email, string nickname, int permission)
        {
            Name = name;
            Document = document;
            Enabled = enabled;
            Userid = userid;
            Email = email;
            Nickname = nickname;
            Permission = permission;
        }

        public string Name { get; set; }
        public string Document { get; set; }
        public bool Enabled { get; set; }
        public int Userid { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public int Permission { get; set; }
    }
}
