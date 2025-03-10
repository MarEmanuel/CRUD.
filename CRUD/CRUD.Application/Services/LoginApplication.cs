using AutoMapper;
using CRUD.Application.Commons.Bases;
using CRUD.Application.DTOs.Response.Login;
using CRUD.Application.Interfaces;
using CRUD.Infrastructure.Persistences.Interfaces;
using CRUD.Utilities.Static;

namespace CRUD.Application.Services
{
    public class LoginApplication : ILoginApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoginApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<LoginResponseDTO>>> Login(
            string Username, 
            string Password
        )
        {
            var response = new BaseResponse<IEnumerable<LoginResponseDTO>>();
            var id = await _unitOfWork.Login.LoginAsync(Username, Password);

            if (id.Any())
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<LoginResponseDTO>>(id);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }
    }
}
