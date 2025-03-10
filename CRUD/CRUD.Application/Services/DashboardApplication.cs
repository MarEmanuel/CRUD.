using AutoMapper;
using CRUD.Application.Commons.Bases;
using CRUD.Application.DTOs.Response.Dashboard;
using CRUD.Application.Interfaces;
using CRUD.Infrastructure.Persistences.Interfaces;
using CRUD.Utilities.Static;

namespace CRUD.Application.Services
{
    public class DashboardApplication : IDashboardApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<AdminDashboardResponseDTO>>> ListarDashboardAdmin()
        {
            var response = new BaseResponse<IEnumerable<AdminDashboardResponseDTO>>();
            var dashboard = await _unitOfWork.Dashboard.ListarDashboardAdminAsync();

            if (dashboard.Any())
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<AdminDashboardResponseDTO>>(dashboard);
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
