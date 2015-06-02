namespace GifAtMe.Service.Messaging
{
    public class UserIdRequest : ServiceRequestBase
    {
        private string _userId;
        private string _userIdSource;

        public UserIdRequest(string userId, string uIdSource)
        {
            _userId = userId;
            _userIdSource = uIdSource;
        }

        public string UserId { get { return _userId; } }
        public string UserIdSource { get { return _userIdSource; } }
    }
}