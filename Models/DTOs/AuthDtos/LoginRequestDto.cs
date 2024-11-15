using System.ComponentModel.DataAnnotations;

namespace TrialApis.Models.DTOs.AuthDtos
{
   public class LoginRequestDto
   {
      [Required]
      [DataType(DataType.EmailAddress)]

      public string Username { get; set; }

      [Required]
      [DataType(DataType.Password)]
      public string Password { get; set; }
   }
}