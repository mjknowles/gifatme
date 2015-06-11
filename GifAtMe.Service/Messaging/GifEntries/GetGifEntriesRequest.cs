namespace GifAtMe.Service.Messaging.GifEntries
{
    public class GetGifEntriesRequest : UserIdRequest
    {
        private string _keyword;

        public GetGifEntriesRequest(string userId, string uIdSource, string keyword)
            : base(userId, uIdSource)
        {
            _keyword = keyword;
        }

        public string Keyword { get { return _keyword; } }
    }
}