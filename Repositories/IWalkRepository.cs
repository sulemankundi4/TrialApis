using TrialApis.Models.Domains;
using TrialApis.Models.DTOs;

namespace TrialApis.Repositories
{
   public interface IWalkRepository
   {
      Task<Walk> AddWalkAsync(Walk walk);
      Task<List<Walk>> GetAllWalksAsync();
      Task<Walk?> GetSingleWalkAsync(Guid id);

      Task<Walk?> UpdateWalkByIdAsync(Guid id, Walk walk);

      Task<Walk?> DeleteWalkAsync(Guid id);
   }
}