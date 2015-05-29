using GifAtMe.Domain.Entities.GifEntry;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Repository.DatabaseModels
{
    public class UserDb : IdentityUser
    {
        public string UserId { get; set; }
        public string TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamUrl { get; set; }

        public virtual ICollection<GifEntry> GifEntries { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserDb> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
