using GifAtMe.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Domain.Entities.User
{
    public class User : EntityBase<int>, IAggregateRoot
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamUrl { get; set; }

        public List<GifEntry.GifEntry> GifEntries { get; set; }

        protected override void Validate()
        {
        }
    }
}
