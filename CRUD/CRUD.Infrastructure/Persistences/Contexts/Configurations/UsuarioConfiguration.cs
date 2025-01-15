using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Persistences.Contexts.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__645723A6C989DA45");

            builder.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("idUsuario");

            builder.Property(e => e.IdPersona).HasColumnName("idPersona");

            builder.Property(e => e.Mail)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasMaxLength(122)
                .IsUnicode(false);

            builder.Property(e => e.SesionActiva)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            builder.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();

            builder.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.IdPersonaNavigation)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__idPers__3B75D760");
        }
    }
}
