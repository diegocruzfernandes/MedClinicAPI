using Flunt.Notifications;
using MedServer.Domain.Dtos.UserDtos;
using MedServer.Domain.Entities;
using System.Collections.Generic;

namespace MedServer.Domain.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> Get();
        IEnumerable<UserDto> Get(int skip, int take);
        User Get(int id);
        User GetByEmail(string email);
        User Create(CreateUserDto user);
        UserDto Update(EditUserDto user);
        UserDto Delete(int id);
        ResetPasswordUserDto ResetPassword(int id);
        IEnumerable<Notification> Validate();
        bool IsValid();     
    }
}
