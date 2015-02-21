using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Service.Messaging.GifEntries
{
    public class GetGifEntryRequest : BaseGifEntryRequest
    {
        public GetGifEntryRequest(int gifEntryId) : base(gifEntryId) { }
        public GetGifEntryRequest(string userName, string keyword, int alternateIndex) : base(userName, keyword, alternateIndex) { }
        public GetGifEntryRequest(int id, string userName, string keyword, int alternateIndex) : base(id, userName, keyword, alternateIndex) { }
    }
}
