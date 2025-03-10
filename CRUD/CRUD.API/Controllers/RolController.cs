using CRUD.Application.DTOs.Request;
using CRUD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolApplication _rolApplication;

        public RolController(IRolApplication rolApplication)
        {
            _rolApplication = rolApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListRoles()
        {
            var response = await _rolApplication.ListarRoles();
            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectedRoles()
        {
            var response = await _rolApplication.ListarRolesSeleccionados();
            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegistrarRol([FromBody] RolRequestDTO _request)
        {
            var response = await _rolApplication.InsertarRol(
                _request.NombreRol!,
                _request.DescripcionRol!,
                Convert.ToChar(_request.EstadoRol!)
            );

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut("Edit/{idRol:int}")]
        public async Task<IActionResult> EditRol(int idRol, [FromBody] RolRequestDTO _request)
        {
            var response = await _rolApplication.ActualizarRol(
                idRol,
                 _request.NombreRol!,
                 _request.DescripcionRol!,
                 Convert.ToChar(_request.EstadoRol!)
            );

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut("Remove/{idRol:int}")]
        public async Task<IActionResult> RemoveRol(int idRol)
        {
            var response = await _rolApplication.EliminarRol(idRol);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
