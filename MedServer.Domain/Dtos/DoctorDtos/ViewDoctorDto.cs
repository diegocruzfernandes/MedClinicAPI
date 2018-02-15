
namespace MedServer.Domain.Dtos.DoctorDtos
{
    public class ViewDoctorDto
    {
        public ViewDoctorDto(int id, string name, string specialty, string codeRegister, bool enabled, int userId, string email, string nickname, int permission)
        {
            Id = id;
            Name = name;
            Specialty = specialty;
            CodeRegister = codeRegister;
            Enabled = enabled;
            Userid = userId;
            Email = email;
            Nickname = nickname;
            Permission = permission;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string CodeRegister { get; set; }
        public bool Enabled { get; set; }
        public int Userid { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public int Permission { get; set; }        
    }
}
