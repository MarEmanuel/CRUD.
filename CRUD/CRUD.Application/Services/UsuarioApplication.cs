using AutoMapper;
using CRUD.Application.Commons.Bases;
using CRUD.Application.DTOs.Response.Usuario;
using CRUD.Application.Interfaces;
using CRUD.Application.Validators.Usuario;
using CRUD.Infrastructure.Persistences.Interfaces;
using CRUD.Utilities.Static;

namespace CRUD.Application.Services
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UsuarioValidator _validationRules;

        public UsuarioApplication(IUnitOfWork unitOfWork, IMapper mapper, UsuarioValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<IEnumerable<UsuarioResponseDTO>>> ListarUsuarios()
        {
            var response = new BaseResponse<IEnumerable<UsuarioResponseDTO>>();
            var usuarios = await _unitOfWork.Usuario.ListarUsuariosAsync();

            if (usuarios.Any())
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<UsuarioResponseDTO>>(usuarios);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<IEnumerable<UsuarioResponseDTO>>> ListarUsuarioPorID(int IdUsuario)
        {
            var response = new BaseResponse<IEnumerable<UsuarioResponseDTO>>();
            var usuarios = await _unitOfWork.Usuario.ListarUsuarioPorIDAsync(IdUsuario);

            if (usuarios.Any())
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<UsuarioResponseDTO>>(usuarios);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> InsertarUsuario(
            string UserUsername, 
            string UserPassword, 
            string UserMail, 
            int PersonID,
            int UserID,
            char UserStatus
        )
        {
            var response = new BaseResponse<bool>();
            try
            {
                await _unitOfWork.Usuario.InsertarUsuarioAsync(
                    UserUsername, 
                    UserPassword, 
                    UserMail, 
                    PersonID,
                    UserID,
                    UserStatus
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

        public async Task<BaseResponse<bool>> ActualizarUsuario(
            int IdUser, 
            string UserUsername, 
            string UserPassword, 
            string UserMail, 
            int PersonID,
            int UserID,
            char UserStatus
        )
        {
            var response = new BaseResponse<bool>();
            try
            {
                await _unitOfWork.Usuario.ActualizarUsuarioAsync(
                    IdUser, 
                    UserUsername, 
                    UserPassword, 
                    UserMail, 
                    PersonID,
                    UserID,
                    UserStatus
                );
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
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

        public async Task<BaseResponse<bool>> EliminarUsuario(int IdUser)
        {
            var response = new BaseResponse<bool>();
            try
            {
                await _unitOfWork.Usuario.EliminarUsuarioAsync(IdUser);
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
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
