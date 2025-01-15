using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Persistences.Contexts.Configurations
{
    public class SesionConfiguration : IEntityTypeConfiguration<Sesion>
    {
        public void Configure(EntityTypeBuilder<Sesion> builder)
        {
            builder.HasNoKey();

            builder.Property(e => e.FechaCierre).HasColumnType("date");

            builder.Property(e => e.FechaIngreso).HasColumnType("date");

            builder.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            builder.HasOne(d => d.IdUsuarioNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sesiones__idUsua__3D5E1FD2");
        }
    }
}
