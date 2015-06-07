namespace GifAtMe.Service.Messaging.GifEntries
{
    public class DeleteGifEntryRequest : BaseGifEntryRequest
    {
        public DeleteGifEntryRequest(int gifEntryId)
            : base(gifEntryId)
        {
        }

        public DeleteGifEntryRequest(string userId, string userIdSource, string keyword, int alternateIndex)
            : base(userId, userIdSource, keyword, alternateIndex)
        {
        }

        public DeleteGifEntryRequest(int id, string userId, string userIdSource, string keyword, int alternateIndex)
            : base(id, userId, userIdSource, keyword, alternateIndex)
        {
        }
    }
}