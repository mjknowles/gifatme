namespace GifAtMe.Service.Messaging.GifEntries
{
    public class GetAllGifEntriesRequest : UserIdRequest
    {
        private string _keyword;

        public GetAllGifEntriesRequest(string userId, string uIdSource, string keyword)
            : base(userId, uIdSource)
        {
            _keyword = keyword;
        }

        public string Keyword { get { return _keyword; } }
    }
}