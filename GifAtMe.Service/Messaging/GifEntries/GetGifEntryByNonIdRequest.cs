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
        private int? _alternateIndex;

        public string Keyword { get { return _keyword; } }
        public int? AlternateIndex { get { return _alternateIndex; } }

        public GetGifEntryByNonIdRequest(string userName, string keyword, int? AlternateIndex)
            : base(userName) 
        {
            if (String.IsNullOrEmpty(keyword))
            {
                throw new ArgumentException("Keyword cannot be empty.");
            }
            if (AlternateIndex.HasValue && AlternateIndex.Value < 1)
            {
                throw new ArgumentException("Alternate ID must be greater than 0.");
            }
            _keyword = keyword;
            _alternateIndex = AlternateIndex.Value;
        }
    }
}
