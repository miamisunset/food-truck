using ErrorOr;
using FluentAssertions;
using FoodTruck.Application.Common.Interfaces;
using FoodTruck.Application.MobileFoodFacilities.Queries;
using FoodTruck.Domain.MobileFoodFacilities;
using Moq;

namespace FoodTruck.Application.Tests.MobileFoodFacilities.Queries;

public class GetAllQueryHandlerTest
{
    private readonly Mock<IMobileFoodFacilityRepository> _repositoryMock;
    private readonly GetAllQueryHandler _handler;

    public GetAllQueryHandlerTest()
    {
        _repositoryMock = new Mock<IMobileFoodFacilityRepository>();
        _handler = new GetAllQueryHandler(_repositoryMock.Object);
    }
    
    [Fact]
    public async Task Handle_Returns_ListOfMobileFoodFacility_WhenExist()
    {
        // Arrange
        var query = new GetAllQuery(1, 10);
        var expectedFoodFacilities = new List<MobileFoodFacility>
        {
            new() { LocationId = 1, Applicant = "ApplicantName" },
            new() { LocationId = 2, Applicant = "ApplicantName1" }
        };

        _repositoryMock.Setup(r => r.ListAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(expectedFoodFacilities);

        // Act
        var result = await _handler.Handle(query, It.IsAny<CancellationToken>());

        // Assert
        result.Value.Should().BeEquivalentTo(expectedFoodFacilities);
    }
    
    [Fact]
    public async Task Handle_Returns_Error_When_NoneExist()
    {
        // Arrange
        var query = new GetAllQuery(1, 10);
        List<MobileFoodFacility> nullFoodFacility = null;

        _repositoryMock.Setup(r => r.ListAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(nullFoodFacility);
        
        // Act
        var result = await _handler.Handle(query, It.IsAny<CancellationToken>());
        
        // Assert
        result.FirstError.Should().Be(Error.NotFound(
            description: "No food trucks or carts found"));
    }
}
