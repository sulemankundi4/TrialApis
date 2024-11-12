using TrialApis.Models.Domains;

namespace TrialApis.Repositories
{
   public interface IWalkRepository
   {
      Task<Walk> AddWalkAsync(Walk walk);
   }
}