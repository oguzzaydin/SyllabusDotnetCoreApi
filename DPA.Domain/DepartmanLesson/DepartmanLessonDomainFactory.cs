using DPA.Model;

namespace DPA.Domain
{
    public static class DepartmanLessonDomainFactory
    {
        public static DepartmanLessonDomain Create(AddDepartmanLessonModel addDepartmanLessonModel)
        {
            return new DepartmanLessonDomain(
                addDepartmanLessonModel.DepartmanId,
                addDepartmanLessonModel.LessonId
            );
        }

        public static DepartmanLessonDomain Create(DepartmanLessonEntity departmanLessonEntity)
        {
            return new DepartmanLessonDomain(
                departmanLessonEntity.DepartmanLessonId,
                departmanLessonEntity.DepartmanId,
                departmanLessonEntity.LessonId
            );
        }
    }
}