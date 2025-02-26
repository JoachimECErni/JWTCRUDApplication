using System.Linq.Expressions;
using CRUDApplication.Domain.Entities;

namespace CRUDApplication.Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<User> Get(User entity);
        Task<User> Add(User entity);
    }
}
