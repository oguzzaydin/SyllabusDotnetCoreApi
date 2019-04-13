using System;
namespace DPA.Database.Exceptions
{
    public class UserFriendlyException : DpaException
    {
        public UserFriendlyException(string message) : base(400, message)
        {

        }
    }
}
