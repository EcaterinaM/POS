using BuildingVitals.DataAccessContracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingVitals.DataAccessImplementations.Configurations
{
    public class MetricConfiguration : IEntityTypeConfiguration<Metric>
    {
        public void Configure(EntityTypeBuilder<Metric> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Date).IsRequired();

            builder.HasOne(a => a.Sensor)
                .WithMany(a => a.Metrics)
                .HasForeignKey(b => b.SensorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
