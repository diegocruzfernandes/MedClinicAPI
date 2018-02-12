using Flunt.Notifications;
using MedServer.Domain.Dtos.SecretaryDtos;
using MedServer.Domain.Entities;
using System.Collections.Generic;

namespace MedServer.Domain.Services
{
    public interface ISecretaryService
    {
        IEnumerable<Secretary> Get();
        IEnumerable<Secretary> Get(int skip, int take);
        IEnumerable<Secretary> Find(string name);
        Secretary Get(int id);
        Secretary Create(CreateSecretaryDto secretary);
        Secretary Update(EditSecretaryDto secretary);
        Secretary Delete(int id);
        IEnumerable<Notification> Validate();
    }
}
