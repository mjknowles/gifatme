using System;

namespace GifAtMe.Service.Messaging
{
    public abstract class IntegerIdRequest : ServiceRequestBase
    {
        private int _id;

        public IntegerIdRequest(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("ID must be 0 or positive.");
            }
            _id = id;
        }

        public int Id { get { return _id; } }
    }
}