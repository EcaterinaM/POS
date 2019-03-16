using BuildingVitals.DataAccessContracts.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingVitals.DataAccessImplementations.Configurations.Entities.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Name).IsRequired().HasMaxLength(128).IsUnicode(false);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(128).IsUnicode(false);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(128).IsUnicode(false);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(128).IsUnicode(false);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(128).IsUnicode(false);
            builder.Property(u => u.PhoneNumber).HasMaxLength(32).IsUnicode(false);

            builder.ToTable("User");
        }
    }
}
