using System;

namespace DPA.Model
{
    public class UserLogModel
    {
        public UserLogModel(long userId, LogType logType)
        {
            UserId = userId;
            LogType = logType;
        }

        public long UserLogId { get; set; }

        public long UserId { get; set; }

        public LogType LogType { get; set; }

        public string Content { get; set; }

        public DateTime DateTime { get; set; }
    }
}