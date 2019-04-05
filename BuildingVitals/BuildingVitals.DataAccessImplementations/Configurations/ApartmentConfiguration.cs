using BuildingVitals.DataAccessContracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingVitals.DataAccessImplementations.Configurations
{
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Floor).IsRequired();
            builder.Property(a => a.Number).IsRequired();

            builder.HasOne(a => a.Building)
                .WithMany(a => a.Apartments)
                .HasForeignKey(b => b.BuildingId);
        }
    }
}
