using AutoMapper;
using CRUD.Application.Commons.Bases;
using CRUD.Application.DTOs.Response.Rol;
using CRUD.Application.Interfaces;
using CRUD.Application.Validators.Rol;
using CRUD.Infrastructure.Persistences.Interfaces;
using CRUD.Shared.Models;
using CRUD.Utilities.Static;

namespace CRUD.Application.Services
{
    public class RolApplication : IRolApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RolValidator _validationRules;

        public RolApplication(IUnitOfWork unitOfWork, IMapper mapper, RolValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<IEnumerable<RolResponseDTO>>> ListarRoles()
        {
            var response = new BaseResponse<IEnumerable<RolResponseDTO>>();
            var roles = await _unitOfWork.Rol.ListarRolesAsync();

            if (roles.Any())
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<RolResponseDTO>>(roles);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<IEnumerable<BaseDTO>>> ListarRolesSeleccionados()
        {
            var response = new BaseResponse<IEnumerable<BaseDTO>>();
            var roles = await _unitOfWork.Rol.ListarRolesSeleccionadosAsync();

            if (roles is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<BaseDTO>>(roles);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> InsertarRol(
            string NombreRol, 
            string DescripcionRol, 
            char EstadoRol
        )
        {
            var response = new BaseResponse<bool>();

            try
            {
                await _unitOfWork.Rol.InsertarRolAsync(NombreRol, DescripcionRol, EstadoRol);
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
        
        public async Task<BaseResponse<bool>> ActualizarRol(
            int IdRol, 
            string NombreRol, 
            string DescripcionRol, 
            char EstadoRol
        )
        {
            var response = new BaseResponse<bool>();
            try
            {
                await _unitOfWork.Rol.ActualizarRolAsync(IdRol, NombreRol, DescripcionRol, EstadoRol);
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

        public async Task<BaseResponse<bool>> EliminarRol(int IdRol)
        {
            var response = new BaseResponse<bool>();
            try
            {
                await _unitOfWork.Rol.EliminarRolAsync(IdRol);
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
