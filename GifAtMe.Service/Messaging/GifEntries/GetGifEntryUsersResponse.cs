using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Service.Messaging.GifEntries
{
    public class GetGifEntryUsersResponse : ServiceResponseBase
    {
        public IEnumerable<string> Users { get; set; }
    }
}
