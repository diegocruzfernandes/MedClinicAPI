namespace MedServer.Domain.Dtos.TypeConsultDtos
{
    public class EditTypeConsultDto
    {
        public EditTypeConsultDto(int id, string name, string description, bool enabled)
        {
            Id = id;
            Name = name;
            Description = description;
            Enabled = enabled;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Enabled { get; private set; }
    }
}
