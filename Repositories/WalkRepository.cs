using TrialApis.Data;
using TrialApis.Models.Domains;

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
   }
}