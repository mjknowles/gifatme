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
            if (String.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("User name cannot be empty.");
            }
            _userName = userName;
        }

        public string UserName { get { return _userName; } }
    }
}
