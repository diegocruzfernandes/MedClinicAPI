using Flunt.Notifications;
using MedServer.Domain.Dtos.User;
using MedServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> Get();
        IEnumerable<UserDto> Get(int skip, int take);
        UserDto Get(int id);
        User GetByEmail(string email);
        UserDto Create(CreateUserDto user);
        UserDto Update(EditUserDto user);
        UserDto Delete(int id);
        User ResetPassword(int id);
        IEnumerable<Notification> Validate();
    }
}
