using System;
using DPA.Model;

namespace DPA.Domain
{
    public class DepartmentLessonDomain
    {
        protected internal DepartmentLessonDomain(long lessonId, long departmentId)
        {
            DepartmentId = departmentId;
            LessonId = lessonId;
        }

        protected internal DepartmentLessonDomain(
            long departmentLessonEntity, 
            long lessonId, 
            long departmentId
            //DateTime createdDate
            )
        {
            DepartmentLessonEntity = departmentLessonEntity;
            LessonId = lessonId;
            DepartmentId = departmentId;
            CreatedDate = DateTime.Now;
        }

        public long DepartmentLessonEntity { get; set; }

        public long LessonId { get; set; }

        public long DepartmentId { get; set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime UpdatedDate { get; private set; }

        public void Update(UpdateDepartmentLessonModel updateDepartmentLessonModel) 
        {
            LessonId = updateDepartmentLessonModel.LessonId;
            DepartmentId = updateDepartmentLessonModel.DepartmentId;
            UpdatedDate = DateTime.Now;
        }
    }
}
