using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TrialApis.Models.Domains;
using TrialApis.Models.DTOs;
using TrialApis.Repositories;

namespace TrialApis.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ImageController : ControllerBase
   {
      private readonly IImageRepository _imageRepository;
      public ImageController(IImageRepository imageRepository)
      {
         _imageRepository = imageRepository;
      }

      [HttpPost]
      [Route("Upload")]
      public async Task<IActionResult> Upload([FromForm] ImagesRequestDto imagesRequestDto)
      {
         ValidateFileUpload(imagesRequestDto);
         if (ModelState.IsValid)
         {
            var imageDomainModel = new Image
            {
               File = imagesRequestDto.File,
               FileExtension = Path.GetExtension(imagesRequestDto.File.FileName),
               FileSizeInBytes = imagesRequestDto.File.Length,
               FileName = imagesRequestDto.FileName,
               FileDescription = imagesRequestDto.FileDescription
            };

            //user repository to upload image
            await _imageRepository.Upload(imageDomainModel);
            return Ok(imageDomainModel);
         }

         return BadRequest(ModelState);
      }

      private void ValidateFileUpload(ImagesRequestDto imagesRequestDto)
      {
         var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
         if (!allowedExtensions.Contains(Path.GetExtension(imagesRequestDto.File.FileName)))
         {
            ModelState.AddModelError("file", "Unsupported File type!");
         }

         if (imagesRequestDto.File.Length > 10485760)
         {
            ModelState.AddModelError("file", "File size should be less than 10MB");
         }
      }
   }
}