using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TrialApis.Models.DTOs;

namespace TrialApis.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ImageController : ControllerBase
   {
      [HttpPost]
      [Route("Upload")]
      public async Task<IActionResult> Upload([FromForm] ImagesRequestDto imagesRequestDto)
      {
         ValidateFileUpload(imagesRequestDto);
         if (ModelState.IsValid)
         {
            //user repository to upload image

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