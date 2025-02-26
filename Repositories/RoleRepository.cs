using CRUDApplication.Data;
using CRUDApplication.Domain.Entities;
using CRUDApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUDApplication.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAll()
        {
            return await _context.Set<Role>().ToListAsync();
        }

        public async Task<Role> Get(int id)
        {
            return await _context.Set<Role>().FindAsync(id);
        }

        public async Task<Role> Add(Role entity)
        {
            await _context.Set<Role>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Role> Update(Role entity)
        {
            _context.Set<Role>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<Role> Delete(int id)
        {
            var entity = await _context.Set<Role>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Role>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
