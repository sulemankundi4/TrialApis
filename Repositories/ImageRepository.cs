using TrialApis.Data;
using TrialApis.Models.Domains;

namespace TrialApis.Repositories
{
   public class ImageRepository : IImageRepository
   {
      private readonly IWebHostEnvironment _webHostEnvironment;
      private readonly IHttpContextAccessor _httpContextAccessor;
      private readonly NZWalksDbContext _dbContext;
      public ImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, NZWalksDbContext nzWalksDbContext)
      {
         _webHostEnvironment = webHostEnvironment;
         _httpContextAccessor = httpContextAccessor;
         _dbContext = nzWalksDbContext;
      }
      public async Task<Image> Upload(Image image)
      {
         var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", $"{image.FileName}{image.FileExtension}");

         using var stream = new FileStream(localFilePath, FileMode.Create);
         await image.File.CopyToAsync(stream);

         // https://localhost:123/images/image.jpg
         var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";
         image.FilePath = urlFilePath;

         await _dbContext.AddAsync(image);
         await _dbContext.SaveChangesAsync();

         return image;
      }
   }
}