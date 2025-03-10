using CRUD.Application.DTOs.Request;
using FluentValidation;

namespace CRUD.Application.Validators.Rol
{
    public class RolValidator : AbstractValidator<RolRequestDTO>
    {
        public RolValidator()
        {
            RuleFor(x => x.NombreRol)
                .NotNull().WithMessage("El campo 'RolName' no puede ser nulo.")
                .NotEmpty().WithMessage("El campo 'RolName' no puede ser vacío.");

            RuleFor(x => x.DescripcionRol)
                .NotNull().WithMessage("El campo 'RolDescription' no puede ser nulo.")
                .NotEmpty().WithMessage("El campo 'RolDescription' no puede ser vacío.");
        }
    }
}
