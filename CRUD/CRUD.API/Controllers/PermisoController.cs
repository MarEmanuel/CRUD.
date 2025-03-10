using CRUD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisoController : ControllerBase
    {
        private readonly IPermisoApplication _permisoApplication;

        public PermisoController(IPermisoApplication permisoApplication)
        {
            _permisoApplication = permisoApplication;
        }

        [HttpGet("{idRol:int}")]
        public async Task<IActionResult> ListarPermisosPorRol(int idRol)
        {
            var response = await _permisoApplication.ListarPermisosPorRol(idRol);
            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
