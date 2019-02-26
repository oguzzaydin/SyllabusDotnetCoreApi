using DPA.Model;

namespace DPA.Domain
{
    public static class UserLogDomainFactory
    {
        public static UserLogDomain Create(UserLogModel userLogModel)
        {
            return new UserLogDomain
            (
                userLogModel.UserLogId,
                userLogModel.UserId,
                userLogModel.LogType,
                userLogModel.Content,
                userLogModel.DateTime
            );
        }
    }
}
