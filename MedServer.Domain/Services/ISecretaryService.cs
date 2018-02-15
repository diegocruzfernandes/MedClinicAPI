using Flunt.Notifications;
using MedServer.Domain.Dtos.SecretaryDtos;
using MedServer.Domain.Entities;
using System.Collections.Generic;

namespace MedServer.Domain.Services
{
    public interface ISecretaryService
    {
        IEnumerable<ViewSecretaryDto> Get();
        IEnumerable<ViewSecretaryDto> Get(int skip, int take);
        IEnumerable<ViewSecretaryDto> Find(string name);
        ViewSecretaryDto Get(int id);
        Secretary Create(CreateSecretaryDto secretary);
        Secretary Update(EditSecretaryDto secretary);
        Secretary Delete(int id);
        IEnumerable<Notification> Validate();
    }
}
