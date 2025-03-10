using CRUD.Application.DTOs.Request;
using CRUD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplication _usuarioApplication;

        public UsuarioController(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListUsuarios()
        {
            var response = await _usuarioApplication.ListarUsuarios();
            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet("GetByID/{idUsuario:int}")]
        public async Task<IActionResult> ListPersonaByID(int idUsuario)
        {
            var response = await _usuarioApplication.ListarUsuarioPorID(idUsuario);
            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUsuario([FromBody] UsuarioRequestDTO _request)
        {
            var response = await _usuarioApplication.InsertarUsuario(
                _request.Username!,
                _request.Password!,
                _request.Mail!,
                _request.IdPersona,
                _request.IdRol,
                Convert.ToChar(_request.EstadoUsuario!)
            );

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut("Edit/{idUsuario:int}")]
        public async Task<IActionResult> EditUsuario(int idUsuario, [FromBody] UsuarioRequestDTO _request)
        {
            var response = await _usuarioApplication.ActualizarUsuario(
                idUsuario, 
                _request.Username!,
                _request.Password!,
                _request.Mail!,
                _request.IdPersona,
                _request.IdRol,
                Convert.ToChar(_request.EstadoUsuario!)
            );

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut("Remove/{idUsuario:int}")]
        public async Task<IActionResult> RemoveUsuario(int idUsuario)
        {
            var response = await _usuarioApplication.EliminarUsuario(idUsuario);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
