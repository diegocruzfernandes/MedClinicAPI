using Flunt.Notifications;
using MedServer.Domain.Dtos.TypeConsultDtos;
using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Domain.Services;
using System.Collections.Generic;

namespace MedServer.Service
{
    public class TypeConsultService : Notifiable, ITypeConsultService
    {
        private readonly ITypeConsultRepository _repository;

        public TypeConsultService(ITypeConsultRepository repository)
        {
            _repository = repository;
        }

        public TypeConsult Create(CreateTypeConsultDto type)
        {
            var typeConsultNew = new TypeConsult(0, type.Name, type.Description, type.Enabled);
            if(_repository.TypeConsultExists(typeConsultNew))
            {
                AddNotification("TypeConsult", "Este modo de consulta já está cadastrado");
                return null;
            }
            if (typeConsultNew.Valid)
                _repository.Save(typeConsultNew);
            return typeConsultNew;
        }

        public TypeConsult Delete(int id)
        {
            var typeConsult = _repository.Get(id);
            if (typeConsult == null)
                AddNotification("TypeConsult", "Não foi possivel encontrar o modo de consulta");
            else
                _repository.Delete(typeConsult);
            return typeConsult;
        }
       
        public IEnumerable<TypeConsult> Get()
        {
            return _repository.Get();
        }

        public TypeConsult Get(int id)
        {
            return _repository.Get(id);
        }

        public TypeConsult Update(EditTypeConsultDto type)
        {
            var typeConsult = _repository.Get(type.Id);
            typeConsult.Update(type.Name, type.Description);
            if (typeConsult.Enabled) typeConsult.Activate(); else typeConsult.Deactivate();
            if (typeConsult.Valid)
                _repository.Update(typeConsult);
            return typeConsult;
        }

        public IEnumerable<Notification> Validate()
        {
            return Notifications;
        }
    }
}
