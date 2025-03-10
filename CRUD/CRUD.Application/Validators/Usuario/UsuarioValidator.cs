using CRUD.Application.DTOs.Request;
using FluentValidation;

namespace CRUD.Application.Validators.Usuario
{
    public class UsuarioValidator : AbstractValidator<UsuarioRequestDTO>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Username)
                .NotNull().WithMessage("El campo 'Username' no puede ser nulo.")
                .NotEmpty().WithMessage("El campo 'Username' no puede ser vacío.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("El campo 'Password' no puede ser nulo.")
                .NotEmpty().WithMessage("El campo 'Password' no puede ser vacío.");
        }
    }
}
