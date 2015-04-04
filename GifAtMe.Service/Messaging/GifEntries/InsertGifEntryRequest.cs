using GifAtMe.Service.DTOs;

namespace GifAtMe.Service.Messaging.GifEntries
{
    public class InsertGifEntryRequest : ServiceRequestBase
    {
        public GifEntryDTOProperties GifEntryDTOProperties { get; set; }
    }
}