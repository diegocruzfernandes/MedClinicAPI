using MedServer.Domain.Entities;
using System.Collections.Generic;

namespace MedServer.Domain.Repositories
{
    public interface ISecretaryRepository
    {
        IEnumerable<Secretary> Get();
        IEnumerable<Secretary> Get(int skip, int take);
        IEnumerable<Secretary> Find(string name);
        Secretary Get(int id);
        void Save(Secretary secretary);
        void Update(Secretary secretary);
        void Delete(Secretary secretary);
        bool SecretaryExists(Secretary secretary);       
    }
}
