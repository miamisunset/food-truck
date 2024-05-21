using ErrorOr;
using FoodTruck.Application.MobileFoodFacilities.Queries;
using FoodTruck.Application.Common.Interfaces;
using FoodTruck.Domain.MobileFoodFacilities;
using FluentAssertions;
using Moq;

namespace FoodTruck.Application.Tests.MobileFoodFacilities.Queries;

public class GetByLocationIdQueryHandlerTests
{
    private readonly Mock<IMobileFoodFacilityRepository> _repositoryMock;
    private readonly GetByLocationIdQueryHandler _handler;

    public GetByLocationIdQueryHandlerTests()
    {
        _repositoryMock = new Mock<IMobileFoodFacilityRepository>();
        _handler = new GetByLocationIdQueryHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnMobileFoodFacility_WhenLocationIdExists()
    {
        // Arrange
        var query = new GetByLocationIdQuery(1);
        var cancellationToken = new CancellationToken();
        var expectedFoodFacility = 
            new MobileFoodFacility { LocationId = 1, Applicant = "ApplicantName" };

        _repositoryMock.Setup(r => r.GetByLocationId(query.LocationId))
            .ReturnsAsync(expectedFoodFacility);

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        result.Value.Should().BeEquivalentTo(expectedFoodFacility);
    }

    [Fact]
    public async Task Handle_ShouldReturnError_WhenLocationIdDoesNotExist()
    {
        // Arrange
        var query = new GetByLocationIdQuery(1);
        var cancellationToken = new CancellationToken();
        MobileFoodFacility nullFoodFacility = null!;
        
        _repositoryMock.Setup(r => r.GetByLocationId(query.LocationId))
            .ReturnsAsync(nullFoodFacility);
        
        // Act
        var result = await _handler.Handle(query, cancellationToken);
        
        // Assert
        result.FirstError.Should().Be(Error.NotFound(
            $"{query.LocationId} mobile food facility not found"));
    }
}