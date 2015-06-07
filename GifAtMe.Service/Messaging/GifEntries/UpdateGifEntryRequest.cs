using GifAtMe.Service.DTOs;

namespace GifAtMe.Service.Messaging.GifEntries
{
    public class UpdateGifEntryRequest : BaseGifEntryRequest
    {
        public UpdateGifEntryRequest(int gifEntryId)
            : base(gifEntryId)
        {
        }

        public UpdateGifEntryRequest(string userId, string userIdSource, string keyword, int alternateIndex)
            : base(userId, userIdSource, keyword, alternateIndex)
        {
        }

        public UpdateGifEntryRequest(int id, string userId, string userIdSource, string keyword, int alternateIndex)
            : base(id, userId, userIdSource, keyword, alternateIndex)
        {
        }

        public GifEntryDTOProperties GifEntryProperties { get; set; }
    }
}