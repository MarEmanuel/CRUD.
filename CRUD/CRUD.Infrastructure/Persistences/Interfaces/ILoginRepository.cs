using CRUD.Domain.Entities;

namespace CRUD.Infrastructure.Persistences.Interfaces
{
    public interface ILoginRepository : IGenericRepository<Login>
    {
        Task<IEnumerable<Login>> LoginAsync(
            string Username,
            string Password
        );
    }
}
