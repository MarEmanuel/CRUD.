using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Persistences.Contexts.Configurations
{
    public class PermisoConfiguration : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.HasNoKey();

            builder.Property(e => e.NombreRol)
                .HasColumnName("NombreRol");

            builder.Property(e => e.NombrePermiso)
                .HasColumnName("NombrePermiso");

            builder.Property(e => e.RutaPermiso)
                .HasColumnName("RutaPermiso");

            builder.Property(e => e.DescripcionPermiso)
                .HasColumnName("DescripcionPermiso");

            builder.Property(e => e.IconoPermiso)
                .HasColumnName("IconoPermiso");
        }
    }
}
