using ErrorOr;
using FluentAssertions;
using FoodTruck.Application.Common.Interfaces;
using FoodTruck.Application.MobileFoodFacilities.Queries;
using FoodTruck.Domain.MobileFoodFacilities;
using Moq;

namespace FoodTruck.Application.Tests.MobileFoodFacilities.Queries;

public class GetByNameQueryHandlerTests
{
    private readonly Mock<IMobileFoodFacilityRepository> _repositoryMock;
    private readonly GetByNameQueryHandler _handler;

    public GetByNameQueryHandlerTests()
    {
        _repositoryMock = new Mock<IMobileFoodFacilityRepository>();
        _handler = new GetByNameQueryHandler(_repositoryMock.Object);
    }
    
    [Fact]
    public async Task Handle_ShouldReturnListOfMobileFoodFacility_WhenApplicantExists()
    {
        // Arrange
        var query = new GetByNameQuery("ApplicantName");
        var cancellationToken = new CancellationToken();
        var expectedFoodFacilities = new List<MobileFoodFacility>();
        expectedFoodFacilities.Add(new MobileFoodFacility
        {
            LocationId = 1, 
            Applicant = "ApplicantName"
        });
        expectedFoodFacilities.Add(new MobileFoodFacility
        {
            LocationId = 2, 
            Applicant = "ApplicantName"
        });

        _repositoryMock.Setup(r => r.GetByApplicant(query.Applicant))
            .ReturnsAsync(expectedFoodFacilities);

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        result.Value.Should().BeEquivalentTo(expectedFoodFacilities);
    }

    [Fact]
    public async Task Handle_ShouldReturnError_WhenApplicantDoesNotExist()
    {
        // Arrange
        var query = new GetByNameQuery("ApplicantName");
        var cancellationToken = new CancellationToken();
        List<MobileFoodFacility> nullFoodFacility = null!;
        
        _repositoryMock.Setup(r => r.GetByApplicant(query.Applicant))
            .ReturnsAsync(nullFoodFacility);
        
        // Act
        var result = await _handler.Handle(query, cancellationToken);
        
        // Assert
        result.FirstError.Should().Be(Error.NotFound(
            description: "No food trucks or carts found"));
    }
}
