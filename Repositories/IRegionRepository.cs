using TrialApis.Models.Domains;
using TrialApis.Models.DTOs;

namespace TrialApis.Repositories
{
   public interface IRegionRepository
   {
      Task<List<Region>> GetAllAsync();

      Task<Region?> GetRegionByIdAsync(Guid id);

      Task<Region> CreateAsync(Region region);

      Task<Region?> UpdateRegionAsync(Guid id, Region region);

      Task<Region?> DeleteRegionAsync(Guid id);
   }
}