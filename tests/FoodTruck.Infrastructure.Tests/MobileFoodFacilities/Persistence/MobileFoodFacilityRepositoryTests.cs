using FoodTruck.Application.Common.Interfaces;
using FoodTruck.Domain.MobileFoodFacilities;
using FoodTruck.Infrastructure.Common.Persistence;
using FoodTruck.Infrastructure.MobileFoodFacilities.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FoodTruck.Infrastructure.Tests.MobileFoodFacilities.Persistence;

public class MobileFoodFacilityRepositoryTests
{
    private readonly FoodTruckDbContext _context;
    private readonly IMobileFoodFacilityRepository _repository;

    public MobileFoodFacilityRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<FoodTruckDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _context = new FoodTruckDbContext(options);
        _repository = new MobileFoodFacilitiesRepository(_context);

        // Add initial data
        _context.Add(new MobileFoodFacility()
        {
            LocationId = 1, 
            Applicant = "TestApplicant1"
        });
        _context.Add(new MobileFoodFacility()
        {
            LocationId = 2, 
            Applicant = "TestApplicant2"
        });
        
        _context.SaveChanges();
    }

    [Fact]
    public async Task ListAsync_ShouldReturnAllFacilities_WhenFacilitiesExist()
    {
        // Act
        var result = await _repository.ListAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetByLocationId_ShouldReturnFacility_WhenIdExists()
    {
        // Arrange
        var locationId = 1;

        // Act
        var result = await _repository.GetByLocationId(locationId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(locationId, result.LocationId);
    }

    [Fact]
    public async Task GetByApplicant_ShouldReturnFacility_WhenApplicantExists()
    {
        // Arrange
        var applicant = "TestApplicant1";

        // Act
        var result = await _repository.GetByApplicant(applicant);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(applicant, result.First().Applicant);
    }
    
    public void Dispose()
    {
        _context.Database.EnsureDeleted();
    }
}
