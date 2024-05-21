﻿using FoodTruck.Application.Common.Interfaces;
using FoodTruck.Domain.MobileFoodFacilities;
using FoodTruck.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FoodTruck.Infrastructure.MobileFoodFacilities.Persistence;

/// <summary>
/// Repository for accessing mobile food facilities.
/// </summary>
internal class MobileFoodFacilitiesRepository(
    FoodTruckDbContext dbContext) 
    : IMobileFoodFacilityRepository
{
    /// <summary>
    /// Retrieves a list of all mobile food facilities asynchronously.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a list of <see cref="MobileFoodFacility"/> objects if successful;
    /// otherwise, a null value.
    /// </returns>
    public async Task<List<MobileFoodFacility>?> ListAsync() => 
        await dbContext.MobileFoodFacilities.ToListAsync();

    /// <summary>
    /// Retrieves a mobile food facility by its location ID asynchronously.
    /// </summary>
    /// <param name="locationId">The location ID of the mobile food facility.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="MobileFoodFacility"/> object if successful;
    /// otherwise, a null value.
    /// </returns>
    public async Task<MobileFoodFacility?> GetByLocationId(int locationId) =>
        await dbContext.MobileFoodFacilities
            .Where(mff => mff.LocationId == locationId)
            .FirstOrDefaultAsync();

    /// <summary>
    /// Retrieves a list of mobile food facilities by applicant asynchronously.
    /// </summary>
    /// <param name="applicant">The name of the applicant.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a list of <see cref="MobileFoodFacility"/> objects if successful;
    /// otherwise, a null value.
    /// </returns>
    public async Task<List<MobileFoodFacility>?> GetByApplicant(string applicant) =>
        await dbContext.MobileFoodFacilities
            .Where(mff => mff.Applicant.Contains(applicant))
            .ToListAsync();
}
