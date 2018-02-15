using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.SecretaryDtos
{
    public class ViewSecretaryDto
    {
        public ViewSecretaryDto(int id, string name, string document, bool enabled, int userid, string email, string nickname, int permission)
        {
            Id = id;
            Name = name;
            Document = document;
            Enabled = enabled;
            Userid = userid;
            Email = email;
            Nickname = nickname;
            Permission = permission;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public bool Enabled { get; set; }
        public int Userid { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public int Permission { get; set; }
    }
}
