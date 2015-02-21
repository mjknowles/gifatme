using GifAtMe.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Service.Messaging.GifEntries
{
    public class UpdateGifEntryRequest : BaseGifEntryRequest
    {
        public UpdateGifEntryRequest(int gifEntryId) : base(gifEntryId) { }
        public UpdateGifEntryRequest(string userName, string keyword, int alternateIndex) : base(userName, keyword, alternateIndex) { }
        public UpdateGifEntryRequest(int id, string userName, string keyword, int alternateIndex) : base(id, userName, keyword, alternateIndex) { }

        public GifEntryDTOProperties GifEntryProperties { get; set; }
    }
}
