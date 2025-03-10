using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Persistences.Contexts.Configurations
{
    public class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.HasNoKey();

            builder.Property(e => e.UserID)
                    .HasColumnName("UserID");

            builder.Property(e => e.RoleID)
                    .HasColumnName("RoleID");

            builder.Property(e => e.RoleName)
                    .HasColumnName("RoleName");

            builder.Property(e => e.SessionID)
                    .HasColumnName("SessionID");
        }
    }
}
