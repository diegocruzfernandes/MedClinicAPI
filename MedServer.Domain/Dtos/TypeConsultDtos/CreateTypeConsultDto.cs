namespace MedServer.Domain.Dtos.TypeConsultDtos
{
    public class CreateTypeConsultDto
    {
        public CreateTypeConsultDto(string name, string description, bool enabled)
        {
            Name = name;
            Description = description;
            Enabled = enabled;
        }

        public string Name { get;  set; }
        public string Description { get;  set; }
        public bool Enabled { get;  set; }
    }
}
