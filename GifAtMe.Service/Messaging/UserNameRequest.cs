using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Service.Messaging
{
    public class UserNameRequest : ServiceRequestBase
    {
        private string _userName;

        public UserNameRequest(string userName)
        {
            _userName = userName;
        }

        public string UserName { get { return _userName; } }
    }
}
