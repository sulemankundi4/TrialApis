using System.ComponentModel.DataAnnotations;

namespace TrialApis.Models.DTOs
{
   public class ImagesRequestDto
   {
      [Required]
      public IFormFile File { get; set; }

      [Required]
      public string FileName { get; set; }
      public string? FileDescription { get; set; }
   }
}