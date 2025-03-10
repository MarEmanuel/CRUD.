using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Persistences.Contexts.Configurations
{
    public class SesionConfiguration : IEntityTypeConfiguration<Sesion>
    {
        public void Configure(EntityTypeBuilder<Sesion> builder)
        {
            builder.HasKey(e => e.IdSesion)
                    .HasName("PK__Sesiones");

            builder.Property(e => e.IdSesion)
                .ValueGeneratedOnAdd()
                .HasColumnName("idSesion");

            builder.Property(e => e.FechaEgreso).HasColumnType("date");

            builder.Property(e => e.FechaIngreso).HasColumnType("date");

            builder.Property(e => e.SesionActiva)
                .HasMaxLength(1)
                .IsUnicode(false);

            builder.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            builder.HasOne(d => d.IdUsuarioNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sesiones__idUsua__3D5E1FD2");
        }
    }
}
