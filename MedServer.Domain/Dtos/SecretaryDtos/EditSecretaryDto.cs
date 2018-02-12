using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Dtos.SecretaryDtos
{
    public class EditSecretaryDto
    {
        public EditSecretaryDto(int id, string name, string document, bool enabled)
        {
            Id = id;
            Name = name;
            Document = document;
            Enabled = enabled;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public bool Enabled { get; set; }
    }
}
