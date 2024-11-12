using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TrialApis.Data;
using TrialApis.Models.Domains;
using TrialApis.Models.DTOs;

namespace TrialApis.Repositories
{
   public class RegionRepository : IRegionRepository
   {
      private readonly NZWalksDbContext _dbContext;
      public RegionRepository(NZWalksDbContext dbContext)
      {
         _dbContext = dbContext;
      }

      public async Task<List<Region>> GetAllAsync()
      {
         return await _dbContext.Regions.ToListAsync();
      }

      public async Task<Region?> GetRegionByIdAsync(Guid id)
      {
         return await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
      }

      public async Task<Region> CreateAsync(Region region)
      {
         await _dbContext.Regions.AddAsync(region);
         await _dbContext.SaveChangesAsync();
         return region;
      }

      public async Task<Region?> UpdateRegionAsync(Guid id, Region region)
      {
         var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

         if (existingRegion == null)
         {
            return null;
         }

         existingRegion.Code = region.Code;
         existingRegion.Name = region.Name;
         existingRegion.RegionImageUrl = region.RegionImageUrl;

         await _dbContext.SaveChangesAsync();
         return existingRegion;
      }

      public async Task<Region?> DeleteRegionAsync(Guid id)
      {
         var region = await _dbContext.Regions.FindAsync(id);

         if (region == null)
         {
            return null;
         }

         _dbContext.Regions.Remove(region);
         await _dbContext.SaveChangesAsync();
         return region;
      }
   }
}