using BuildingVitals.DataAccessContracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingVitals.DataAccessImplementations.Configurations
{
    public class SensorConfiguration : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired();

            builder.HasOne(s => s.Apartment)
                .WithMany(a => a.Sensors)
                .HasForeignKey(s => s.ApartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
