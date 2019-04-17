using System;
namespace DPA.Core.Exceptions
{
    public class UserFriendlyException : DpaException
    {
        public UserFriendlyException(string message) : base(400, message)
        {

        }
    }
}
