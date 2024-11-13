using System.ComponentModel.DataAnnotations;

namespace TrialApis.Models.DTOs
{
   public class UpdateWalkRequestDto
   {
      [Required]
      [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 characters")]
      public string Name { get; set; }
      [Required]
      [MaxLength(500, ErrorMessage = "Description has to be a maximum of 100 characters")]
      public string Description { get; set; }
      [Required]
      [Range(0, 50)]
      public double LengthInKm { get; set; }
      public string? WalkImageUrl { get; set; }
      [Required]
      public Guid DifficultyId { get; set; }
      [Required]
      public Guid RegionId { get; set; }
   }
}