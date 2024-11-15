using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TrialApis.Data
{
   public class NZWalksAuthDbContext : IdentityDbContext
   {
      public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
      {

      }

      protected override void OnModelCreating(ModelBuilder builder)
      {
         base.OnModelCreating(builder);

         var readerRoleId = "e1a1b2c3-d4e5-6789-0abc-def123456789";
         var writerRoleId = "f1a2b3c4-d5e6-7890-1abc-def234567890";

         var roles = new List<IdentityRole>{
            new IdentityRole{
               Id = readerRoleId,
               ConcurrencyStamp = readerRoleId,
               Name = "Reader",
               NormalizedName = "Reader".ToUpper()

            },
            new IdentityRole{
               Id=writerRoleId,
               ConcurrencyStamp = writerRoleId,
               Name = "Writer",
               NormalizedName = "Writer"
            }
         };

         builder.Entity<IdentityRole>().HasData(roles);
      }
   }
}