using CRUD.Application.DTOs.Request;
using FluentValidation;

namespace CRUD.Application.Validators.Persona
{
    public class PersonaValidator : AbstractValidator<PersonaRequestDTO>
    {
        public PersonaValidator()
        {
            RuleFor(x => x.NombresPersona)
                .NotNull().WithMessage("El campo 'Nombre' no puede ser nulo.")
                .NotEmpty().WithMessage("El campo 'Nombre' no puede ser vacío.");

            RuleFor(x => x.ApellidosPersona)
                .NotNull().WithMessage("El campo 'Apellido' no puede ser nulo.")
                .NotEmpty().WithMessage("El campo 'Apellido' no puede ser vacío.");

            RuleFor(x => x.Identificacion)
                .NotNull().WithMessage("El campo 'Identificación' no puede ser nulo.")
                .NotEmpty().WithMessage("El campo 'Identificación' no puede ser vacío.");

            RuleFor(x => x.Genero)
                .NotNull().WithMessage("El campo 'Genero' no puede ser nulo.")
                .NotEmpty().WithMessage("El campo 'Genero' no puede ser vacío.");

            RuleFor(x => x.FechaNacimiento)
                .NotNull().WithMessage("El campo 'FechaNacimiento' no puede ser nulo.")
                .NotEmpty().WithMessage("El campo 'FechaNacimiento' no puede ser vacío.");
        }
    }
}
