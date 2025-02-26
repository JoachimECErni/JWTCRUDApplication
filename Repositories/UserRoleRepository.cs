using CRUDApplication.Data;
using CRUDApplication.Domain.Entities;
using CRUDApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUDApplication.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly AppDbContext _context;

        public UserRoleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserRole> Add(UserRole entity)
        {
            await _context.Set<UserRole>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<List<UserRole>> GetAll(params Expression<Func<UserRole, object>>[] includes)
        {
            IQueryable<UserRole> query = _context.Set<UserRole>();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.ToListAsync();
        }
        public async Task<UserRole> Get(int Id, params Expression<Func<UserRole, object>>[] includes)
        {
            IQueryable<UserRole> query = _context.Set<UserRole>();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == Id);
        }

        public async Task<UserRole> Update(UserRole entity)
        {
            _context.Set<UserRole>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<UserRole> Delete(int id)
        {
            var entity = await _context.Set<UserRole>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<UserRole>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }

    }
}
