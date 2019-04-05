using BuildingVitals.DataAccessContracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingVitals.DataAccessImplementations.Configurations
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Address).IsRequired();


            builder.HasMany(b => b.Apartments)
                .WithOne(a => a.Building)
                .OnDelete(DeleteBehavior.Restrict); ;

        }
    }
}
