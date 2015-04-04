using GifAtMe.Service.DTOs;
using System.Collections.Generic;

namespace GifAtMe.Service.Messaging.GifEntries
{
    public class GetGifEntriesResponse : ServiceResponseBase
    {
        public IEnumerable<GifEntryDTO> GifEntries { get; set; }
    }
}