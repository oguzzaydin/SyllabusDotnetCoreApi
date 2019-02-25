using System;
using DPA.Model;

namespace DPA.Domain
{
    public class UserLessonDomain
    {
        protected internal UserLessonDomain(long userId, long lessonId) {
            UserId = userId;
            LessonId = lessonId;
        }

        protected internal UserLessonDomain(
          long userLessonId,
          long userId,
          long lessonId  
        ) {
            UserLessonId = userLessonId;
            UserId = userId;
            LessonId = lessonId;
            CreatedDate = DateTime.Now;
        }

        public long UserLessonId { get; private set; }
        
        public long UserId { get; private set; }

        public long LessonId { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime UpdatedDate { get; private set; }

        public void Update(UpdateUserLessonModel updateUserLessonModel) {
            UserId = updateUserLessonModel.UserId;
            LessonId = updateUserLessonModel.LessonId;
            UpdatedDate = DateTime.Now;
        }
    }
}
