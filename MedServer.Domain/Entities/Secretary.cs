using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Entities
{
    public class Secretary : Notifiable
    {
        protected Secretary() { }

        public Secretary(int id, string name, string document, bool enabled, User user)
        {
            Id = id;
            Name = name;
            Document = document;
            Enabled = enabled;
            User = user;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public bool Enabled { get; private set; }
        public User User { get; private set; }

        public void Update(string name, string document)
        {
            Name = name;
            Document = document;
            Validate();
        }

        public void Activate() => Enabled = true;

        public void Deactivate() => Enabled = false;

        public void Validate() => AddNotifications(
           new Contract()
             .HasMinLen(Name, 3, "Name", "O Nome não pode ter menos que 3 caracteres")
             .HasMaxLen(Name, 60, "Name", "O Nome não pode ter mais que 60 caracteres")
             .HasMaxLen(Document, 255, "Document", "O Documento não pode ter mais de  255 caracteres1")
            );
    }
}
