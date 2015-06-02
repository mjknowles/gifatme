namespace GifAtMe.Service.Messaging.GifEntries
{
    public class DeleteGifEntryRequest : BaseGifEntryRequest
    {
        public DeleteGifEntryRequest(int gifEntryId)
            : base(gifEntryId)
        {
        }

        public DeleteGifEntryRequest(string userId, string keyword, int alternateIndex)
            : base(userId, keyword, alternateIndex)
        {
        }

        public DeleteGifEntryRequest(int id, string userId, string keyword, int alternateIndex)
            : base(id, userId, keyword, alternateIndex)
        {
        }
    }
}