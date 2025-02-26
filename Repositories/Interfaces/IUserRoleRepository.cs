using System.Linq.Expressions;
using CRUDApplication.Domain.Entities;

namespace CRUDApplication.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<List<UserRole>> GetAll(params Expression<Func<UserRole, object>>[] includes);
        Task<UserRole> Get(int Id, params Expression<Func<UserRole, object>>[] includes);
        Task<UserRole> Add(UserRole entity);
        Task<UserRole> Update(UserRole entity);
        Task<UserRole> Delete(int id);
    }
}
