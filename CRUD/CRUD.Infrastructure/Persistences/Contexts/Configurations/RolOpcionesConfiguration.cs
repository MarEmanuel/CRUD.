using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Persistences.Contexts.Configurations
{
    public class RolOpcionesConfiguration : IEntityTypeConfiguration<RolOpciones>
    {
        public void Configure(EntityTypeBuilder<RolOpciones> builder)
        {
            builder.HasKey(e => e.IdOpcion)
                    .HasName("PK__RolOpcio__A914DF350DEAFCD2");

            builder.Property(e => e.IdOpcion)
                .ValueGeneratedNever()
                .HasColumnName("idOpcion");

            builder.Property(e => e.NombreOpcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
