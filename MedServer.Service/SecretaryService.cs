using Flunt.Notifications;
using MedServer.Domain.Dtos.SecretaryDtos;
using MedServer.Domain.Dtos.UserDtos;
using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Domain.Services;
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
            var user = _service.Create(new CreateUserDto(secretary.User.Email, secretary.User.Password, secretary.User.Nickname, secretary.User.Permission, secretary.User.Enabled));

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

        public IEnumerable<Secretary> Find(string name)
        {
            return _repository.Find(name);
        }

        public IEnumerable<Secretary> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<Secretary> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public Secretary Get(int id)
        {
            return _repository.Get(id);
        }

        public Secretary Update(EditSecretaryDto secretary)
        {
            //TODO: o ID do usuário de ser o que vir pelo TOKEN
            var user = _service.Get(0);
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
