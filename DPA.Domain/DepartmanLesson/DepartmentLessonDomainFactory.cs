using DPA.Model;

namespace DPA.Domain
{
    public static class DepartmentLessonDomainFactory
    {
        public static DepartmentLessonDomain Create(DepartmentLessonEntity DepartmentLessonEntity)
        {
            return new DepartmentLessonDomain(
                DepartmentLessonEntity.DepartmentLessonId,
                DepartmentLessonEntity.LessonId,
                DepartmentLessonEntity.DepartmentId
                //DepartmentLessonEntity.CreatedDate
            );
        }

        public static DepartmentLessonDomain Create(AddDepartmentLessonModel addDepartmentLessonModel)
        {
            return new DepartmentLessonDomain(
                addDepartmentLessonModel.LessonId,
                addDepartmentLessonModel.DepartmentId

            );
        }


    }
}