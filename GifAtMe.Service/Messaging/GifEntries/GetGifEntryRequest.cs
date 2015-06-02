namespace GifAtMe.Service.Messaging.GifEntries
{
    public class GetGifEntryRequest : BaseGifEntryRequest
    {
        public GetGifEntryRequest(int gifEntryId)
            : base(gifEntryId)
        {
        }

        public GetGifEntryRequest(string userId, string uIdSource, string keyword, int alternateIndex)
            : base(userId, uIdSource, keyword, alternateIndex)
        {
        }

        public GetGifEntryRequest(int id, string userId, string uIdSource, string keyword, int alternateIndex)
            : base(id, userId, uIdSource, keyword, alternateIndex)
        {
        }
    }
}