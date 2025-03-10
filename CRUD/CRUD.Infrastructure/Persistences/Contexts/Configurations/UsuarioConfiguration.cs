using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Persistences.Contexts.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PK__Usuarios__645723A6C989DA45");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("idUsuario");

            builder.Property(e => e.IdPersona).HasColumnName("idPersona");

            builder.Property(e => e.Mail)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasMaxLength(122)
                .IsUnicode(false);

            builder.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.EstadoUsuario)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("EstadoUsuario");

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

            builder.HasOne(d => d.IdPersonaNavigation)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__idPers__3B75D760");

            builder.Property(e => e.IdRol)
                .HasColumnName("idRol");

            builder.HasMany(d => d.IdRols)
                .WithMany(p => p.IdUsuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "RolUsuario",
                    j => j.HasOne<Rol>().WithMany().HasForeignKey("IdRol").OnDelete(DeleteBehavior.ClientSetNull),
                    j => j.HasOne<Usuario>().WithMany().HasForeignKey("IdUsuario").OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("IdRol", "IdUsuario").HasName("PK_RolUsuario");
                        j.ToTable("Rol_Usuarios");
                    });
        }
    }
}
