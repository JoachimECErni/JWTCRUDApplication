using CRUDApplication.Data;
using CRUDApplication.Domain.Entities;
using CRUDApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUDApplication.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AppDbContext _context;

        public AuthenticationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User entity)
        {
            await _context.Set<User>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> Get(User entity)
        {
            var query = _context.Set<User>()
                .Include(u => u.UserRoles) 
                    .ThenInclude(ur => ur.Role);

            return await query.FirstOrDefaultAsync(u => u.Username == entity.Username);
        }
    }
}
