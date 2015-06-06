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
        public string SlackUserId { get; set; }
        public string SlackUserName { get; set; }
        public string SlackTeamId { get; set; }
        public string SlackTeamName { get; set; }
        public string SlackTeamUrl { get; set; }

        public virtual ICollection<GifEntryDb> GifEntries { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserDb> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("UserId", SlackUserId));
            return userIdentity;
        }
    }
}
