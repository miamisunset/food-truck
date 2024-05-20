using FoodTruck.Domain.MobileFoodFacilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodTruck.Infrastructure.MobileFoodFacilities.Persistence;

public class MobileFoodFacilityConfiguration : IEntityTypeConfiguration<MobileFoodFacility>
{
    public void Configure(EntityTypeBuilder<MobileFoodFacility> builder)
    {
        builder.HasKey(e => e.LocationId);

        builder.Property(e => e.FacilityType)
            .HasConversion(
                facilityType => facilityType!.Name,
                value => FacilityType.FromName(value, false));

        builder.Property(e => e.Status)
            .HasConversion(
                status => status!.Name,
                value => Status.FromName(value, false));
    }
}
