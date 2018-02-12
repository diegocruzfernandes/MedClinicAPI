using Flunt.Notifications;
using MedServer.Domain.Dtos.UserDtos;
using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Domain.Services;
using MedServer.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Service
{
    public class UserService : Notifiable, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IEmailService _emailService;

        public UserService(IUserRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public IEnumerable<UserDto> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<UserDto> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public User Get(int id)
        {
            return _repository.Get(id);         
        }

        public User GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        public User Create(CreateUserDto user)
        {
            var userNew = new User(0, user.Email, user.Password, user.Nickname, (EPermission)user.Permission, user.Enabled);

            if (_repository.UserExists(userNew))
            {
                AddNotification("User", "Usuário já cadastrado!");
                return null;
            }

            if (userNew.Valid)
                _repository.Save(userNew);

            //var usercmd = ConvertUserToUserDtoAndAddNotifications(userNew);
            return userNew;
        }

        public UserDto Update(EditUserDto user)
        {
            var userTmp = _repository.Get(user.Id);
            userTmp.ChangeNickname(user.Nickname);

            if (userTmp.Enabled) userTmp.Activate(); else userTmp.Deactivate();

            if (userTmp.Valid)
                _repository.Update(userTmp);

            var usercmd = ConvertUserToUserDtoAndAddNotifications(userTmp);
            return usercmd;
        }

        public UserDto Delete(int id)
        {
            var user = _repository.Get(id);

            if (user == null)
                AddNotification("User", "Não foi encontrado o usúario solicitado");
            else
                _repository.Delete(user);

            var usercmd = ConvertUserToUserDtoAndAddNotifications(user);
            return usercmd;
        }

        public ResetPasswordUserDto ResetPassword(int id)
        {
            var user = _repository.Get(id);

            if (user == null)
            {
                AddNotification("User", "Usário não encontrado");
                return null;
            }

            var newPassword = user.ResetPassword();
            _repository.Update(user);
            _emailService.Send(
                user.Nickname,
                user.Email,
                 string.Format("Mazzatech - Med Clinic - Important", user.Nickname),
                 string.Format($"Sua nova senha é: {newPassword}.", newPassword)
                );

            var userNewPass = new ResetPasswordUserDto() { Name = user.Nickname, Password = newPassword };
            return userNewPass;
        }

        public IEnumerable<Notification> Validate()
        {
            return Notifications;
        }

        public bool IsValid()
        {
            if (Notifications.Count > 0)
                return false;
            else
                return true;
        }

        private UserDto ConvertUserToUserDtoAndAddNotifications(User user)
        {
            var userdto = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Nickname = user.Nickname,
                Permission = (int)user.Permission,
                Enabled = user.Enabled
            };
            AddNotifications(user.Notifications);
            return userdto;
        }  
    }
}
