using CRUD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardApplication _dashboardApplication;

        public DashboardController(IDashboardApplication dashboardApplication)
        {
            _dashboardApplication = dashboardApplication;
        }

        [HttpGet("Administrador")]
        public async Task<IActionResult> ListPersonas()
        {
            var response = await _dashboardApplication.ListarDashboardAdmin();
            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
