using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Service.Messaging.GifEntries
{
    public abstract class BaseGifEntryRequest : IntegerIdRequest
    {
        private string _userName;
        private string _keyword;
        private int _alternateIndex;
        public string UserName { get { return _userName; } }
        public string Keyword { get { return _keyword; } }
        public int AlternateIndex { get { return _alternateIndex; } }
        
        public BaseGifEntryRequest(int gifEntryId) : base(gifEntryId) { }
        public BaseGifEntryRequest(string userName, string keyword, int alternateIndex) : base(0) 
        {
            SetProperties(userName, keyword, alternateIndex);
        }
        public BaseGifEntryRequest(int id, string userName, string keyword, int alternateIndex)
            : base(id)
        {
            SetProperties(userName, keyword, alternateIndex);
        }
        
        private void SetProperties(string userName, string keyword, int alternateIndex)
        {
            if (String.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("UserName cannot be empty.");
            }
            if (String.IsNullOrEmpty(keyword))
            {
                throw new ArgumentException("Keyword cannot be empty.");
            }
            _userName = userName;
            _keyword = keyword;
            _alternateIndex = alternateIndex;
        }
    }
}
