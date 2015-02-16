using GifAtMe.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Service.Messaging.GifEntries
{
    public class GetGifEntriesResponse : ServiceResponseBase
    {
        public IEnumerable<GifEntryDTO> GifEntries { get; set; }
    }
}
