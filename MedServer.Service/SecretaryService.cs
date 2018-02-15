using Flunt.Notifications;
using MedServer.Domain.Dtos.SecretaryDtos;
using MedServer.Domain.Dtos.UserDtos;
using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Domain.Services;
using MedServer.Domain.ValueObjects;
using System.Collections.Generic;

namespace MedServer.Service
{
    public class SecretaryService : Notifiable, ISecretaryService
    {
        private readonly ISecretaryRepository _repository;
        private readonly IUserService _service;

        public SecretaryService(ISecretaryRepository repository, IUserService service)
        {
            _repository = repository;
            _service = service;
        }

        public Secretary Create(CreateSecretaryDto secretary)
        {
            var passwordTMP = secretary.Email.Substring(0, 3).ToLower();
            var user = _service.Create(new CreateUserDto(secretary.Email, passwordTMP, secretary.Nickname, secretary.Permission, secretary.Enabled));
            var secretaryTemp = new Secretary(0, secretary.Name, secretary.Document, secretary.Enabled, user);

            if (_repository.SecretaryExists(secretaryTemp))
                AddNotification("Secretary", "O secretário/a já existe!");
            if (secretaryTemp.Valid)
                _repository.Save(secretaryTemp);
            AddNotifications(user.Notifications);
            return secretaryTemp;
        }

        public Secretary Delete(int id)
        {
            var secretary = _repository.Get(id);
            if (secretary == null)
                AddNotification("Secretary", "O secretário/a não foi encontrado");
            else
                _repository.Delete(secretary);

            return secretary;
        }

        public IEnumerable<ViewSecretaryDto> Find(string name)
        {
            List<ViewSecretaryDto> viewSecretary = new List<ViewSecretaryDto>();
            var secretaries = _repository.Find(name);
            foreach (var secretary in secretaries)
            {
                viewSecretary.Add(new ViewSecretaryDto(secretary.Id, secretary.Name, secretary.Document, secretary.Enabled, secretary.User.Id, secretary.User.Email, secretary.User.Nickname, (int)secretary.User.Permission));
            }
            return viewSecretary;
        }

        public IEnumerable<ViewSecretaryDto> Get()
        {
            List<ViewSecretaryDto> viewSecretary = new List<ViewSecretaryDto>();
            var secretaries = _repository.Get();
            foreach (var secretary in secretaries)
            {
                viewSecretary.Add(new ViewSecretaryDto(secretary.Id, secretary.Name, secretary.Document, secretary.Enabled, secretary.User.Id, secretary.User.Email, secretary.User.Nickname, (int)secretary.User.Permission));
            }
            return viewSecretary;
        }

        public IEnumerable<ViewSecretaryDto> Get(int skip, int take)
        {        
            List<ViewSecretaryDto> viewSecretary = new List<ViewSecretaryDto>();
            var secretaries = _repository.Get(skip, take);
            foreach (var secretary in secretaries)
            {
                viewSecretary.Add(new ViewSecretaryDto(secretary.Id, secretary.Name, secretary.Document, secretary.Enabled, secretary.User.Id, secretary.User.Email, secretary.User.Nickname, (int)secretary.User.Permission));
            }
            return viewSecretary;
        }

        public ViewSecretaryDto Get(int id)
        {
            var secretary = _repository.Get(id);
            return new ViewSecretaryDto(secretary.Id, secretary.Name, secretary.Document, secretary.Enabled, secretary.User.Id, secretary.User.Email, secretary.User.Nickname, (int)secretary.User.Permission);
        }

        public Secretary Update(EditSecretaryDto secretary)
        {
            var user = _service.Get(secretary.UserId);
            user.ChangeNickname(secretary.Nickname);
            user.ChangePermission((EPermission)secretary.Permission);
            var secretaryTemp = new Secretary(secretary.Id, secretary.Name, secretary.Document, secretary.Enabled, user);
            if (secretaryTemp.Valid)
                _repository.Update(secretaryTemp);
            return secretaryTemp;
        }

        public IEnumerable<Notification> Validate()
        {
            return Notifications;
        }
    }
}
