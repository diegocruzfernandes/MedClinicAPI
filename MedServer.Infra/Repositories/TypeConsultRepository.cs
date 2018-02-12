using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Infra.Repositories
{
    public class TypeConsultRepository : ITypeConsultRepository
    {
        private readonly DataContext _context;

        public TypeConsultRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(TypeConsult type)
        {
            _context.Entry(type).State = EntityState.Deleted;
        }

        public IEnumerable<TypeConsult> Get()
        {
            return _context.TypesConsult
                    .OrderBy(u => u.Name)
                    .ToList();
        }

        public TypeConsult Get(int id)
        {
            return _context.TypesConsult.FirstOrDefault(x => x.Id == id); ;
        }

        public bool TypeConsultExists(TypeConsult type)
        {
            return _context.TypesConsult.Any(x => x.Name == type.Name);
        }

        public void Save(TypeConsult type)
        {
            _context.TypesConsult.Add(type);
        }

        public void Update(TypeConsult type)
        {
            _context.Entry(type).State = EntityState.Modified;
        }
    }
}
