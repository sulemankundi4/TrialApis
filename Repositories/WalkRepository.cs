using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TrialApis.Data;
using TrialApis.Models.Domains;
using TrialApis.Models.DTOs;

namespace TrialApis.Repositories
{
   class WalkRepository : IWalkRepository
   {
      private readonly NZWalksDbContext _dbContext;
      public WalkRepository(NZWalksDbContext dbContext)
      {
         _dbContext = dbContext;
      }
      public async Task<Walk> AddWalkAsync(Walk walk)
      {
         await _dbContext.Walks.AddAsync(walk);
         await _dbContext.SaveChangesAsync();
         return walk;
      }

      public async Task<List<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
      {
         var walks = _dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

         if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
         {
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
               walks = walks.Where(x => x.Name.Contains(filterQuery));
            }
         }

         // Sorting
         if (string.IsNullOrWhiteSpace(sortBy) == false)
         {
            if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
               walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
            }
            else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
            {
               walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
            }
         }

         // pagination
         var skipResults = (pageNumber - 1) * pageSize;

         return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
      }

      public async Task<Walk?> GetSingleWalkAsync(Guid id)
      {
         var checkWalkDomain = await _dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);

         if (checkWalkDomain == null)
         {
            return null;
         }

         return checkWalkDomain;
      }

      public async Task<Walk?> UpdateWalkByIdAsync(Guid id, Walk walk)
      {
         var existingWalkDomain = await _dbContext.Walks.FindAsync(id);

         if (existingWalkDomain == null)
         {
            return null;
         }

         existingWalkDomain.Description = walk.Description;
         existingWalkDomain.Name = walk.Name;
         existingWalkDomain.DifficultyId = walk.DifficultyId;
         existingWalkDomain.RegionId = walk.RegionId;
         existingWalkDomain.LengthInKm = walk.LengthInKm;
         existingWalkDomain.WalkImageUrl = walk.WalkImageUrl;

         await _dbContext.SaveChangesAsync();
         return existingWalkDomain;
      }

      public async Task<Walk?> DeleteWalkAsync(Guid id)
      {
         var existingWalk = _dbContext.Walks.Find(id);
         if (existingWalk == null)
         {
            return null;
         }

         _dbContext.Remove(existingWalk);
         await _dbContext.SaveChangesAsync();
         return existingWalk;
      }
   }
}