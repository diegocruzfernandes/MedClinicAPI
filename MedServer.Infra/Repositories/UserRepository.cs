using MedServer.Domain.Dtos.UserDtos;
using MedServer.Domain.Entities;
using MedServer.Domain.Repositories;
using MedServer.Infra.Context;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }     

        public IEnumerable<UserDto> Get()
        {
            return _context
               .Users
               .Select(u => new UserDto
               {
                   Id = u.Id,
                   Nickname = u.Nickname,
                   Email = u.Email,
                   Permission = (int)u.Permission,
                   Enabled = u.Enabled
               })
           .OrderBy(u => u.Nickname)
           .ToList();
        }

        public IEnumerable<UserDto> Get(int skip, int take)
        {
            return _context
               .Users
               .Select(u => new UserDto
               {
                   Nickname = u.Nickname,
                   Email = u.Email,
                   Permission = (int)u.Permission,
                   Enabled = u.Enabled
               })
           .OrderBy(u => u.Nickname)
           .Skip(skip)
           .Take(take)
           .ToList();
        }

        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x=> x.Email == email);
        }

        public void Save(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(User user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public bool UserExists(User user)
        {
            return _context.Users.Any(x => x.Email == user.Email);
        }
    }
}
