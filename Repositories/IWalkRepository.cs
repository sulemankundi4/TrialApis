using TrialApis.Models.Domains;
using TrialApis.Models.DTOs;

namespace TrialApis.Repositories
{
   public interface IWalkRepository
   {
      Task<Walk> AddWalkAsync(Walk walk);
      Task<List<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageSize = 1, int pageNumber = 1000);
      Task<Walk?> GetSingleWalkAsync(Guid id);
      Task<Walk?> UpdateWalkByIdAsync(Guid id, Walk walk);
      Task<Walk?> DeleteWalkAsync(Guid id);
   }
}