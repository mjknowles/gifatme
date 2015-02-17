using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Service.Messaging.GifEntries
{
    public class GetGifEntryByNonIdRequest : UserNameRequest
    {
        private string _keyword;
        private int _alternateId;

        public string Keyword { get { return _keyword; } }
        public int AlternateId { get { return _alternateId; } }

        public GetGifEntryByNonIdRequest(string userName, string keyword, int alternateId)
            : base(userName) 
        {
            if (String.IsNullOrEmpty(keyword))
            {
                throw new ArgumentException("Keyword cannot be empty.");
            }
            if (alternateId < 1)
            {
                throw new ArgumentException("Alternate ID must be greater than 0.");
            }
            _keyword = keyword;
            _alternateId = alternateId;
        }
    }
}
