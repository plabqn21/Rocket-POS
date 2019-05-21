using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RamsoftBD.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }

        
        public Guid? BranchId { get; set; }
        [Required]

        public string Role { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("BranchId", this.BranchId.ToString()));
            userIdentity.AddClaim(new Claim("Name", this.Name));
            userIdentity.AddClaim(new Claim("Role", this.Role));
            userIdentity.AddClaim(new Claim("Id", this.Id));
            userIdentity.AddClaim(new Claim("Email", this.Email));
            return userIdentity;
        }






    }
}