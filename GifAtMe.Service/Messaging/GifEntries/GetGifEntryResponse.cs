using GifAtMe.Service.DTOs;

namespace GifAtMe.Service.Messaging.GifEntries
{
    public class GetGifEntryResponse : ServiceResponseBase
    {
        public GifEntryDTO GifEntry { get; set; }
    }
}