using System;
using System.Collections.Generic;
using System.Text;

namespace DPA.Model
{
    public class UserEntity : BaseEntity
    {
        public long UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Roles Roles { get; set; }

        public Status Status { get; set; }

        public Title Title { get; set; }


        public virtual ICollection<UserLogEntity> UsersLogs { get; set; } = new HashSet<UserLogEntity>(); //LOG

        public virtual ICollection<ConstraintEntity> Constraints { get; set; } = new HashSet<ConstraintEntity>();

        public virtual ICollection<UserLessonEntity> UserLessons { get; set; } = new HashSet<UserLessonEntity>();

        public virtual ICollection<UnitLessonEntity> UnitLessons { get; set; } = new HashSet<UnitLessonEntity>();
    }
}
