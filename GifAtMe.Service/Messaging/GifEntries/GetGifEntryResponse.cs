using GifAtMe.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Service.Messaging.GifEntries
{
    public class GetGifEntryResponse : ServiceResponseBase
    {
        public GifEntryDTO GifEntry { get; set; }
    }
}
