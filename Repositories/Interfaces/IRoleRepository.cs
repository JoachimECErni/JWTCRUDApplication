using System.Linq.Expressions;
using CRUDApplication.Domain.Entities;

namespace CRUDApplication.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> Get(int id);
        Task<List<Role>> GetAll();
        Task<Role> Add(Role entity);
        Task<Role> Update(Role entity);
        Task<Role> Delete(int id);
    }
}
