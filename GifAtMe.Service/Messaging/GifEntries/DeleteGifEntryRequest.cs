namespace GifAtMe.Service.Messaging.GifEntries
{
    public class DeleteGifEntryRequest : BaseGifEntryRequest
    {
        public DeleteGifEntryRequest(int gifEntryId)
            : base(gifEntryId)
        {
        }

        public DeleteGifEntryRequest(string userName, string keyword, int alternateIndex)
            : base(userName, keyword, alternateIndex)
        {
        }

        public DeleteGifEntryRequest(int id, string userName, string keyword, int alternateIndex)
            : base(id, userName, keyword, alternateIndex)
        {
        }
    }
}