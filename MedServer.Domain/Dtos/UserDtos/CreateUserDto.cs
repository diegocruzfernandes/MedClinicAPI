namespace MedServer.Domain.Dtos.UserDtos
{
    public class CreateUserDto
    {
        public CreateUserDto(string email, string password, string nickname, int permission, bool enabled)
        {
            Email = email;
            Password = password;
            Nickname = nickname;
            Permission = permission;
            Enabled = enabled;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public int Permission { get; set; }
        public bool Enabled { get; set; }
    }
}
