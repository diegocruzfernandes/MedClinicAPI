
namespace MedServer.Domain.Dtos.DoctorDtos
{
    public class CreateDoctorDto
    {
        public CreateDoctorDto(string name, string specialty, string codeRegister, bool enabled, int userid, string email, string nickname)
        {
            Name = name;
            Specialty = specialty;
            CodeRegister = codeRegister;
            Enabled = enabled;
            Userid = userid;
            Email = email;
            Password = Password;
            Nickname = nickname;            
        }

        public string Name { get; set; }
        public string Specialty { get; set; }
        public string CodeRegister { get; set; }
        public bool Enabled { get; set; }
        public int Userid { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }        
    }
}
