using CRUD.Application.Commons.Bases;
using CRUD.Application.DTOs.Response.Login;

namespace CRUD.Application.Interfaces
{
    public interface ILoginApplication
    {
        Task<BaseResponse<IEnumerable<LoginResponseDTO>>> Login(
            string Username,
            string Password
        );
    }
}
