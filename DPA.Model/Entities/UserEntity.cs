﻿using System.Collections.Generic;

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

        public virtual ConstraintEntity Constraint { get; set; }
        public virtual ICollection<UserLogEntity> UsersLogs { get; set; } = new HashSet<UserLogEntity>(); //LOG
        public virtual ICollection<UserLessonEntity> UserLessons { get; set; } = new HashSet<UserLessonEntity>();
        public virtual ICollection<DepartmentInstructorEntity> DepartmentInstructors { get; set; } = new HashSet<DepartmentInstructorEntity>();
        public virtual ICollection<UnitLessonEntity> UnitLessons { get; set; } = new HashSet<UnitLessonEntity>();
    }
}