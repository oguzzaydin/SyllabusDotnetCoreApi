using System;
using DPA.Model;

namespace DPA.Domain
{
    public class DepartmanLessonDomain
    {
        protected internal DepartmanLessonDomain(long lessonId, long departmanId)
        {
            DepartmanId = departmanId;
            LessonId = lessonId;
        }

        protected internal DepartmanLessonDomain(
            long departmanLessonId, 
            long lessonId, 
            long departmanId
            //DateTime createdDate
            )
        {
            DepartmanLessonId = departmanLessonId;
            LessonId = lessonId;
            DepartmanId = departmanId;
            CreatedDate = DateTime.Now;
        }

        public long DepartmanLessonId { get; set; }

        public long LessonId { get; set; }

        public long DepartmanId { get; set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime UpdatedDate { get; private set; }

        public void Update(UpdateDepartmanLessonModel updateDepartmanLessonModel) 
        {
            LessonId = updateDepartmanLessonModel.LessonId;
            DepartmanId = updateDepartmanLessonModel.DepartmanId;
            UpdatedDate = DateTime.Now;
        }
    }
}
