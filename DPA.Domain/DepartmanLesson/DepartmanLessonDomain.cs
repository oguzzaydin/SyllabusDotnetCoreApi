using System;

namespace DPA.Domain
{
    public class DepartmanLessonDomain
    {
        protected internal DepartmanLessonDomain(long lessonId, long departmanId)
        {
            DepartmanId = departmanId;
            LessonId = lessonId;
        }

        protected internal DepartmanLessonDomain(long departmanLessonId, long lessonId, long departmanId)
        {
            DepartmanLessonId = departmanLessonId;
            LessonId = lessonId;
            DepartmanId = departmanId;
        }


        public long DepartmanLessonId { get; set; }

        public long LessonId { get; set; }

        public long DepartmanId { get; set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime UpdatedDate { get; private set; }
    }
}