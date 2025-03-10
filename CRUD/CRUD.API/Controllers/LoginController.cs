using CRUD.Application.DTOs.Request;
using CRUD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRegisterApplication _registerApplication;
        private readonly ILoginApplication _loginApplication;

        public LoginController(
            IRegisterApplication registerApplication,
            ILoginApplication loginApplication
        )
        {
            _registerApplication = registerApplication;
            _loginApplication = loginApplication;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegistrarPersonaUsuario([FromBody] RegistrationRequestDTO _request)
        {
            var response = await _registerApplication.InsertarPersonaUsuario(
                _request.NombresPersona!,
                _request.ApellidosPersona!,
                _request.Identificacion!,
                Convert.ToChar(_request.Genero!),
                _request.FechaNacimiento!,
                _request.Username!,
                _request.Password!,
                _request.Mail!
            );

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost("SessionStart")]
        public async Task<IActionResult> IniciarSesion([FromBody] LoginRequestDTO _request)
        {
            var response = await _loginApplication.Login(
                _request.Username!,
                _request.Password!
            );

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
