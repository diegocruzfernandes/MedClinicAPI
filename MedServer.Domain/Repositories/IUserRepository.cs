using MedServer.Domain.Dtos.User;
using MedServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
