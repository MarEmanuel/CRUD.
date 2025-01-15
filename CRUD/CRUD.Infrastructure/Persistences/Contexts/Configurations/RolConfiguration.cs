using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Persistences.Contexts.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasKey(e => e.IdRol)
                    .HasName("PK__Roles__3C872F76F79038CE");

            builder.Property(e => e.IdRol)
                .ValueGeneratedNever()
                .HasColumnName("idRol");

            builder.Property(e => e.RolName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasMany(d => d.IdUsuarios)
                .WithMany(p => p.IdRols)
                .UsingEntity<Dictionary<string, object>>(
                    "RolUsuario",
                    l => l.HasOne<Usuario>().WithMany().HasForeignKey("IdUsuario").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Rol_Usuar__idUsu__412EB0B6"),
                    r => r.HasOne<Rol>().WithMany().HasForeignKey("IdRol").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Rol_Usuar__idRol__403A8C7D"),
                    j =>
                    {
                        j.HasKey("IdRol", "IdUsuario").HasName("PK__Rol_Usua__4AC25D4C94008118");

                        j.ToTable("Rol_Usuarios");

                        j.IndexerProperty<int>("IdRol").HasColumnName("idRol");

                        j.IndexerProperty<int>("IdUsuario").HasColumnName("idUsuario");
                    });
        }
    }
}
