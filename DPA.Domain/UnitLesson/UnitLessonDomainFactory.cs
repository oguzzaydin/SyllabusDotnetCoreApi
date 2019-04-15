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
    }
}