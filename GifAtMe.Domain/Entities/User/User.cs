using GifAtMe.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Domain.Entities.User
{
    public class User : EntityBase<string>, IAggregateRoot
    {
        public string SlackUserName { get; set; }
        public string SlackUserId { get; set; }
        public string SlackTeamId { get; set; }
        public string SlackTeamName { get; set; }
        public string SlackTeamUrl { get; set; }

        public User()
        {
            GifEntries = new List<GifEntry.GifEntry>();
        }

        public List<GifEntry.GifEntry> GifEntries { get; set; }

        protected override void Validate()
        {
        }
    }
}
