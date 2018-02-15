namespace MedServer.Domain.Dtos.TypeConsultDtos
{
    public class ViewTypeConsultDto
    {
        public ViewTypeConsultDto(int id, string name, string description, bool enabled)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.enabled = enabled;
        }

        public int id { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }
        public bool enabled { get; private set; }
    }
}
