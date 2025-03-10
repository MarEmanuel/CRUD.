using AutoMapper;
using CRUD.Application.Commons.Bases;
using CRUD.Application.DTOs.Response.Persona;
using CRUD.Application.Interfaces;
using CRUD.Application.Validators.Persona;
using CRUD.Infrastructure.Persistences.Interfaces;
using CRUD.Shared.Models;
using CRUD.Utilities.Static;

namespace CRUD.Application.Services
{
    public class PersonaApplication : IPersonaApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PersonaValidator _validationRules;

        public PersonaApplication(IUnitOfWork unitOfWork, IMapper mapper, PersonaValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<IEnumerable<PersonaResponseDTO>>> ListarPersonas()
        {
            var response = new BaseResponse<IEnumerable<PersonaResponseDTO>>();
            var personas = await _unitOfWork.Persona.ListarPersonasAsync();

            if (personas.Any())
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<PersonaResponseDTO>>(personas);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<IEnumerable<BaseDTO>>> ListarPersonasSeleccionadas()
        {
            var response = new BaseResponse<IEnumerable<BaseDTO>>();
            var personas = await _unitOfWork.Persona.ListarPersonasSeleccionadasAsync();

            if (personas is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<BaseDTO>>(personas);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<IEnumerable<PersonaResponseDTO>>> ListarPersonaPorID(
            int IdPersona
        )
        {
            var response = new BaseResponse<IEnumerable<PersonaResponseDTO>>();
            var persona = await _unitOfWork.Persona.ListarPersonaPorIDAsync(IdPersona);

            if (persona.Any())
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<PersonaResponseDTO>>(persona);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> InsertarPersona(
            string NombresPersona,
            string ApellidosPersona, 
            string Identificacion, 
            char Genero, 
            DateTime FechaNacimiento, 
            char EstadoPersona
        )
        {
            var response = new BaseResponse<bool>();
            try
            {
                await _unitOfWork.Persona.InsertarPersonaAsync(
                    NombresPersona, 
                    ApellidosPersona, 
                    Identificacion, 
                    Genero, 
                    FechaNacimiento, 
                    EstadoPersona
                );
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

        public async Task<BaseResponse<bool>> ActualizarPersona(
            int IdPersona, 
            string NombresPersona, 
            string ApellidosPersona, 
            string Identificacion, 
            char Genero, 
            DateTime FechaNacimiento,
            char EstadoPersona
        )
        {
            var response = new BaseResponse<bool>();

            try
            {
                await _unitOfWork.Persona.ActualizarPersonaAsync(
                    IdPersona,
                    NombresPersona,
                    ApellidosPersona,
                    Identificacion,
                    Genero,
                    FechaNacimiento,
                    EstadoPersona
                );
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

        public async Task<BaseResponse<bool>> EliminarPersona(int IdPersona)
        {
            var response = new BaseResponse<bool>();
            try
            {
                await _unitOfWork.Persona.EliminarPersonaAsync(IdPersona);
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
