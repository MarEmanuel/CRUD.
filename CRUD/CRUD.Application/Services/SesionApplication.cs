using AutoMapper;
using CRUD.Application.Commons.Bases;
using CRUD.Application.DTOs.Response.Sesion;
using CRUD.Application.Interfaces;
using CRUD.Application.Validators.Usuario;
using CRUD.Infrastructure.Persistences.Interfaces;
using CRUD.Utilities.Static;

namespace CRUD.Application.Services
{
    public class SesionApplication : ISesionApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UsuarioValidator _validationRules;

        public SesionApplication(IUnitOfWork unitOfWork, IMapper mapper, UsuarioValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<IEnumerable<SesionResponseDTO>>> ListarSesiones()
        {
            var response = new BaseResponse<IEnumerable<SesionResponseDTO>>();
            var sesiones = await _unitOfWork.Sesion.ListarSesionesAsync();

            if (sesiones.Any())
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<SesionResponseDTO>>(sesiones);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<IEnumerable<SesionResponseDTO>>> ListarSesionPorID(int IdUsuario)
        {
            var response = new BaseResponse<IEnumerable<SesionResponseDTO>>();
            var sesion = await _unitOfWork.Sesion.ListarSesionPorIDAsync(IdUsuario);

            if (sesion.Any())
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<SesionResponseDTO>>(sesion);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> IniciarSesion(int IdUsuario)
        {
            var response = new BaseResponse<bool>();
            try
            {
                await _unitOfWork.Sesion.IniciarSesionAsync(
                    IdUsuario
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

        public async Task<BaseResponse<bool>> FinalizarSesion(int IdSesion, int IdUsuario)
        {
            var response = new BaseResponse<bool>();
            try
            {
                await _unitOfWork.Sesion.FinalizarSesionAsync(
                    IdSesion,
                    IdUsuario
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
    }
}
