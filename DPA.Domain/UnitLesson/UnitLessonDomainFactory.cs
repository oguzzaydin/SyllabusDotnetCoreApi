using DPA.Model;

namespace DPA.Domain.UnitLesson
{
    public static class UnitLessonDomainFactory
    {
        public static UnitLessonDomain Create(long lessonId = 0, long userId = 0, long locationId = 0)
        {
            return new UnitLessonDomain
            (
                lessonId,
                userId,
                locationId
            );
        }

        public static UnitLessonDomain Create(UpdateUnitLessonModel updateUnitLessonModel)
        {
            return new UnitLessonDomain
            (
                updateUnitLessonModel.UnitLessonId,
                updateUnitLessonModel.LocationId,
                updateUnitLessonModel.StarTime,
                updateUnitLessonModel.EndTime,
                updateUnitLessonModel.DayOfTheWeekType
            );
        }

        public static UnitLessonDomain Create(UnitLessonEntity unitLessonEntity)
        {
            return new UnitLessonDomain
            (
                unitLessonEntity.UnitLessonId,
                unitLessonEntity.LessonId,
                unitLessonEntity.LocationId,
                unitLessonEntity.SyllabusId,
                unitLessonEntity.UserId,
                unitLessonEntity.StarTime,
                unitLessonEntity.EndTime,
                unitLessonEntity.SemesterType,
                unitLessonEntity.GroupType,
                unitLessonEntity.DayOfTheWeekType
            );
        }
    }
}