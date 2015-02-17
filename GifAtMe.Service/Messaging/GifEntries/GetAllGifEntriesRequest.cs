using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Service.Messaging.GifEntries
{
    public class GetAllGifEntriesRequest: UserNameRequest
    {
        public GetAllGifEntriesRequest(string userName) : base(userName) { }
    }
}
