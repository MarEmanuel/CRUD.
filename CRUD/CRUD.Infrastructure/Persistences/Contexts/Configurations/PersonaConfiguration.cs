using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Persistences.Contexts.Configurations
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PK__Persona__A47881419AAC3F6B");

            builder.ToTable("Persona");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("idPersona");

            builder.Property(e => e.ApellidosPersona)
                .HasMaxLength(60)
                .IsUnicode(false);

            builder.Property(e => e.FechaNacimiento).HasColumnType("date");

            builder.Property(e => e.Identificacion)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.NombresPersona)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.EstadoPersona)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("EstadoPersona");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("FechaCreacion");

            builder.Property(e => e.FechaEdicion)
                .HasColumnType("date")
                .HasColumnName("FechaEdicion");

            builder.Property(e => e.FechaEliminacion)
                .HasColumnType("date")
                .HasColumnName("FechaEliminacion");

            builder.Property(e => e.UsuarioCreacion)
                .HasColumnType("int")
                .HasColumnName("UsuarioCreacion");

            builder.Property(e => e.UsuarioEdicion)
                .HasColumnType("int")
                .HasColumnName("UsuarioEdicion");

            builder.Property(e => e.UsuarioEliminacion)
                .HasColumnType("int")
                .HasColumnName("UsuarioEliminacion");
        }
    }
}
