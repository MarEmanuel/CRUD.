using AutoMapper;
using CRUD.Application.Commons.Bases;
using CRUD.Application.DTOs.Response.Login;
using CRUD.Application.Interfaces;
using CRUD.Infrastructure.Persistences.Interfaces;
using CRUD.Utilities.Static;

namespace CRUD.Application.Services
{
    public class RegisterApplication : IRegisterApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public RegisterApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> InsertarPersonaUsuario(
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
            var response = new BaseResponse<bool>();

            try
            {
                await _unitOfWork.Register.InsertarPersonaUsuarioAsync(
                    NombresPersona,
                    ApellidosPersona,
                    Identificacion,
                    Genero,
                    FechaNacimiento,
                    Username,
                    Password,
                    Mail
                );

                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
                response.Errors = new List<FluentValidation.Results.ValidationFailure>
                {
                    new("Exception", ex.Message)
                };
            }
            return response;
        }
    }
}
