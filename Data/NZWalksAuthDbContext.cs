using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TrialApis.Data
{
   public class NZWalksAuthDbContext : IdentityDbContext
   {
      public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
      {

      }
   }
}