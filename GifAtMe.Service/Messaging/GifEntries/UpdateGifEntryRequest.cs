using GifAtMe.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Service.Messaging.GifEntries
{
    public class UpdateGifEntryRequest : IntegerIdRequest
    {
        public UpdateGifEntryRequest(int gifEntryId) : base(gifEntryId) { }
        public GifEntryPropertiesDTO GifEntryProperties { get; set; }
    }
}
