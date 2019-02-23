using System;

namespace DPA.Model
{
    public class UserLogEntity: BaseEntity
    {
        public LogType LogType { get; set; }

        public string Content { get; set; }

        public long UserId { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
