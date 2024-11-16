using Microsoft.AspNetCore.Identity;

namespace TrialApis.Repositories
{
   public interface ITokenRepository
   {
      string CreateJWTToken(IdentityUser user, List<string> roles);
   }
}