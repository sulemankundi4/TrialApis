using TrialApis.Models.Domains;

namespace TrialApis.Repositories
{
   public interface IImageRepository
   {
      Task<Image> Upload(Image image);
   }
}