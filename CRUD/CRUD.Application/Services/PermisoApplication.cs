using AutoMapper;
using CRUD.Application.Commons.Bases;
using CRUD.Application.DTOs.Response.Permiso;
using CRUD.Application.Interfaces;
using CRUD.Infrastructure.Persistences.Interfaces;
using CRUD.Utilities.Static;

namespace CRUD.Application.Services
{
    public class PermisoApplication : IPermisoApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PermisoApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<PermisoResponseDTO>>> ListarPermisosPorRol(int idRol)
        {
            var response = new BaseResponse<IEnumerable<PermisoResponseDTO>>();
            var personas = await _unitOfWork.Permiso.ListarPermisosAsync(idRol);

            if (personas.Any())
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<PermisoResponseDTO>>(personas);
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
