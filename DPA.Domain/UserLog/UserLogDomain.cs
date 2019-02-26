using DPA.Model;
using System;

namespace DPA.Domain
{
    public class UserLogDomain
    {
        protected internal UserLogDomain
        (
            long userLogId,
            long userId,
            LogType logType,
            string content,
            DateTime dateTime
        )
        {
            UserLogId = userLogId;
            UserId = userId;
            LogType = logType;
            Content = content;
            DateTime = dateTime;
        }

        public string Content { get; private set; }

        public DateTime DateTime { get; private set; }

        public LogType LogType { get; private set; }

        public long UserId { get; private set; }

        public long UserLogId { get; private set; }

        public void Add()
        {
            DateTime = DateTime.Now;
        }
    }
}
