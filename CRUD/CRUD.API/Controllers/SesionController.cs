using CRUD.Application.DTOs.Request;
using CRUD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        private readonly ISesionApplication _sesionApplication;

        public SesionController(ISesionApplication sesionApplication)
        {
            _sesionApplication = sesionApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListSessions()
        {
            var response = await _sesionApplication.ListarSesiones();
            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet("GetByID/{idUsuario:int}")]
        public async Task<IActionResult> ListSessionByID(int idUsuario)
        {
            var response = await _sesionApplication.ListarSesionPorID(idUsuario);
            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut("EndSession/")]
        public async Task<IActionResult> EndSession([FromBody] SesionRequestDTO _request)
        {
            var response = await _sesionApplication.FinalizarSesion(
                _request.IdSesion!,
                _request.IdUsuario
            );

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
