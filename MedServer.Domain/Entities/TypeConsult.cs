using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Entities
{
    public class TypeConsult : Notifiable
    {
        protected TypeConsult() { }

        public TypeConsult(int id, string name, string description, bool enabled)
        {
            Id = id;
            Name = name;
            Description = description;
            Enabled = enabled;
            Schedules = new HashSet<Schedule>();
            Validate();
        }

        public int Id{ get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Enabled { get; private set; }

        public ICollection<Schedule> Schedules { get; private set; }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
            Validate();
        }

        public void Activate() => Enabled = true;

        public void Deactivate() => Enabled = false;

        public void Validate() => AddNotifications(
            new Contract()
               .HasMinLen(Name, 3, "Name", "O Name não pode ter menos que 3 caracteres")
               .HasMaxLen(Name, 60, "Name", "O Name não pode ter mais que 60 caracteres")
               .HasMaxLen(Description, 255, "Description", "A Descrition deve ter no máximo 255 caracteres")
           );
    }
}
