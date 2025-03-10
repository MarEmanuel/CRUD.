using CRUD.Infrastructure.Commons.Bases.Request;
using CRUD.Infrastructure.Persistences.Contexts;
using CRUD.Infrastructure.Persistences.Interfaces;
using CRUD.Shared.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace CRUD.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DatabaseContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public IQueryable<TDTO> Ordering<TDTO>(
            BasePaginationRequest request,
            IQueryable<TDTO> queryable,
            bool pagination = false)
            where TDTO : class
        {
            IQueryable<TDTO> queryDTO = request.Order == "desc" ? queryable.OrderBy($"{request.Sort} descending") : queryable.OrderBy($"{request.Sort} ascending");

            //if (pagination) queryDTO = queryDTO.Paginate(request);

            return queryDTO;
        }

        public async Task<IEnumerable<T>> ExecuteStoredProcedureAsync(
            string storedProcedure, 
            params SqlParameter[] parameters
        )
        {
            var SQL_QUERY = $"EXEC {storedProcedure} ";

            SQL_QUERY += string.Join(", ", parameters.Select(p => $"{p.ParameterName} = {p.Value}"));

            return await _entity
                .FromSqlRaw(SQL_QUERY, parameters)
                .ToListAsync();
        }

        public async Task ExecuteNonQueryStoredProcedureAsync(
            string storedProcedure, 
            params SqlParameter[] parameters
        )
        {
            var SQL_QUERY = $"EXEC {storedProcedure} ";

            SQL_QUERY += string.Join(", ", parameters.Select(p => p.ParameterName));

            await _context.Database.ExecuteSqlRawAsync(SQL_QUERY, parameters);
        }

        public async Task<IEnumerable<BaseDTO>> ExecuteStoredProcedureForBaseDTOAsync(
            string storedProcedure,
            string idColumnName,
            string stringColumnName,
            params SqlParameter[] parameters
        )
        {
            var SQL_QUERY = $"EXEC {storedProcedure} ";
            SQL_QUERY += string.Join(", ", parameters.Select(p => $"{p.ParameterName} = {p.Value}"));

            using var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = SQL_QUERY;
            command.Parameters.AddRange(parameters);

            var results = new List<BaseDTO>();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                results.Add(new BaseDTO
                {
                    Id_value = reader[idColumnName] is DBNull ? 0 : Convert.ToInt32(reader[idColumnName]),
                    String_value = reader[stringColumnName] is DBNull ? null : reader[stringColumnName].ToString()
                });
            }

            return results;
        }

        public async Task<IEnumerable<IDictionary<string, object>>> ExecuteStoredProcedureForNonBaseEntity(
            string storedProcedure,
            params SqlParameter[] parameters
        )
        {
            var SQL_QUERY = $"EXEC {storedProcedure} ";

            SQL_QUERY += string.Join(", ", parameters.Select(p => $"{p.ParameterName} = {p.Value}"));

            var connection = _context.Database.GetDbConnection();

            var resultList = new List<IDictionary<string, object>>();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = SQL_QUERY;
                command.Parameters.AddRange(parameters);
                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row.Add(reader.GetName(i), reader.GetValue(i));
                        }
                        resultList.Add(row);
                    }
                }
            }

            return resultList;
        }
    }
}
