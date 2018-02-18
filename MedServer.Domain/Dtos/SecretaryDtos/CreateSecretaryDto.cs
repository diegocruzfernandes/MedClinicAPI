
namespace MedServer.Domain.Dtos.SecretaryDtos
{
    public class CreateSecretaryDto
    {
        public CreateSecretaryDto(string name, string document, bool enabled, int userid, string email, string nickname, string password)
        {
            Name = name;
            Document = document;
            Enabled = enabled;
            Userid = userid;
            Email = email;
            Nickname = nickname;
            Password = password;     
        }

        public string Name { get; set; }
        public string Document { get; set; }
        public bool Enabled { get; set; }
        public int Userid { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}
