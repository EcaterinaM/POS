using BuildingVitals.DataAccessContracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingVitals.DataAccessImplementations.Configurations
{
    public class ApartmentSensorConfiguration : IEntityTypeConfiguration<ApartmentSensor>
    {
        public void Configure(EntityTypeBuilder<ApartmentSensor> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.SensorId).IsRequired();
            builder.Property(a => a.ApartmentId).IsRequired();
        }
    }
}
