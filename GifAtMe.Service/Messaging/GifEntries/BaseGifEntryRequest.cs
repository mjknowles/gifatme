using System;

namespace GifAtMe.Service.Messaging.GifEntries
{
    public abstract class BaseGifEntryRequest : IntegerIdRequest
    {
        private string _userId;
        private string _userIdSource;
        private string _keyword;
        private int _alternateIndex;

        public string UserId { get { return _userId; } }

        public string UserIdSource { get { return _userIdSource; } }

        public string Keyword { get { return _keyword; } }

        public int AlternateIndex { get { return _alternateIndex; } }

        public BaseGifEntryRequest(int gifEntryId)
            : base(gifEntryId)
        {
        }

        public BaseGifEntryRequest(string userId, string userIdSource, string keyword, int alternateIndex)
            : base(0)
        {
            SetProperties(userId, userIdSource, keyword, alternateIndex);
        }

        public BaseGifEntryRequest(int id, string userId, string userIdSource, string keyword, int alternateIndex)
            : base(id)
        {
            SetProperties(userId, userIdSource, keyword, alternateIndex);
        }

        private void SetProperties(string userId, string userIdSource, string keyword, int alternateIndex)
        {
            if (String.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("UserId cannot be empty.");
            }
            if (String.IsNullOrEmpty(keyword))
            {
                throw new ArgumentException("Keyword cannot be empty.");
            }
            _userId = userId;
            _userIdSource = userIdSource;
            _keyword = keyword;
            _alternateIndex = alternateIndex;
        }
    }
}