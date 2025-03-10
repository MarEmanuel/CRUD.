using CRUD.Domain.Entities;
using CRUD.Infrastructure.Persistences.Contexts;
using CRUD.Infrastructure.Persistences.Interfaces;
using Microsoft.Data.SqlClient;

namespace CRUD.Infrastructure.Persistences.Repositories
{
    public class RegisterRepository : GenericRepository<Register>, IRegisterRepository
    {
        public RegisterRepository(DatabaseContext context) : base(context) { }

        public async Task InsertarPersonaUsuarioAsync(
            string NombresPersona, 
            string ApellidosPersona, 
            string Identificacion, 
            char Genero, 
            DateTime FechaNacimiento, 
            string Username, 
            string Password, 
            string Mail
        )
        {
            var parameters = new[]
            {
                new SqlParameter("@PersonName", NombresPersona),
                new SqlParameter("@PersonLastName", ApellidosPersona),
                new SqlParameter("@PersonID", Identificacion),
                new SqlParameter("@PersonGender", Genero),
                new SqlParameter("@PersonBirthDate", FechaNacimiento),
                new SqlParameter("@UserUsername", Username),
                new SqlParameter("@UserPassword", Password),
                new SqlParameter("@UserMail", Mail)
            };

            await ExecuteNonQueryStoredProcedureAsync("RegistroPersonaUsuario", parameters);
        }
    }
}
