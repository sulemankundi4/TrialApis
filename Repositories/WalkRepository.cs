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

      public async Task<List<Walk>> GetAllWalksAsync()
      {
         var AllWalksDomain = await _dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
         return AllWalksDomain;
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