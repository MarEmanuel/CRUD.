using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Persistences.Contexts.Configurations
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(e => e.IdPersona)
                    .HasName("PK__Persona__A47881419AAC3F6B");

            builder.ToTable("Persona");

            builder.Property(e => e.IdPersona)
                .ValueGeneratedNever()
                .HasColumnName("idPersona");

            builder.Property(e => e.Apellidos)
                .HasMaxLength(60)
                .IsUnicode(false);

            builder.Property(e => e.FechaNacimiento).HasColumnType("date");

            builder.Property(e => e.Identificacion)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Nombres)
                .HasMaxLength(80)
                .IsUnicode(false);
        }
    }
}
