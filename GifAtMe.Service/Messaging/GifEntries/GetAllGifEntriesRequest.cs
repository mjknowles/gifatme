using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Service.Messaging.GifEntries
{
    public class GetAllGifEntriesRequest: UserNameRequest
    {
        private string _keyword;

        public GetAllGifEntriesRequest(string userName, string keyword) : base(userName) 
        {
            _keyword = keyword;
        }

        public string Keyword { get { return _keyword; } }
    }
}
