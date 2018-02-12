using MedServer.Domain.Dtos.UserDtos;
using MedServer.Domain.Entities;
using System.Collections.Generic;

namespace MedServer.Domain.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserDto> Get();
        IEnumerable<UserDto> Get(int skip, int take);
        User Get(int id);
        User GetByEmail(string email);
        void Save(User user);
        void Update(User user);
        void Delete(User user);
        bool UserExists(User user);
    }
}
