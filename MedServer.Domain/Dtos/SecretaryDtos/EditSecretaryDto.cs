
namespace MedServer.Domain.Dtos.SecretaryDtos
{
    public class EditSecretaryDto
    {
        public EditSecretaryDto(int id, string name, string document, bool enabled, int userId, string email, string nickname, int permission)
        {
            Id = id;
            Name = name;
            Document = document;
            Enabled = enabled;
            UserId = userId;
            Email = email;
            Nickname = nickname;
            Permission = permission;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public bool Enabled { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public int Permission { get; set; }
    }
}
