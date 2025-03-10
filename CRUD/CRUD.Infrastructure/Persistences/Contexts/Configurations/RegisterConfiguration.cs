using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Persistences.Contexts.Configurations
{
    public class RegisterConfiguration : IEntityTypeConfiguration<Register>
    {
        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder.HasNoKey();

            builder.Property(e => e.NombresPersona)
                    .HasColumnName("NombresPersona");

            builder.Property(e => e.ApellidosPersona)
                .HasColumnName("ApellidosPersona");

            builder.Property(e => e.Identificacion)
                .HasColumnName("Identificacion");

            builder.Property(e => e.Genero)
                .HasColumnName("Genero");

            builder.Property(e => e.FechaNacimiento)
                .HasColumnName("FechaNacimiento");

            builder.Property(e => e.Username)
                .HasColumnName("Username");

            builder.Property(e => e.Password)
                .HasColumnName("Password");

            builder.Property(e => e.Mail)
                .HasColumnName("Mail");

            builder.Property(e => e.EstadoUsuario)
                .HasColumnName("EstadoUsuario");
        }
    }
}
