using CRUD.Application.DTOs.Request;
using CRUD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaApplication _personaApplication;

        public PersonaController(IPersonaApplication personaApplication)
        {
            _personaApplication = personaApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListPersonas()
        {
            var response = await _personaApplication.ListarPersonas();
            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectedPersona()
        {
            var response = await _personaApplication.ListarPersonasSeleccionadas();
            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet("GetByID/{idPersona:int}")]
        public async Task<IActionResult> ListPersonaByID(int idPersona)
        {
            var response = await _personaApplication.ListarPersonaPorID(idPersona);
            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterPersona([FromBody] PersonaRequestDTO _request)
        {
            var response = await _personaApplication.InsertarPersona(
                _request.NombresPersona!,
                _request.ApellidosPersona!,
                _request.Identificacion!,
                Convert.ToChar(_request.Genero),
                _request.FechaNacimiento,
                Convert.ToChar(_request.EstadoPersona!)
            );

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut("Edit/{idPersona:int}")]
        public async Task<IActionResult> EditPersona(int idPersona, [FromBody] PersonaRequestDTO _request)
        {
            var response = await _personaApplication.ActualizarPersona(
                idPersona,
                _request.NombresPersona!,
                _request.ApellidosPersona!,
                _request.Identificacion!,
                Convert.ToChar(_request.Genero!),
                _request.FechaNacimiento,
                Convert.ToChar(_request.EstadoPersona!)
            );
            return Ok(response);
        }

        [HttpPut("Remove/{idPersona:int}")]
        public async Task<IActionResult> RemovePersona(int idPersona)
        {
            var response = await _personaApplication.EliminarPersona(idPersona);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
