using CRUD.Infrastructure.Commons.Bases.Request;
using CRUD.Shared.Models;
using Microsoft.Data.SqlClient;

namespace CRUD.Infrastructure.Persistences.Interfaces
{
    public interface IGenericRepository<T>
    {
        IQueryable<TDTO> Ordering<TDTO>(
            BasePaginationRequest request,
            IQueryable<TDTO> queryable,
            bool pagination = false)
            where TDTO : class;

        Task<IEnumerable<T>> ExecuteStoredProcedureAsync(
            string storedProcedure, 
            params SqlParameter[] parameters
        );

        Task ExecuteNonQueryStoredProcedureAsync(
            string storedProcedure, 
            params SqlParameter[] parameters
        );

        Task<IEnumerable<BaseDTO>> ExecuteStoredProcedureForBaseDTOAsync(
            string storedProcedure,
            string idColumnName,
            string stringColumnName,
            params SqlParameter[] parameters
        );

        Task<IEnumerable<IDictionary<string, object>>> ExecuteStoredProcedureForNonBaseEntity(
            string storedProcedure,
            params SqlParameter[] parameters
        );
    }
}
