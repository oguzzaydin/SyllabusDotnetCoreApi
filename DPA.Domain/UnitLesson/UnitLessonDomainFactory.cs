namespace DPA.Domain.UnitLesson
{
    public static class UnitLessonDomainFactory
    {
        public static UnitLessonDomain Create(long lessonId, long userId, long locationId)
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