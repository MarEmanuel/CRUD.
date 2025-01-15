using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Persistences.Contexts.Configurations
{
    public class RolRolOpcionesConfiguration : IEntityTypeConfiguration<RolRolOpciones>
    {
        public void Configure(EntityTypeBuilder<RolRolOpciones> builder)
        {
            builder.HasNoKey();

            builder.ToTable("Rol_RolOpciones");

            builder.Property(e => e.RolIdRol).HasColumnName("Rol_idRol");

            builder.Property(e => e.RolOpcionesIdOpciones).HasColumnName("RolOpciones_idOpciones");

            builder.HasOne(d => d.RolIdRolNavigation)
                .WithMany()
                .HasForeignKey(d => d.RolIdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rol_RolOp__Rol_i__44FF419A");

            builder.HasOne(d => d.RolOpcionesIdOpcionesNavigation)
                .WithMany()
                .HasForeignKey(d => d.RolOpcionesIdOpciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rol_RolOp__RolOp__45F365D3");
        }
    }
}
