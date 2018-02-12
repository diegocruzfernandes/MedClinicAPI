using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace MedServer.Infra.Repositories
{
    public class SecretaryRepository : ISecretaryRepository
    {
        public readonly DataContext _context;

        public SecretaryRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(Secretary secretary)
        {
             
            _context.Entry(secretary).State = EntityState.Deleted;
        }

        public IEnumerable<Secretary> Find(string name)
        {
            return _context.Secretaries.Where(x => x.Name == name);
        }

        public IEnumerable<Secretary> Get()
        {
            return _context.Secretaries.OrderBy(d => d.Name).ToList();
        }

        public IEnumerable<Secretary> Get(int skip, int take)
        {
            return _context.Secretaries.OrderBy(d => d.Name).Skip(skip).Take(take).ToList();
        }

        public Secretary Get(int id)
        {
            return _context.Secretaries.FirstOrDefault(x => x.Id == id); ;
        }

        public void Save(Secretary secretary)
        {
            _context.Secretaries.Add(secretary);
        }

        public bool SecretaryExists(Secretary secretary)
        {
            return _context.Secretaries.Any(x => x.Name == secretary.Name);
        }

        public void Update(Secretary secretary)
        {
            _context.Entry(secretary).State = EntityState.Modified;
        }
    }
}
