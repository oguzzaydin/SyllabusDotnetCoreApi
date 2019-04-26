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
                addLessonModel.AKTS,
                addLessonModel.LessonType,
                addLessonModel.WeeklyHour,
                addLessonModel.SemesterType
            );
        }

        public static LessonDomain Create(UpdateLessonModel updateLessonModel)
        {
            return new LessonDomain(
                updateLessonModel.Name,
                updateLessonModel.LessonCode,
                updateLessonModel.AKTS,
                updateLessonModel.LessonType,
                updateLessonModel.WeeklyHour,
                updateLessonModel.SemesterType
            );
        }

        public static LessonDomain Create(LessonEntity lessonEntity)
        {
            return new LessonDomain(
                lessonEntity.Name,
                lessonEntity.LessonCode,
                lessonEntity.AKTS,
                lessonEntity.LessonType,
                lessonEntity.WeeklyHour,
                lessonEntity.SemesterType
            );
        }
    }
}