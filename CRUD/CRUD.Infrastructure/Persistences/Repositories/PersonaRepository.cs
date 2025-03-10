using CRUD.Domain.Entities;
using CRUD.Infrastructure.Persistences.Contexts;
using CRUD.Infrastructure.Persistences.Interfaces;
using CRUD.Shared.Models;
using Microsoft.Data.SqlClient;

namespace CRUD.Infrastructure.Persistences.Repositories
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        public PersonaRepository(DatabaseContext context) : base(context) { }

        public async Task<IEnumerable<Persona>> ListarPersonasAsync()
        {
            return await ExecuteStoredProcedureAsync("LeerPersonas");
        }

        public async Task<IEnumerable<BaseDTO>> ListarPersonasSeleccionadasAsync()
        {
            return await ExecuteStoredProcedureForBaseDTOAsync(
                "ListarPersonas",
                "idPersona",
                "NombrePersona"
            );
        }

        public async Task<IEnumerable<Persona>> ListarPersonaPorIDAsync(
            int IdPersona
        )
        {
            var parameters = new[]
            {
                new SqlParameter("@PersonId", IdPersona)
            };

            return await ExecuteStoredProcedureAsync("LeerPersonaPorID", parameters);
        }

        public async Task InsertarPersonaAsync(
            string NombresPersona, 
            string ApellidosPersona, 
            string Identificacion, 
            char Genero, 
            DateTime FechaNacimiento, 
            char EstadoPersona
        )
        {
            var parameters = new[]
            {
                new SqlParameter("@PersonName", NombresPersona),
                new SqlParameter("@PersonLastName", ApellidosPersona),
                new SqlParameter("@PersonID", Identificacion),
                new SqlParameter("@PersonGender", Genero),
                new SqlParameter("@PersonBirthDate", FechaNacimiento),
                new SqlParameter("@PersonStatus", EstadoPersona),
            };

            await ExecuteNonQueryStoredProcedureAsync("InsertarPersona", parameters);
        }

        public async Task ActualizarPersonaAsync(
            int IdPersona, 
            string NombresPersona, 
            string ApellidosPersona, 
            string Identificacion, 
            char Genero, 
            DateTime FechaNacimiento, 
            char EstadoPersona
        )
        {
            var parameters = new[]
            {
                new SqlParameter("@PersonId", IdPersona),
                new SqlParameter("@PersonName", NombresPersona),
                new SqlParameter("@PersonLastName", ApellidosPersona),
                new SqlParameter("@PersonID", Identificacion),
                new SqlParameter("@PersonGender", Genero),
                new SqlParameter("@PersonBirthDate", FechaNacimiento),
                new SqlParameter("@PersonStatus", EstadoPersona),
            };

            await ExecuteNonQueryStoredProcedureAsync("EditarPersona", parameters);
        }

        public async Task EliminarPersonaAsync(int IdPersona)
        {
            var parameters = new[]
            {
                new SqlParameter("@PersonId", IdPersona)
            };

            await ExecuteNonQueryStoredProcedureAsync("EliminarPersona", parameters);
        }
    }
}
