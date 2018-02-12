using MedServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Repositories
{
    public interface ITypeConsultRepository
    {
        IEnumerable<TypeConsult> Get();
        TypeConsult Get(int id);
        void Save(TypeConsult type);
        void Update(TypeConsult type);
        void Delete(TypeConsult type);
        bool TypeConsultExists(TypeConsult type);
    }
}
