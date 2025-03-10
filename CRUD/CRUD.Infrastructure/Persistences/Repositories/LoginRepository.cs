using CRUD.Domain.Entities;
using CRUD.Infrastructure.Persistences.Contexts;
using CRUD.Infrastructure.Persistences.Interfaces;
using Microsoft.Data.SqlClient;

namespace CRUD.Infrastructure.Persistences.Repositories
{
    public class LoginRepository : GenericRepository<Login>, ILoginRepository
    {
        public LoginRepository(DatabaseContext context) : base(context) { }

        public async Task<IEnumerable<Login>> LoginAsync(string Username, string Password)
        {
            var parameters = new[]
            {
                new SqlParameter("@Username", Username),
                new SqlParameter("@Password", Password)
            };

            return await ExecuteStoredProcedureAsync("IniciarSesion", parameters);
        }
    }
}
