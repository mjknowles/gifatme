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