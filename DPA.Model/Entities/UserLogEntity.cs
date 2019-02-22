using DPA.Model.Enums;
using System;

namespace DPA.Model.Entities
{
    public class UserLogEntity: BaseEntity
    {
        public LogType LogType { get; set; }

        public string Content { get; set; }

        public long UserId { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
