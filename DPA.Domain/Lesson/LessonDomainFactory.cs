using DPA.Model;

namespace DPA.Domain
{
    public static class LessonDomainFactory
    {
        public static LessonDomain Create(AddLessonModel addLessonModel)
        {
            return new LessonDomain(
                addLessonModel.Name,
                addLessonModel.LessonCode,
                addLessonModel.Group,
                addLessonModel.AKTS,
                addLessonModel.LessonType,
                addLessonModel.EducationType,
                addLessonModel.WeeklyHour
            );
        }

        public static LessonDomain Create(UpdateLessonModel updateLessonModel)
        {
            return new LessonDomain(
                updateLessonModel.Name,
                updateLessonModel.LessonCode,
                updateLessonModel.Group,
                updateLessonModel.AKTS,
                updateLessonModel.LessonType,
                updateLessonModel.EducationType,
                updateLessonModel.WeeklyHour
            );
        }

        public static LessonDomain Create(LessonEntity lessonEntity)
        {
            return new LessonDomain(
                lessonEntity.Name,
                lessonEntity.LessonCode,
                lessonEntity.Group,
                lessonEntity.AKTS,
                lessonEntity.LessonType,
                lessonEntity.EducationType,
                lessonEntity.WeeklyHour
            );
        }
    }
}